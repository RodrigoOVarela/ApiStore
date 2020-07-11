using ApiStore.Domain.StoreContext.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c = new Customer(
                "Rodrigo",
                "Varela",
                "9999999999999",
                "rodrigo@gmail.com",
                "99555789",
                "edmundo soldatelli");

            var order = new Order(c);
        }
    }
}
