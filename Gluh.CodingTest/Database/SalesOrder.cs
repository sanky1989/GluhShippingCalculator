using System;
using System.Collections.Generic;
using System.Text;

namespace Gluh.CodingTest.Database
{
    public class SalesOrder
    {
        public int ID { get; set; }

        public string OrderNumber { get; set; }

        public string DeliveryAddress { get; set; }

        public string DeliveryState { get; set; }

        public string DeliveryPostalCode { get; set; }

        public List<SalesOrderLine> Lines { get; set; }
        public  SalesOrder()
        {
            Lines = new List<SalesOrderLine>();
        }
    }
}
