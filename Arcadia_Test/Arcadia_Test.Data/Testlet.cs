namespace Arcadia_Test.Data
{
    using System;
    using System.Collections.Generic;

    public class Testlet
    {
        public Testlet(string testletId, IEnumerable<TestItem> items)
        {
            TestletId = testletId;
            Items = items;
        }

        public string TestletId { get; set; }
        public IEnumerable<TestItem> Items { get; set; }

    }
}
