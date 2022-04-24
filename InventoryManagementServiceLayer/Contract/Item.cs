using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementServiceLayer.Contract
{
    public class Product
    {
        public int ProductCode { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public decimal ProductDescription { get; set; }

    }
}


