using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Organization3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "contacts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Regon = table.Column<string>(type: "TEXT", nullable: false),
                    Nip = table.Column<string>(type: "TEXT", nullable: false),
                    Adress_City = table.Column<string>(type: "TEXT", nullable: true),
                    Adress_Street = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Adress_City", "Adress_Street", "Name", "Nip", "Regon" },
                values: new object[,]
                {
                    { 1, "Kraków", "Św. Filipa 17", "WSEI", "123456", "321321321" },
                    { 2, "Warszawa", "Wesoła 15", "Famo", "432432", "123123123" }
                });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "OrganizationId" },
                values: new object[] { new DateTime(2024, 11, 12, 12, 20, 50, 635, DateTimeKind.Local).AddTicks(2523), 1 });

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "Id", "Category", "Created", "DateOfBirth", "Email", "FirstName", "LastName", "OrganizationId", "Phone" },
                values: new object[] { 2, 0, new DateTime(2024, 11, 12, 12, 20, 50, 635, DateTimeKind.Local).AddTicks(2575), new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ola@wsei.edu.pl", "Ola", "Nowak", 2, "123123123" });

            migrationBuilder.CreateIndex(
                name: "IX_contacts_OrganizationId",
                table: "contacts",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_Organizations_OrganizationId",
                table: "contacts",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_Organizations_OrganizationId",
                table: "contacts");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_contacts_OrganizationId",
                table: "contacts");

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "contacts");

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 10, 22, 45, 41, 638, DateTimeKind.Local).AddTicks(8721));
        }
    }
}
