using System;
using System.Collections.Generic;

namespace Store.Ind.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name {get; set;}

        public string Description { get; set; }

        public decimal CostPrice { get; set; }

        public decimal FinalPrice { get; set; }

        public string Barcode { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }

        public Category Category { get; set; }

        public Brand Brand { get; set; }
        public List<Variant> Variants { get; set; }
    }
}