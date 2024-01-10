using Lab.GenericRepository.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.GenericRepository.Infrastructure
{
    public class PatientMapDbConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e=>e.Id);

            builder.Property(e=>e.Name);

            builder.Property(e=>e.ContactPhoneNumber);

            builder.Property(e=>e.BirthDate);

            builder.Property(e=>e.Address);

            builder.Property(e=>e.NamePersonReference);

            builder.Property(e=>e.PhoneReference);

            builder.ToTable("patient");
        }
    }
}
