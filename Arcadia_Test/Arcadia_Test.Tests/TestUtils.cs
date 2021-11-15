using Arcadia_Test.Configuration;
using Arcadia_Test.Data;
using Arcadia_Test.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcadia_Test.Tests
{
    public static class TestUtils
    {
        public static List<TestItem> BuildTestItems(int testItemsLength, int pretestItemsCount) =>
            Enumerable.Range(0, testItemsLength).Select(index => new TestItem
            {
                ItemId = index.ToString(),
                ItemType = index < pretestItemsCount ? TestItemTypeEnum.Pretest : TestItemTypeEnum.Operational
            }).ToList();

        public static List<TestItem> BuildTestItems(AppConfig config) => BuildTestItems(config.TestItemsLength, config.PretestItemsCount);

        public static AppConfig BuildAppConfig(int firstPretestItemsCount, int testItemsLength, int pretestItemsCount) =>
            new AppConfig
            {
                FirstPretestItemsCount = firstPretestItemsCount,
                TestItemsLength = testItemsLength,
                PretestItemsCount = pretestItemsCount
            };
    }
}
