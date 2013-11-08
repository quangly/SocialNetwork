using AngularJS_WebApi_EF.Controllers;
using AngularJS_WebApi_EF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var cntr = new PersonController();
            var person = cntr.GetUser("jane123");
            Assert.IsTrue(person != null);

        }


    }
}
