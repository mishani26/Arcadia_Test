using System;
using System.Collections.Generic;
using System.Text;

namespace Arcadia_Test.Services
{
    public class TestException: Exception
    {
        public TestException(string message): base(message)
        {

        }
    }
}
