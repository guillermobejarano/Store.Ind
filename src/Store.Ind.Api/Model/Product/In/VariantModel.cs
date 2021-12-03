using Store.Ind.Domain.Entities;

namespace Store.Ind.Api.Model.Product.In
{
    public class VariantModel
    {
        public TypeSize Size { get; set; }
        public TypeColor Color { get; set; }

        public int Stock { get; set; }
    }
}
