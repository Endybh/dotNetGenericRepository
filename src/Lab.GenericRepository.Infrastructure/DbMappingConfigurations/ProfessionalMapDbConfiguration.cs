using Lab.GenericRepository.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.GenericRepository.Infrastructure
{
    public class ProfessionalMapDbConfiguration : IEntityTypeConfiguration<Professional>
    {
        public void Configure(EntityTypeBuilder<Professional> builder)
        {
            builder.HasKey(e=>e.Id);

            builder.Property(e=>e.Specialty);

            builder.Property(e=>e.Name);

            builder.Property(e=>e.RegistrationCouncil);

            builder.Property(e=>e.ProfessionalRegisterNumber);

            builder.ToTable("professional");
        }
    }
}
