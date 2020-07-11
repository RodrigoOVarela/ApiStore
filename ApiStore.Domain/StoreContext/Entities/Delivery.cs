using ApiStore.Domain.StoreContext.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiStore.Domain.StoreContext.Entities
{
    public class Delivery
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            CreateDate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }
        public DateTime CreateDate { get; private set; }

        public DateTime EstimatedDeliveryDate { get; private set; }

        public EDeliveryStatus Status { get; private set; }

        public void Ship()
        {
            //se data no passado não entrega
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel()
        {
            //se stats entregue não pode cancelar
            Status = EDeliveryStatus.Canceled;
        }
    }
}
