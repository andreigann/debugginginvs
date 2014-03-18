using System;
using NUnit.Framework;

namespace ZipCodes.Tests.DateIntervalTests
{
    [TestFixture]
    public class GivenPartialLeftOverlapShould
    {
        private Tuple<DateTime, DateTime> actual;

        public DateInterval CreateSUT(DateTime start, DateTime end)
        {
            return new DateInterval(start, end);
        }

        [SetUp]
        public virtual void SetUp()
        {
            DateInterval sut = CreateSUT(new DateTime(2014, 2, 2), new DateTime(2014, 3, 3));
            actual = sut.GetOverlap(Tuple.Create("2014,2,20", "2014,3,20"));

        }
        [Test]
        public void ReturnLeftSideFromNewInterval()
        {
            Assert.That(actual.Item1, Is.EqualTo(new DateTime(2014, 2, 20)));
        }

        [Test]
        public void ReturnRightSideFromOldInterval()
        {
            Assert.That(actual.Item2, Is.EqualTo(new DateTime(2014, 3, 3)));
        }
    }
    [TestFixture]
    public class GivenOldIntervalWrapsNewIntervalShould
    {
        private Tuple<DateTime, DateTime> actual;

        public DateInterval CreateSUT(DateTime start, DateTime end)
        {
            return new DateInterval(start, end);
        }

        [SetUp]
        public virtual void SetUp()
        {
            DateInterval sut = CreateSUT(new DateTime(2014, 2, 2), new DateTime(2014, 3, 3));
            actual = sut.GetOverlap(Tuple.Create("2014,2,10", "2014,2,20"));

        }
        [Test]
        public void ReturnLeftSideFromNewInterval()
        {
            Assert.That(actual.Item1, Is.EqualTo(new DateTime(2014, 2, 10)));
        }

        [Test]
        public void ReturnRightSideFromNewInterval()
        {
            Assert.That(actual.Item2, Is.EqualTo(new DateTime(2014, 2, 20)));
        }
    }
    [TestFixture]
    public class GivenNewIntervalWrapsOldIntervalShould
    {
        private Tuple<DateTime, DateTime> actual;

        public DateInterval CreateSUT(DateTime start, DateTime end)
        {
            return new DateInterval(start, end);
        }

        [SetUp]
        public virtual void SetUp()
        {
            DateInterval sut = CreateSUT(new DateTime(2014, 2, 10), new DateTime(2014, 2, 20));
            actual = sut.GetOverlap(Tuple.Create("2014,2,1", "2014,3,1"));

        }
        [Test]
        public void ReturnLeftSideFromNewInterval()
        {
            Assert.That(actual.Item1, Is.EqualTo(new DateTime(2014, 2, 10)));
        }

        [Test]
        public void ReturnRightSideFromNewInterval()
        {
            Assert.That(actual.Item2, Is.EqualTo(new DateTime(2014, 2, 20)));
        }
    }
}