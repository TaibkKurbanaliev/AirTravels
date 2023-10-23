using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirTravels.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character(100)", fixedLength: true, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cities_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    company = table.Column<char>(type: "character(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("companies_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "document_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<string>(type: "character(50)", fixedLength: true, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("document_types_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    number = table.Column<string>(type: "character(20)", fixedLength: true, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Document_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "passangers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    second_name = table.Column<string>(type: "character(100)", fixedLength: true, maxLength: 100, nullable: false),
                    first_name = table.Column<string>(type: "character(100)", fixedLength: true, maxLength: 100, nullable: false),
                    third_name = table.Column<string>(type: "character(100)", fixedLength: true, maxLength: 100, nullable: true),
                    document = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Passanger_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    departure_point = table.Column<int>(type: "integer", nullable: false),
                    destination = table.Column<int>(type: "integer", nullable: false),
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    service_provider = table.Column<int>(type: "integer", nullable: false),
                    departure_date = table.Column<DateOnly>(type: "date", nullable: false),
                    arrival_date = table.Column<DateOnly>(type: "date", nullable: false),
                    service_registration_date = table.Column<DateOnly>(type: "date", nullable: false),
                    passanger = table.Column<int>(type: "integer", nullable: false),
                    is_completed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ticket_pkey", x => x.id);
                    table.ForeignKey(
                        name: "departure_point_fkey",
                        column: x => x.departure_point,
                        principalTable: "cities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "destination_fkey",
                        column: x => x.destination,
                        principalTable: "cities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "passanger_fkey",
                        column: x => x.passanger,
                        principalTable: "passangers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "service_provider_fkey",
                        column: x => x.service_provider,
                        principalTable: "companies",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tickets_departure_point",
                table: "tickets",
                column: "departure_point");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_destination",
                table: "tickets",
                column: "destination");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_passanger",
                table: "tickets",
                column: "passanger");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_service_provider",
                table: "tickets",
                column: "service_provider");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "document_types");

            migrationBuilder.DropTable(
                name: "documents");

            migrationBuilder.DropTable(
                name: "tickets");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "passangers");

            migrationBuilder.DropTable(
                name: "companies");
        }
    }
}
