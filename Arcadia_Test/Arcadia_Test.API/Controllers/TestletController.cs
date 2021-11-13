using Arcadia_Test.Data;
using Arcadia_Test.Data.Enums;
using Arcadia_Test.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcadia_Test.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestletController : ControllerBase
    {
        private readonly ITestletService _testletService;

        public TestletController(ITestletService testletService)
        {
            _testletService = testletService;
        }

        [HttpGet]
        public Testlet Get()
        {
            var res = _testletService.GenerateTest();
            return res;
        }
    }
}
