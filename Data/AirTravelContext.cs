using System;
using System.Collections.Generic;
using AirTravels.Models;
using Microsoft.EntityFrameworkCore;

namespace AirTravels.Data;

public partial class AirTravelContext : DbContext
{
    public AirTravelContext()
    {
    }

    public AirTravelContext(DbContextOptions<AirTravelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<Passanger> Passangers { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AirTravel;Username=postgres;Password=1");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cities_pkey");

            entity.ToTable("cities");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("name");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("companies_pkey");

            entity.ToTable("companies");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Company1)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("company");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Document_pkey");

            entity.ToTable("documents");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id");
            entity.Property(e => e.Number)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("number");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Documents)
                .HasForeignKey(d => d.Type)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("documents_type_fkey");
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("document_types_pkey");

            entity.ToTable("document_types");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("type");
        });

        modelBuilder.Entity<Passanger>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Passanger_pkey");

            entity.ToTable("passangers");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id");
            entity.Property(e => e.Document).HasColumnName("document");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("first_name");
            entity.Property(e => e.SecondName)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("second_name");
            entity.Property(e => e.ThirdName)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("third_name");

            entity.HasOne(d => d.DocumentNavigation).WithMany(p => p.Passangers)
                .HasForeignKey(d => d.Document)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("passangers_document_fkey");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ticket_pkey");

            entity.ToTable("tickets");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id");
            entity.Property(e => e.ArrivalDate).HasColumnName("arrival_date");
            entity.Property(e => e.DepartureDate).HasColumnName("departure_date");
            entity.Property(e => e.DeparturePoint).HasColumnName("departure_point");
            entity.Property(e => e.Destination).HasColumnName("destination");
            entity.Property(e => e.IsCompleted).HasColumnName("is_completed");
            entity.Property(e => e.OrderNumber).HasColumnName("order_number");
            entity.Property(e => e.Passanger).HasColumnName("passanger");
            entity.Property(e => e.ServiceProvider).HasColumnName("service_provider");
            entity.Property(e => e.ServiceRegistrationDate).HasColumnName("service_registration_date");

            entity.HasOne(d => d.DeparturePointNavigation).WithMany(p => p.TicketDeparturePointNavigations)
                .HasForeignKey(d => d.DeparturePoint)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("departure_point_fkey");

            entity.HasOne(d => d.DestinationNavigation).WithMany(p => p.TicketDestinationNavigations)
                .HasForeignKey(d => d.Destination)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("destination_fkey");

            entity.HasOne(d => d.PassangerNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.Passanger)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("passanger_fkey");

            entity.HasOne(d => d.ServiceProviderNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ServiceProvider)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("service_provider_fkey");
        });
        modelBuilder.HasSequence("documents_id_seq");
        modelBuilder.HasSequence("passangers_id_seq");
        modelBuilder.HasSequence("tickets_id_seq");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
