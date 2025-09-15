using Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ADbContext.Configuration
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(U => U.Id);

            builder.Property(U => U.Password).HasMaxLength(255);
            builder.Property(U => U.UserName).HasMaxLength(255);
           
            builder.Property(U => U.IsGuest);

            builder.HasOne(U => U.Person).WithOne(P => P.User).HasForeignKey<User>(U => U.PersonID)
                .OnDelete(DeleteBehavior.Restrict);
            ;

        }
    }

}

