namespace Arcadia_Test.Tests
{
    using NUnit.Framework;
    using Moq;
    using Arcadia_Test.Services.Interfaces;
    using System.Linq;
    using Microsoft.Extensions.Options;
    using Arcadia_Test.Configuration;
    using Arcadia_Test.Services;

    public class TestletServiceTest
    {
        [Test]
        public void Return_Value_Not_Null()
        {
            var config = TestUtils.BuildAppConfig(2, 10, 4);
            var testItems = TestUtils.BuildTestItems(config);

            var mockConfig = new Mock<IOptions<AppConfig>>();
            mockConfig.Setup(x => x.Value).Returns(config);

            var mockService = new Mock<ITestRandomizeService>();
            mockService.Setup(x => x.Randomize(testItems.ToList())).Returns(testItems);

            var testletService = new TestletService(mockConfig.Object, mockService.Object);

            var testlet = testletService.GenerateTest();
            Assert.NotNull(testlet);
        }

        [Test]
        public void Return_Id_Not_Null()
        {
            var config = TestUtils.BuildAppConfig(2, 10, 4);
            var testItems = TestUtils.BuildTestItems(config);

            var mockConfig = new Mock<IOptions<AppConfig>>();
            mockConfig.Setup(x => x.Value).Returns(config);

            var mockService = new Mock<ITestRandomizeService>();
            mockService.Setup(x => x.Randomize(testItems.ToList())).Returns(testItems);

            var testletService = new TestletService(mockConfig.Object, mockService.Object);

            var testlet = testletService.GenerateTest();
            Assert.NotNull(testlet.TestletId);
        }
    }
}