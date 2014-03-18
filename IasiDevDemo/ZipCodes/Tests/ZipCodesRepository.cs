using NUnit.Framework;

namespace ZipCodes.Tests.ZipCodesRepositoryTests
{

        [TestFixture]
        public class GivenEmptyListOfCitiesShould : ZipCodesRepository
        {
            public ZipCodesRepository CreateSUT()
            {
                return new ZipCodesRepository();
            }
            [Test]
            public void PopulateTheListOfCities()
            {
                ZipCodesRepository sut = CreateSUT();
                sut.UpdateCities();
                Assert.That(sut.Cities,Has.Count.EqualTo(8));
        }
    }
}