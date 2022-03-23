using CleaningManagement.DAL.Abstraction.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleaningManagement.DAL.Configurations
{
    public class CleaningPlanEntityConfiguration: IEntityTypeConfiguration<CleaningPlan>
    {
        public void Configure(EntityTypeBuilder<CleaningPlan> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NewID()");
            builder.Property(x => x.Title).IsRequired().HasMaxLength(256);
            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(512);
        }
    }
}