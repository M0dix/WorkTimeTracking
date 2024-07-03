using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkTimeTracking.Models;

namespace WorkTimeTracking.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(user => user.Id);

            builder.HasIndex(user => user.Email)
                .IsUnique();

            builder.Property(user => user.Email)
                .IsRequired();

            builder.Property(user => user.FirstName)
                .IsRequired();

            builder.Property(user => user.LastName)
                .IsRequired();

            builder.Property(user => user.Patronymic)
                .IsRequired();
        }
    }
}
