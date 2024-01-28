
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Terminal_EF.Entities;

namespace BusTerminal.EntityMaps
{
    public class TripEntityMaps : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.Property(_ => _.Origin).HasMaxLength(50).IsRequired();
            builder.Property(_ => _.Destination).HasMaxLength(50).IsRequired();
            builder.Property(_ => _.TicketPrice).HasPrecision(10, 3);

        }
        
    }
}
