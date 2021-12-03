using Store.Ind.Domain.Enums;

namespace Store.Ind.Domain.Entities
{
    public class Variant : BaseEntity
    {
        public string Name { get; set; }

        public TypeSizes Size { get; set; }

        public TypeColors Color { get; set; }

        public int Stock { get; set; }
    }
}