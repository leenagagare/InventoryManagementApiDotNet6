﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDataLayer.Entities
{
    public class Product
    {
        [Key]
        public int ProductCode { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ProductDescription { get; set; }

    }
}


