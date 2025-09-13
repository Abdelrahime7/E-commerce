using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.ADbContext.Configuration
{
    internal class DisacountConfig : IEntityTypeConfiguration<Disacount>
    {
        public void Configure(EntityTypeBuilder<Disacount> builder)
        {
            builder.ToTable("Disacounts");
            builder.HasKey(d => d.Id);
            builder.Property(D => D.Percentag);
            builder.Property(D => D.Type).HasMaxLength(255);
            builder.HasKey(d =>d.IsDeleted);

        }
    }
}
