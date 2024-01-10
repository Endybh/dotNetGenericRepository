using Lab.GenericRepository.Core;
using Microsoft.EntityFrameworkCore;

namespace Lab.GenericRepository.Infrastructure
{
    public class MedicalRecordContext:DbContext
    {
        public DbSet<Patient> Patients{get;set;}
        public DbSet<MedicalRecord> MedicalRecords{get;set;}
        public DbSet<Professional> Professionals{get;set;}
        public MedicalRecordContext(DbContextOptions<MedicalRecordContext> options)
           :base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PatientMapDbConfiguration());

            modelBuilder.ApplyConfiguration(new MedicalRecordMapDbConfiguration());

            modelBuilder.ApplyConfiguration(new ProfessionalMapDbConfiguration());
        }
    }
}