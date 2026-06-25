using HospitalAppointmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointmentAPI.Data
{
    public class HospitalAppointmentDbContext : DbContext
    {
        public HospitalAppointmentDbContext(DbContextOptions<HospitalAppointmentDbContext> options)
            : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; } = null!;
        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Appointment> Appointments { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.DoctorId);
                entity.Property(e => e.DoctorName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Specialization).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
                entity.Property(e => e.City).HasMaxLength(100);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.PatientId);
                entity.Property(e => e.PatientName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
                entity.Property(e => e.City).HasMaxLength(100);
                entity.Property(e => e.Gender).HasMaxLength(20);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.AppointmentId);
                entity.Property(e => e.AppointmentStatus).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Symptoms).HasMaxLength(500);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");

                entity.HasOne(e => e.Doctor)
                    .WithMany(d => d.Appointments)
                    .HasForeignKey(e => e.DoctorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(e => e.PatientId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.UserName).IsRequired().HasMaxLength(50);
                entity.HasIndex(e => e.UserName).IsUnique();
                entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId);
                entity.Property(e => e.RoleName).IsRequired().HasMaxLength(50);
                entity.HasIndex(e => e.RoleName).IsUnique();
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.UserRoleId);
                entity.HasOne(e => e.User)
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(e => e.RoleId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
