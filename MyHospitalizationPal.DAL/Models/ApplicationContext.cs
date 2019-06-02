using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyHospitalizationPal.DAL.Models
{
    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DailySchedule> DailySchedule { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<EmergencyContact> EmergencyContact { get; set; }
        public virtual DbSet<Encounter> Encounter { get; set; }
        public virtual DbSet<EncounterNote> EncounterNote { get; set; }
        public virtual DbSet<Feeling> Feeling { get; set; }
        public virtual DbSet<HealthProfessional> HealthProfessional { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<ScheduledEvent> ScheduledEvent { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:serverlicenta.database.windows.net,1433;Initial Catalog=MobilityDb;Persist Security Info=False;User ID=IchimTeodor;Password=Idontcare1.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;", b => b.MigrationsAssembly("MyHospitalizationPal.Server"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DailySchedule>(entity =>
            {
                entity.HasOne(d => d.HeathProfessional)
                    .WithMany(p => p.DailySchedule)
                    .HasForeignKey(d => d.HeathProfessionalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DailySchedule_HealthProfessional");
            });

            modelBuilder.Entity<EmergencyContact>(entity =>
            {
                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.EmergencyContact)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmergencyContact_Patient");
            });

            modelBuilder.Entity<Encounter>(entity =>
            {
                entity.Property(e => e.DateOfDischarge).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Encounter)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Encounter_Department");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Encounter)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Encounter_Patient");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Encounter)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Encounter_Room");
            });

            modelBuilder.Entity<EncounterNote>(entity =>
            {
                entity.HasOne(d => d.Encounter)
                    .WithMany(p => p.EncounterNote)
                    .HasForeignKey(d => d.EncounterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientNote_Encounter");
            });

            modelBuilder.Entity<Feeling>(entity =>
            {
                entity.Property(e => e.FeelingType).IsUnicode(false);

                entity.Property(e => e.Value).IsUnicode(false);

                entity.HasOne(d => d.EncounterNote)
                    .WithMany(p => p.Feeling)
                    .HasForeignKey(d => d.EncounterNoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feeling_PatientNote");
            });

            modelBuilder.Entity<HealthProfessional>(entity =>
            {
                entity.Property(e => e.Type).IsUnicode(false);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.BloodType).IsUnicode(false);
            });

            modelBuilder.Entity<ScheduledEvent>(entity =>
            {
                entity.HasOne(d => d.AssignedHealthProfessionalDNavigation)
                    .WithMany(p => p.ScheduledEvent)
                    .HasForeignKey(d => d.AssignedHealthProfessionalD)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScheduledEvent_HealthProfessional");

                entity.HasOne(d => d.Encounter)
                    .WithMany(p => p.ScheduledEvent)
                    .HasForeignKey(d => d.EncounterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScheduledEvent_Encounter");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasOne(d => d.Encounter)
                    .WithMany(p => p.UserInfo)
                    .HasForeignKey(d => d.EncounterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserInfo_Encounter");
            });
        }
    }
}
