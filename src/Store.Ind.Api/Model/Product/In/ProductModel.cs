using System;
using System.Collections.Generic;

namespace Store.Ind.Api.Model.Product.In
{
    public class ProductModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal CostPrice { get; set; }

        public decimal FinalPrice { get; set; }

        public string Barcode { get; set; }
        public DateTime CreatedAt { get; set; }

        public int CategoryId { get; set; }

        public List<VariantModel> Variants { get; set; }
    }
}
