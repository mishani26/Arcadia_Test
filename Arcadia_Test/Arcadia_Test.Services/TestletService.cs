namespace Arcadia_Test.Services
{
    using Arcadia_Test.Configuration;
    using Arcadia_Test.Data;
    using Arcadia_Test.Data.Enums;
    using Arcadia_Test.Services.Interfaces;
    using Microsoft.Extensions.Options;
    using System;
    using System.Linq;

    public class TestletService : ITestletService
    {
        private readonly IOptions<AppConfig> _config;
        private readonly ITestRandomizeService _testRandomizeService;

        public TestletService(IOptions<AppConfig> config, ITestRandomizeService testRandomizeService)
        {
            _config = config;
            _testRandomizeService = testRandomizeService;
        }

        public Testlet GenerateTest()
        {
            var testItems = Enumerable.Range(0, _config.Value.TestItemsLength).Select(index => new TestItem
            {
                ItemId = index.ToString(),
                ItemType = index < _config.Value.PretestItemsCount ? TestItemTypeEnum.Pretest : TestItemTypeEnum.Operational
            }).ToList();

            return new Testlet(new Random().Next().ToString(), _testRandomizeService.Randomize(testItems));
        }
    }
}
