using ApiStore.Domain.StoreContext.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiStore.Domain.StoreContext.Entities
{
    public class Order
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;

        public Order(Customer customer)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }
        public Customer Customer { get; private set; }

        public string Number { get; private set; }

        public DateTime CreateDate { get; private set; }

        public EOrderStatus Status { get; private set; }

        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();

        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public void AddItem(OrderItem item)
        {
            //valida item
            //add ao pedido
            _items.Add(item);
        }

        public void Place()
        {
            //gerar número do pedido
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();


        }

        public void Pay()
        {
            Status = EOrderStatus.Paid;



        }

        public void Ship()
        {
            //a cada 5 produtos é uma entrega
            var deliveries = new List<Delivery>();
            deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
            var count = 1;
            foreach (var item in _items)
            {
                if (count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }

            //envia todas as entregas
            deliveries.ForEach(x => x.Ship());

            //adiciona as entregas aos pedidos
            deliveries.ForEach(x =>_deliveries.Add(x));

        }

        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }


    }
}
