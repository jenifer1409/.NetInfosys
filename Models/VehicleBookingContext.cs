using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace c_class3.Models;

public partial class VehicleBookingContext : DbContext
{
    public VehicleBookingContext()
    {
    }

    public VehicleBookingContext(DbContextOptions<VehicleBookingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Checkdbfirst> Checkdbfirsts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-PL0KJBQ;Initial Catalog=databasefirst;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Encrypt=True;Trust Server Certificate=True;Command Timeout=0");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Checkdbfirst>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__checkdbf__3213E83F3B5EE821");

            entity.ToTable("checkdbfirst");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Charges).HasColumnName("charges");
            entity.Property(e => e.Vehiclestatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("vehiclestatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
