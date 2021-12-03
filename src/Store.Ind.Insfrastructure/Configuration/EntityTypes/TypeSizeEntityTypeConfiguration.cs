using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Ind.Domain.Entities;

namespace Store.Ind.Insfrastructure.Configuration.EntityTypes
{
    class TypeSizeEntityTypeConfiguration : IEntityTypeConfiguration<TypeSize>
    {
        public void Configure(EntityTypeBuilder<TypeSize> builder)
        {
            builder.HasKey(x => x.Code);

            builder.HasData(
                new TypeSize { Code = Domain.Enums.TypeSizes.XS, Description = Domain.Enums.TypeSizes.XS.ToString() },
                new TypeSize { Code = Domain.Enums.TypeSizes.S, Description = Domain.Enums.TypeSizes.S.ToString() },
                new TypeSize { Code = Domain.Enums.TypeSizes.M, Description = Domain.Enums.TypeSizes.M.ToString() },
                new TypeSize { Code = Domain.Enums.TypeSizes.L, Description = Domain.Enums.TypeSizes.L.ToString() },
                new TypeSize { Code = Domain.Enums.TypeSizes.XL, Description = Domain.Enums.TypeSizes.XL.ToString() },
                new TypeSize { Code = Domain.Enums.TypeSizes.XXL, Description = Domain.Enums.TypeSizes.XXL.ToString() },
                new TypeSize { Code = Domain.Enums.TypeSizes.XXXL, Description = Domain.Enums.TypeSizes.XXXL.ToString() },
                new TypeSize { Code = Domain.Enums.TypeSizes.XXXXL, Description = Domain.Enums.TypeSizes.XXXXL.ToString() });
        }
    }
}
