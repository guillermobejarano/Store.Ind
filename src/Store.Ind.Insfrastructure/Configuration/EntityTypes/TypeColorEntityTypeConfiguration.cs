using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Ind.Domain.Entities;

namespace Store.Ind.Insfrastructure.Configuration.EntityTypes
{
    class TypeColorEntityTypeConfiguration : IEntityTypeConfiguration<TypeColor>
    {
        public void Configure(EntityTypeBuilder<TypeColor> builder)
        {
            builder.HasKey(x => x.Code);

            builder.HasData(
                new TypeColor { Code = Domain.Enums.TypeColors.Black, Description = Domain.Enums.TypeColors.Black.ToString() },
                new TypeColor { Code = Domain.Enums.TypeColors.Blue, Description = Domain.Enums.TypeColors.Blue.ToString() },
                new TypeColor { Code = Domain.Enums.TypeColors.White, Description = Domain.Enums.TypeColors.White.ToString() },
                new TypeColor { Code = Domain.Enums.TypeColors.Brown, Description = Domain.Enums.TypeColors.Brown.ToString() },
                new TypeColor { Code = Domain.Enums.TypeColors.Green, Description = Domain.Enums.TypeColors.Green.ToString() },
                new TypeColor { Code = Domain.Enums.TypeColors.Grey, Description = Domain.Enums.TypeColors.Grey.ToString() },
                new TypeColor { Code = Domain.Enums.TypeColors.Red, Description = Domain.Enums.TypeColors.Red.ToString() },
                new TypeColor { Code = Domain.Enums.TypeColors.Yellow, Description = Domain.Enums.TypeColors.Yellow.ToString() });
        }
    }
}
