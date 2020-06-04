using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    IdDoctor = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Doctor_PK", x => x.IdDoctor);
                });

            migrationBuilder.CreateTable(
                name: "Medicament",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Medicament_PK", x => x.IdMedicament);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    IdPatient = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Patient_PK", x => x.IdPatient);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    IdPrescription = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    IdPatient = table.Column<int>(nullable: false),
                    IdDoctor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Prescritpion_PK", x => x.IdPrescription);
                    table.ForeignKey(
                        name: "Prescription_Doctor",
                        column: x => x.IdDoctor,
                        principalTable: "Doctor",
                        principalColumn: "IdDoctor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Prescription_Patient",
                        column: x => x.IdPatient,
                        principalTable: "Patient",
                        principalColumn: "IdPatient",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prescription_Medicament",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(nullable: false),
                    IdPrescription = table.Column<int>(nullable: false),
                    Dose = table.Column<int>(nullable: false),
                    Details = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Prescription_Medicament_PK", x => new { x.IdMedicament, x.IdPrescription });
                    table.ForeignKey(
                        name: "Prescription_Medicament_Medicament",
                        column: x => x.IdMedicament,
                        principalTable: "Medicament",
                        principalColumn: "IdMedicament",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Prescription_Medicament_Prescription",
                        column: x => x.IdPrescription,
                        principalTable: "Prescription",
                        principalColumn: "IdPrescription",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "T.Rydzyk@gmail.com", "Tadeusz", "Rydzyk" },
                    { 2, "M.Oktaba@gmail.com", "Mariusz", "Oktaba" },
                    { 3, "G.Lomacz@gmail.com", "Grzegorz", "Łomacz" }
                });

            migrationBuilder.InsertData(
                table: "Medicament",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 10, "Na katar", "Hyrosalic", "Tabletki" },
                    { 20, "Przeciwbólowy", "Tomysol", "Tabletki" },
                    { 30, "Przeciwzapalny", "Mamarys", "Tabletki" },
                    { 40, "Na kaszel", "Kaselic", "Syrop" },
                    { 50, "Antybiotyk", "Parytol", "Tabletki" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 0, new DateTime(2012, 9, 3, 0, 0, 0, 0, DateTimeKind.Local), "Jan", "Kowalski" },
                    { 1, new DateTime(2000, 3, 1, 0, 0, 0, 0, DateTimeKind.Local), "Rafał", "Smoczyński" },
                    { 2, new DateTime(2002, 8, 21, 0, 0, 0, 0, DateTimeKind.Local), "Piotr", "Krótki" },
                    { 3, new DateTime(2004, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), "Mateusz", "Szybki" },
                    { 4, new DateTime(1999, 2, 3, 0, 0, 0, 0, DateTimeKind.Local), "Robert", "Wolny" },
                    { 5, new DateTime(1997, 6, 23, 0, 0, 0, 0, DateTimeKind.Local), "Gosia", "Miałczyńska" }
                });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[,]
                {
                    { 331, new DateTime(2020, 6, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 6, 23, 0, 0, 0, 0, DateTimeKind.Local), 3, 1 },
                    { 332, new DateTime(2020, 6, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 6, 23, 0, 0, 0, 0, DateTimeKind.Local), 2, 2 },
                    { 333, new DateTime(2020, 6, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 6, 24, 0, 0, 0, 0, DateTimeKind.Local), 2, 3 },
                    { 334, new DateTime(2020, 6, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Local), 3, 4 },
                    { 335, new DateTime(2020, 6, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 6, 26, 0, 0, 0, 0, DateTimeKind.Local), 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[,]
                {
                    { 50, 331, "Tylko gdy boli", 1 },
                    { 40, 332, "Na czczo", 100 },
                    { 30, 333, "Tylko rano", 5 },
                    { 20, 334, "Tylko wieczorem", 18 },
                    { 10, 335, "Rano i wieczorem", 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_IdDoctor",
                table: "Prescription",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_IdPatient",
                table: "Prescription",
                column: "IdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicament_IdPrescription",
                table: "Prescription_Medicament",
                column: "IdPrescription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescription_Medicament");

            migrationBuilder.DropTable(
                name: "Medicament");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
