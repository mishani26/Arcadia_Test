namespace Arcadia_Test.Services.Interfaces
{
    using Arcadia_Test.Data;
    using System.Collections.Generic;

    public interface ITestRandomizeService
    {
        IEnumerable<TestItem> Randomize(IReadOnlyList<TestItem> testItems);
    }
}
