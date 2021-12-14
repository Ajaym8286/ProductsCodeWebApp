using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsCodeWebApp.Models
{
    public class ProductService
    {
        public string Product_ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<ProductService> ProductsDetails { get; set; }


    }
}