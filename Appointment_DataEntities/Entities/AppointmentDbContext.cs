using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Appointment_DataEntities.Entities;

public partial class AppointmentDbContext : DbContext
{
    public AppointmentDbContext()
    {
    }

    public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<PatientIntialCheckup> PatientIntialCheckups { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:appointmentserver.database.windows.net,1433;Initial Catalog=AppointmentDb;Persist Security Info=False;User ID=appointments;Password=Password@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__FD01B52323565561");

            entity.Property(e => e.AppointmentId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Appointment_Id");
            entity.Property(e => e.CheckupStatus)
                .HasDefaultValueSql("((0))")
                .HasColumnName("Checkup_Status");
            entity.Property(e => e.Concerns).IsUnicode(false);
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.DoctorId).HasColumnName("Doctor_Id");
            entity.Property(e => e.DoctorName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Doctor_name");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PatientIntialCheckup>(entity =>
        {
            entity.HasKey(e => e.PicId).HasName("PK__Patient___5A0224FFDD5A358E");

            entity.ToTable("Patient_Intial_Checkup");

            entity.Property(e => e.PicId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("pic_Id");
            entity.Property(e => e.AdditionalDetails).IsUnicode(false);
            entity.Property(e => e.AppointmentId).HasColumnName("Appointment_Id");
            entity.Property(e => e.BloodPressure)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Blood_Pressure");
            entity.Property(e => e.SugarLevel).HasColumnName("Sugar_level");

            entity.HasOne(d => d.Appointment).WithMany(p => p.PatientIntialCheckups)
                .HasForeignKey(d => d.AppointmentId)
                .HasConstraintName("FK__Patient_I__Appoi__619B8048");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
