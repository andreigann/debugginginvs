using System;
using System.Diagnostics;

namespace ZipCodes
{
    public class DateInterval
    {
        public DateInterval(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        /// <summary>
        ///     immediate window, autos, data tips
        /// </summary>
        /// <param name="intervalText"></param>
        /// <returns></returns>
        public Tuple<DateTime, DateTime> GetOverlap(Tuple<string, string> intervalText)
        {
            Tuple<DateTime, DateTime> interval = ParseInterval(intervalText);
            return OutsideOfInterval(interval) ? null : GetOverlap(interval);
        }


        private Tuple<DateTime, DateTime> GetOverlap(Tuple<DateTime, DateTime> interval)
        {
            DateTime overlapStart = Start;
            if (Start < interval.Item1)
                overlapStart = interval.Item1;
            Debug.WriteLine("left overlap: {0}", overlapStart);
            DateTime overlapEnd = End;
            if (End > interval.Item2)
                overlapEnd = interval.Item2;
            Debug.WriteLine("right overlap: {0}", overlapStart);

            return new Tuple<DateTime, DateTime>(overlapStart, overlapEnd);
        }

        /// <summary>
        ///     autos is great
        /// </summary>
        /// <param name="interval"></param>
        /// <returns></returns>
        private static int GetOverlapForAutos(Tuple<DateTime, DateTime> interval)
        {
            if (interval.Item1 < interval.Item2 || DateTime.Today > interval.Item1 || DateTime.Now > interval.Item2)
                return 1;
            return 3;
        }

        private bool OutsideOfInterval(Tuple<DateTime, DateTime> interval)
        {
            if (Start > interval.Item2)
                return true;
            if (End < interval.Item1)
                return true;
            return false;
        }

        private static Tuple<DateTime, DateTime> ParseInterval(Tuple<string, string> intervalText)
        {
            DateTime startDate = DateTime.Parse(intervalText.Item1);
            DateTime endDate = DateTime.Parse(intervalText.Item2);
            return new Tuple<DateTime, DateTime>(startDate, endDate);
        }
    }
}