using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using IasiDevDemo.Infrastructure;
using log4net;

namespace IasiDevDemo.Controllers
{
    public class DemoController : Controller
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(DemoController));


        public ActionResult Index()
        {
            return View();
        }

        public string Exceptions()
        {
            // Just My Code
            // Exceptions
            // Break on exception check
            try
            {
                Logger.Info("Before throwing exception");
                var names = new[] {"Name1", "Name2"};
                var thirdName = names[2];
            }
            catch (Exception ex)
            {
                Logger.Error("Exception!!! ", ex);
                //throw;
            }


            return "Success";
        }

        public string SubexpressionBreakpoints()
        {
            int i;
            int j;

            for (i = 0, j = 0; i < 10; i++, j++)
            {
                Trace.WriteLine(String.Format("i = {0}; j = {1}", i, j));
            }

            return "Success";
        }

        public string HitCountBreakpoints()
        {
            var enumerableCollection = Enumerable.Range(1, 1000);

            var sum = 0;
            foreach (var item in enumerableCollection)
            {
                sum += GetFirstDigit(item);
            }

            return "Success";
        }

        private int GetFirstDigit(int number)
        {
            var charDigit = number.ToString(CultureInfo.InvariantCulture)[0];
            if (number == 500)
            {
                throw new DemoException();
            }
            return Convert.ToInt32(charDigit);
        }

        public string ConditionalBreakpoints()
        {

            int i;
            int j;
            for (i = 0, j = 0; i < 10; i++, j--)
            {
                var sb = new StringBuilder();
                sb.AppendFormat("i = {0}, j = {0}", i , j);
                Trace.WriteLine(sb.ToString());
            }


            var names = new[] { "Dan", "Andrei", "Mihai" };
            foreach (var name in names)
            {
                Trace.WriteLine(name);
            }

            return "Success";
        }


        private bool IsMyName(string name)
        {
            if (name == "Andrei")
            {
                return true;
            }
            return false;
        }

        public string FilterBreakpoints()
        {
            const int noOperations = 10;
            //var tasks = new Task[noTasks];
            var threads = new Thread[noOperations];

            for (int i = 0; i < noOperations; i++)
            {
                threads[i] = new Thread(DoWork);
                threads[i].Start();
            }

            waitHandle.Set();

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }

            return "Success";
        }


        ManualResetEvent waitHandle = new ManualResetEvent(false);
        public void DoWork()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Thread {0} starting.", GetCurrentThreadId());
            Trace.WriteLine(sb.ToString());
            Thread.Sleep(0);
            waitHandle.WaitOne();
            sb.Length = 0;
            sb.AppendFormat("Thread {0} ending.", GetCurrentThreadId());
            Trace.WriteLine(sb.ToString());
        }

        private int GetCurrentThreadId()
        {
            return Thread.CurrentThread.ManagedThreadId;

        }

        public string WhenHitBreakpoints()
        {
            var sum = 0;
            foreach (var i in Enumerable.Range(1, 100))
            {
                if (i % 14 == 0)
                {
                    sum += i;
                }
            }

            return "Success " + sum;
        }

        public string DeepStack()
        {
            var bll = new Bll();
            Customer customer = new Customer
                {
                    Id = 10,
                    Name = "Mihai"
                };
            bll.UpdateCustomer(customer);


            return "Success";
        }

        public async Task<string> GetDataFromExternalSourceAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            await Task.Delay(TimeSpan.FromSeconds(3));
            await Task.Delay(TimeSpan.FromSeconds(2));


            return "Success";
        }

        public async Task<string> GetDataFromExternalSourceOneAwaitAsync()
        {
            var task1 = Task.Delay(TimeSpan.FromSeconds(1));
            var task2 = Task.Delay(TimeSpan.FromSeconds(3));
            var task3 = Task.Delay(TimeSpan.FromSeconds(2));

            await Task.WhenAll(task1, task2, task3);

            return "Success";
        }

    }
}