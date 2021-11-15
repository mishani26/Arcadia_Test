namespace Arcadia_Test.Services
{
    using Arcadia_Test.Configuration;
    using Arcadia_Test.Data;
    using Arcadia_Test.Data.Enums;
    using Arcadia_Test.Services.Interfaces;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TestRandomizeService : ITestRandomizeService
    {
        IOptions<AppConfig> _config;

        public TestRandomizeService(IOptions<AppConfig> config)
        {
            _config = config;
        }
        public IEnumerable<TestItem> Randomize(IReadOnlyList<TestItem> testItems)
        {

            if (_config.Value.FirstPretestItemsCount > _config.Value.PretestItemsCount)
            {
                throw new TestException($"Pretest items count cannot be less then in begin");
            }

            var pretestItems = testItems.Where(s => s.ItemType == TestItemTypeEnum.Pretest).ToList();

            if(pretestItems.Count != _config.Value.PretestItemsCount)
            {
                throw new TestException($"Pretest items count must be {_config.Value.PretestItemsCount}");
            }

            var result = pretestItems.Take(_config.Value.FirstPretestItemsCount).ToArray();
            var resultIds = result.Select(x => x.ItemId).ToHashSet();

            var shufleList = testItems.Where(s => !resultIds.Contains(s.ItemId)).ToArray();
            int shufleLength = testItems.Count - _config.Value.FirstPretestItemsCount; 
            var rng = new Random();
            while (shufleLength > 1)
            {
                int nextElem = rng.Next(shufleLength--);
                var currentElem = shufleList[shufleLength];
                shufleList[shufleLength] = shufleList[nextElem];
                shufleList[nextElem] = currentElem;
            }
            return result.Concat(shufleList);
        }
    }
}
