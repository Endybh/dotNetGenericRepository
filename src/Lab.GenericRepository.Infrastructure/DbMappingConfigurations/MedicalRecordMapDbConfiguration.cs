using Lab.GenericRepository.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.GenericRepository.Infrastructure
{
    public class MedicalRecordMapDbConfiguration : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            builder.HasKey(e=>e.Id);

            builder.Property(e=>e.SectionDateHour);

            builder.Property(e=>e.SectionDescription);

            builder.Property(e=>e.ProfessionalFkId);

            builder.Property(e=>e.PatientFkId);

            builder.HasOne(e=>e.Professional)
                .WithMany(f=>f.MedicalRecords)
                .HasForeignKey(e=>e.ProfessionalFkId);

            builder.HasOne(e=>e.Patient)
                .WithMany(f=>f.MedicalRecords)
                .HasForeignKey(e=>e.PatientFkId);

            builder.ToTable("medical_record");
        }
    }
}
