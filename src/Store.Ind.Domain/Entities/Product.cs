using System.Collections.Generic;

namespace Store.Ind.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name {get; set;}

        public List<Variant> Variants { get; set; }
    }
}