using ApiStore.Domain.StoreContext.Entities;
using ApiStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Rodrigo", "Varela");
            var document = new Document("1234567891234");
            var email = new Email("rodrigo@gmail.com");

            var c = new Customer(name, document, email, "9999999");
            var mouse = new Product("Mouse", "Rato", "image.png", 59.90M, 10);
            var teclado = new Product("Teclado", "Teclado", "image.png", 159.90M, 10);
            var impressra = new Product("Impressora", "Impressora", "image.png", 359.90M, 10);
            var cadeira = new Product("Cadeira", "cadeira", "image.png", 559.90M, 10);

            var order = new Order(c);
            order.AddItem(new OrderItem(mouse, 5));
            order.AddItem(new OrderItem(teclado, 5));
            order.AddItem(new OrderItem(cadeira, 5));
            order.AddItem(new OrderItem(impressra, 5));

            //realizei o pedido
            order.Place();

            //simular o pagamento
            order.Pay();

            //simular o envio
            order.Ship();

            //simular o cancelamento
            order.Cancel();
        }
    }
}
