
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Terminal_EF.Entities;

namespace BusTerminal.EntityMaps
{
    public class BusEntityMaps : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)

        {
            builder.HasMany(_ => _.Trip).WithOne(_ => _.Bus).HasForeignKey(_ => _.GroupId);
            builder.HasMany(_=>_.Chairs).WithOne(_ => _.Bus).HasForeignKey(_=>_.GroupId);
            builder.Property(_ => _.Name).IsRequired().HasMaxLength(50);
            

        }
      

    }
}
