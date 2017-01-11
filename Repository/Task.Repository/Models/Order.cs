using System;
using Assignment.Repository.Models.Enums;
using System.Collections.Generic;

namespace Assignment.Repository.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public int CustomerId { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderPlacementDate { get; set; }
        public DateTime OrderDeliveryDate { get; set; }
        public TimeSpan TimeToDelivery { get; set; }
        public string OrderInstructions { get; set; }

    }
}
