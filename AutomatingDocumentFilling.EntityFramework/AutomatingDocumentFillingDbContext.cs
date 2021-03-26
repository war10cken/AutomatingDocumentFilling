using AutomatingDocumentFilling.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomatingDocumentFilling.EntityFramework
{
    public class AutomatingDocumentFillingDbContext : DbContext
    {
        public DbSet<AcademicDiscipline> AcademicDisciplines { get; set; }
        public DbSet<FormOfEducation> FormOfEducations { get; set; }
        public DbSet<GeneralCompetence> GeneralCompetences { get; set; }
        public DbSet<IntermediateCertifications> IntermediateCertificationsEnumerable { get; set; }
        public DbSet<Knowledge> Knowledges { get; set; }
        public DbSet<PedagogicalQualifications> PedagogicalQualificationsEnumerable { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<User> Users { get; set; }

        public AutomatingDocumentFillingDbContext(DbContextOptions options) : base(options) { }
    }
}