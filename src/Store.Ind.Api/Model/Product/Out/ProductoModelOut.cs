using Store.Ind.Api.Model.Product.In;
using System;
using System.Collections.Generic;

namespace Store.Ind.Api.Model.Product.Out
{
    public class ProductoModelOut
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal CostPrice { get; set; }

        public decimal FinalPrice { get; set; }

        public string Barcode { get; set; }
        public DateTime CreatedAt { get; set; }

        public int CategoryName { get; set; }

        public List<VariantModel> Variants { get; set; }
    }
}
