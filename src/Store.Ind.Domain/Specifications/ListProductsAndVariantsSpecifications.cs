using Store.Ind.Domain.Entities;

namespace Store.Ind.Domain.Specifications
{
    public class ListProductsAndVariantsSpecifications : BaseSpecification<Product>
    {
        public ListProductsAndVariantsSpecifications() : base(null)
        {
            AddInclude(u => u.Variants);
        }
    }
}
