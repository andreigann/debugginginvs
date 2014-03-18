using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using NUnit.Framework;
using ZipCodes.USZipClient;

namespace ZipCodes
{
    public class ZipCodesRepository
    {
        private IEnumerable<string> cities= new List<string>();

        public IEnumerable<String> Cities
        {
            get { return cities; }
            set { cities = value; }
        }

        public void UpdateCities()
        {
            IEnumerable<int> zipCodes = GetListOfZipCodes();
            Debug.WriteLine("number of zip codes: {0}", zipCodes.Count());

            IEnumerable<IGrouping<int, int>> zipCodesSlices = zipCodes.GroupBy(c => ((c-1)/10000)%5);
            var zipSource = new USZipSoapClient();
            
            Debug.WriteLine("number of groups: {0}", zipCodesSlices.Count());
            
            var tasks = new List<Task>();
            foreach (var zipCodeSlice in zipCodesSlices)
            {
                var retrieveCityTask = Task.Factory.StartNew(_ => RetrieveCities(zipCodeSlice, zipSource), null);
                tasks.Add(retrieveCityTask);
                retrieveCityTask.ContinueWith(t => AddCities(t.Result));
            }

            Task.WaitAll(tasks.ToArray());
        }

        private int hitCount=0;

        private void AddCities(IEnumerable<string> newCities)
        {
            var uniqueCities = new HashSet<string>(Cities);
            uniqueCities.UnionWith(newCities);

            Debug.WriteLine(string.Format("new set of cities: {0}", string.Join(", ", uniqueCities)));

            Interlocked.Exchange(ref cities, uniqueCities);
        }

        private IEnumerable<string> RetrieveCities(IEnumerable<int> zipCodes, USZipSoapClient zipSource)
        {
            var newCities = new List<string>();
            foreach (int zipCode in zipCodes)
            {
                XmlNode node = zipSource.GetInfoByZIP(zipCode.ToString());
                XmlElement table = node["Table"];
                if (table == null)
                    continue;
                XmlElement city = table["CITY"];
                if (city == null)
                    continue;

                newCities.Add(city.InnerText);
            }
            return newCities;
        }

        public static IEnumerable<int> GetListOfZipCodes()
        {
            return Enumerable.Range(1, 50).Select(x=>(x*10000)+1);
        }

        public IEnumerable<int> FilterListOfZipCodesByComplicatedCriteria(Func<int, bool> aditionalCriteria)
        {
            return
                GetListOfZipCodes()
                    .Where(x => x > 0)
                    .OrderByDescending(_ => _)
                    .Take(100)
                    .OrderByDescending(_ => _)
                    .Take(5).Where(aditionalCriteria);
        }
    }
}