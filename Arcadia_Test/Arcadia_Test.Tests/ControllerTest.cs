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
    using Arcadia_Test.API.Controllers;

    public class ControllerTest
    {
        [Test]
        public void Return_Value_Not_Null()
        {
            var testItems = TestUtils.BuildTestItems(10, 2);

            var testlet = new Testlet(string.Empty, testItems);

            var mockService = new Mock<ITestletService>();
            mockService.Setup(x => x.GenerateTest()).Returns(testlet);

            var controller = new TestletController(mockService.Object);
            Assert.NotNull(controller.Get());
        }
    }
}