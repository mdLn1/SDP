using System;
using System.Collections.Generic;

namespace GCTProject.Data
{
    public partial class Order
    {
        public string Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderTime { get; set; }
        public string DeliveryMethod { get; set; }
    }
}
