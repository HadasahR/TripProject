using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class TripsProjectContext : DbContext,IContext
{
    public TripsProjectContext()
    {
    }

    public TripsProjectContext(DbContextOptions<TripsProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<OrderTicket> OrderTickets { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-E0FAPSB\\SQLEXPRESS;Initial Catalog=TripsProject; Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustId).HasName("PK__customer__9725F2C66A79AC45");

            entity.ToTable("customers");

            entity.Property(e => e.CustId).HasColumnName("custId");
            entity.Property(e => e.CustEmail)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("custEmail");
            entity.Property(e => e.CustFname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("custFName");
            entity.Property(e => e.CustLname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("custLName");
            entity.Property(e => e.CustPassword)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("custPassword");
            entity.Property(e => e.CustPhone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("custPhone");
            entity.Property(e => e.FirstAid).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<OrderTicket>(entity =>
        {
            entity.HasKey(e => e.OrdId).HasName("PK__orderTic__215DC1B8DF55F29A");

            entity.ToTable("orderTickets");

            entity.Property(e => e.OrdId).HasColumnName("ordId");
            entity.Property(e => e.CountPlaces).HasColumnName("countPlaces");
            entity.Property(e => e.CustId).HasColumnName("custId");
            entity.Property(e => e.OrdDate)
                .HasColumnType("date")
                .HasColumnName("ordDate");
            entity.Property(e => e.OrdTime).HasColumnName("ordTime");
            entity.Property(e => e.TripId).HasColumnName("tripId");

            entity.HasOne(d => d.Cust).WithMany(p => p.OrderTickets)
                .HasForeignKey(d => d.CustId)
                .HasConstraintName("FK__orderTick__custI__2C3393D0");

            entity.HasOne(d => d.Trip).WithMany(p => p.OrderTickets)
                .HasForeignKey(d => d.TripId)
                .HasConstraintName("FK__orderTick__tripI__2D27B809");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.TripId).HasName("PK__Trips__303EBF85E7A9E4E4");

            entity.Property(e => e.TripId).HasColumnName("tripId");
            entity.Property(e => e.CustId).HasColumnName("custId");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Destination)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("destination");
            entity.Property(e => e.EmptyPlaces).HasColumnName("emptyPlaces");
            entity.Property(e => e.HowLong).HasColumnName("howLong");
            entity.Property(e => e.Img)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("img");
            entity.Property(e => e.LeavingHour).HasColumnName("leavingHour");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.TypeId).HasColumnName("typeId");

            entity.HasOne(d => d.Type).WithMany(p => p.Trips)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK__Trips__typeId__29572725");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__types__F04DF13AE7BF52C8");

            entity.ToTable("types");

            entity.Property(e => e.TypeId).HasColumnName("typeId");
            entity.Property(e => e.TypeName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("typeName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
