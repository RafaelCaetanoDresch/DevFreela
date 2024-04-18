using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infra.Persistence.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
        .HasKey(u => u.Id);

        builder
            .HasMany(u => u.Skills)
            .WithOne()
            .HasForeignKey(u => u.SkillId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
