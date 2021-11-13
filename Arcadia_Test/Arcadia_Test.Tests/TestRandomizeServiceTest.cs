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
    using System;
    public class TestRandomizeServiceTest
    {
        [Test]
        [TestCase(2, 10, 4)]
        [TestCase(4, 12, 5)]
        [TestCase(6, 18, 14)]
        public void Valid_Config_Not_Null(int firstPretestItemsCount, int testItemsLength, int pretestItemsCount)
        {
            var config = new AppConfig();
            config.FirstPretestItemsCount = firstPretestItemsCount;
            config.TestItemsLength = testItemsLength;
            config.PretestItemsCount = pretestItemsCount;

            var testItems = Enumerable.Range(0, config.TestItemsLength).Select(index => new TestItem
            {
                ItemId = index.ToString(),
                ItemType = index < config.PretestItemsCount ? TestItemTypeEnum.Pretest : TestItemTypeEnum.Operational
            });

            var mockConfig = new Mock<IOptions<AppConfig>>();
            mockConfig.Setup(x => x.Value).Returns(config);

            var randomizeService = new TestRandomizeService(mockConfig.Object);
            Assert.NotNull(randomizeService.Randomize(testItems));
        }

        [Test]
        [TestCase(5, 10, 4)]
        [TestCase(10, 9, 5)]
        [TestCase(6, 10, 14)]
        public void Invalid_Config_Exception(int firstPretestItemsCount, int testItemsLength, int pretestItemsCount)
        {
            var config = new AppConfig();
            config.FirstPretestItemsCount = firstPretestItemsCount;
            config.TestItemsLength = testItemsLength;
            config.PretestItemsCount = pretestItemsCount;

            var testItems = Enumerable.Range(0, config.TestItemsLength).Select(index => new TestItem
            {
                ItemId = index.ToString(),
                ItemType = index < config.PretestItemsCount ? TestItemTypeEnum.Pretest : TestItemTypeEnum.Operational
            });

            var mockConfig = new Mock<IOptions<AppConfig>>();
            mockConfig.Setup(x => x.Value).Returns(config);

            var randomizeService = new TestRandomizeService(mockConfig.Object);
            Assert.Throws<Exception>(() => randomizeService.Randomize(testItems));
        }
    }
}