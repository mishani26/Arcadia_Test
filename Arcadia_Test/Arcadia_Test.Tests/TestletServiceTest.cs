namespace Arcadia_Test.Tests
{
    using NUnit.Framework;
    using Moq;
    using Arcadia_Test.Services.Interfaces;
    using System.Linq;
    using Arcadia_Test.Data;
    using Arcadia_Test.Data.Enums;
    using Microsoft.Extensions.Options;
    using Arcadia_Test.Configuration;
    using Arcadia_Test.Services;

    public class TestletServiceTest
    {
        [Test]
        public void Return_Value_Not_Null()
        {
            var testItems = Enumerable.Range(0, 10).Select(index => new TestItem
            {
                ItemId = index.ToString(),
                ItemType = index < 2 ? TestItemTypeEnum.Pretest : TestItemTypeEnum.Operational
            });

            var config = new AppConfig();
            config.FirstPretestItemsCount = 2;
            config.TestItemsLength = 10;
            config.PretestItemsCount = 4;



            var mockConfig = new Mock<IOptions<AppConfig>>();
            mockConfig.Setup(x => x.Value).Returns(config);

            var mockService = new Mock<ITestRandomizeService>();
            mockService.Setup(x => x.Randomize(testItems)).Returns(testItems);

            var testletService = new TestletService(mockConfig.Object, mockService.Object);

            var testlet = testletService.GenerateTest();
            Assert.NotNull(testlet);
        }

        [Test]
        public void Return_Id_Not_Null()
        {
            var testItems = Enumerable.Range(0, 10).Select(index => new TestItem
            {
                ItemId = index.ToString(),
                ItemType = index < 2 ? TestItemTypeEnum.Pretest : TestItemTypeEnum.Operational
            });

            var config = new AppConfig();
            config.FirstPretestItemsCount = 2;
            config.TestItemsLength = 10;
            config.PretestItemsCount = 4;



            var mockConfig = new Mock<IOptions<AppConfig>>();
            mockConfig.Setup(x => x.Value).Returns(config);

            var mockService = new Mock<ITestRandomizeService>();
            mockService.Setup(x => x.Randomize(testItems)).Returns(testItems);

            var testletService = new TestletService(mockConfig.Object, mockService.Object);

            var testlet = testletService.GenerateTest();
            Assert.NotNull(testlet.TestletId);
        }
    }
}