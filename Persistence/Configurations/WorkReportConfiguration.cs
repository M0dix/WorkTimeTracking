using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkTimeTracking.Models;

namespace WorkTimeTracking.Persistence.Configurations
{
    public class WorkReportConfiguration : IEntityTypeConfiguration<WorkReport>
    {
        public void Configure(EntityTypeBuilder<WorkReport> builder)
        {
            builder.Property(workReport => workReport.Hours)
                .IsRequired();

            builder.Property(workReport => workReport.Date)
                .IsRequired();
        }
    }
}
