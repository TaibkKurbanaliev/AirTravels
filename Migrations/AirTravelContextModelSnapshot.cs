﻿// <auto-generated />
using System;
using AirTravels.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AirTravels.Migrations
{
    [DbContext(typeof(AirTravelContext))]
    partial class AirTravelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AirTravels.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character(100)")
                        .HasColumnName("name")
                        .IsFixedLength();

                    b.HasKey("Id")
                        .HasName("cities_pkey");

                    b.ToTable("cities", (string)null);
                });

            modelBuilder.Entity("AirTravels.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<char>("Company1")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)")
                        .HasColumnName("company");

                    b.HasKey("Id")
                        .HasName("companies_pkey");

                    b.ToTable("companies", (string)null);
                });

            modelBuilder.Entity("AirTravels.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character(20)")
                        .HasColumnName("number")
                        .IsFixedLength();

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("Document_pkey");

                    b.ToTable("documents", (string)null);
                });

            modelBuilder.Entity("AirTravels.Models.DocumentType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character(50)")
                        .HasColumnName("type")
                        .IsFixedLength();

                    b.HasKey("Id")
                        .HasName("document_types_pkey");

                    b.ToTable("document_types", (string)null);
                });

            modelBuilder.Entity("AirTravels.Models.Passanger", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<int>("Document")
                        .HasColumnType("integer")
                        .HasColumnName("document");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character(100)")
                        .HasColumnName("first_name")
                        .IsFixedLength();

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character(100)")
                        .HasColumnName("second_name")
                        .IsFixedLength();

                    b.Property<string>("ThirdName")
                        .HasMaxLength(100)
                        .HasColumnType("character(100)")
                        .HasColumnName("third_name")
                        .IsFixedLength();

                    b.HasKey("Id")
                        .HasName("Passanger_pkey");

                    b.ToTable("passangers", (string)null);
                });

            modelBuilder.Entity("AirTravels.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<DateOnly>("ArrivalDate")
                        .HasColumnType("date")
                        .HasColumnName("arrival_date");

                    b.Property<DateOnly>("DepartureDate")
                        .HasColumnType("date")
                        .HasColumnName("departure_date");

                    b.Property<int>("DeparturePoint")
                        .HasColumnType("integer")
                        .HasColumnName("departure_point");

                    b.Property<int>("Destination")
                        .HasColumnType("integer")
                        .HasColumnName("destination");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_completed");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("integer")
                        .HasColumnName("order_number");

                    b.Property<int>("Passanger")
                        .HasColumnType("integer")
                        .HasColumnName("passanger");

                    b.Property<int>("ServiceProvider")
                        .HasColumnType("integer")
                        .HasColumnName("service_provider");

                    b.Property<DateOnly>("ServiceRegistrationDate")
                        .HasColumnType("date")
                        .HasColumnName("service_registration_date");

                    b.HasKey("Id")
                        .HasName("ticket_pkey");

                    b.HasIndex("DeparturePoint");

                    b.HasIndex("Destination");

                    b.HasIndex("Passanger");

                    b.HasIndex("ServiceProvider");

                    b.ToTable("tickets", (string)null);
                });

            modelBuilder.Entity("AirTravels.Models.Ticket", b =>
                {
                    b.HasOne("AirTravels.Models.City", "DeparturePointNavigation")
                        .WithMany("TicketDeparturePointNavigations")
                        .HasForeignKey("DeparturePoint")
                        .IsRequired()
                        .HasConstraintName("departure_point_fkey");

                    b.HasOne("AirTravels.Models.City", "DestinationNavigation")
                        .WithMany("TicketDestinationNavigations")
                        .HasForeignKey("Destination")
                        .IsRequired()
                        .HasConstraintName("destination_fkey");

                    b.HasOne("AirTravels.Models.Passanger", "PassangerNavigation")
                        .WithMany("Tickets")
                        .HasForeignKey("Passanger")
                        .IsRequired()
                        .HasConstraintName("passanger_fkey");

                    b.HasOne("AirTravels.Models.Company", "ServiceProviderNavigation")
                        .WithMany("Tickets")
                        .HasForeignKey("ServiceProvider")
                        .IsRequired()
                        .HasConstraintName("service_provider_fkey");

                    b.Navigation("DeparturePointNavigation");

                    b.Navigation("DestinationNavigation");

                    b.Navigation("PassangerNavigation");

                    b.Navigation("ServiceProviderNavigation");
                });

            modelBuilder.Entity("AirTravels.Models.City", b =>
                {
                    b.Navigation("TicketDeparturePointNavigations");

                    b.Navigation("TicketDestinationNavigations");
                });

            modelBuilder.Entity("AirTravels.Models.Company", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("AirTravels.Models.Passanger", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
