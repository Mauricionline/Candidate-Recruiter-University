using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Candidate_Recruiter.Migrations
{
    public partial class AddCandidatoPuesto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Candidato",
                keyColumn: "Id",
                keyValue: new Guid("07b4b871-36a1-4074-ab92-dac946cce88f"));

            migrationBuilder.DeleteData(
                table: "Candidato",
                keyColumn: "Id",
                keyValue: new Guid("0e6c1fac-8a16-4a66-b73a-cec784f960bd"));

            migrationBuilder.DeleteData(
                table: "Candidato",
                keyColumn: "Id",
                keyValue: new Guid("2300da76-fab5-4e09-9340-010c72290a6c"));

            migrationBuilder.DeleteData(
                table: "Candidato",
                keyColumn: "Id",
                keyValue: new Guid("3781e0ea-f9ab-47a4-892d-29ca9bb14703"));

            migrationBuilder.DeleteData(
                table: "Candidato",
                keyColumn: "Id",
                keyValue: new Guid("3d82ea8a-514e-4211-9b84-deb39b856a99"));

            migrationBuilder.DeleteData(
                table: "Candidato",
                keyColumn: "Id",
                keyValue: new Guid("54a618cc-a19e-47a4-b6b2-19015df3a962"));

            migrationBuilder.DeleteData(
                table: "Candidato",
                keyColumn: "Id",
                keyValue: new Guid("5b00714a-3d47-4ebf-8e38-dce3980ce884"));

            migrationBuilder.DeleteData(
                table: "Candidato",
                keyColumn: "Id",
                keyValue: new Guid("5ca974cd-b13e-4be3-a1f0-e95fb0bf564a"));

            migrationBuilder.DeleteData(
                table: "Candidato",
                keyColumn: "Id",
                keyValue: new Guid("7cb1e326-4a81-41ea-8e09-ba0b68debc55"));

            migrationBuilder.DeleteData(
                table: "Candidato",
                keyColumn: "Id",
                keyValue: new Guid("ee72df04-e42d-49cd-b787-35a081798a7e"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "Id",
                keyValue: new Guid("3515bbf1-fd21-4320-a2a4-eebaafe46b4e"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "Id",
                keyValue: new Guid("7eb34709-f623-425e-ad5a-6c92149b7f91"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "Id",
                keyValue: new Guid("86c88cc5-1971-43b6-ad01-b0c21dbbeae2"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "Id",
                keyValue: new Guid("b706c933-ee44-4d00-af7c-b74349ecb791"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "Id",
                keyValue: new Guid("f38425cc-8499-4e75-8e8f-03519ef063f2"));

            migrationBuilder.CreateTable(
                name: "CandidatoPuesto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PuestoId = table.Column<Guid>(nullable: false),
                    CandidatoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatoPuesto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidatoPuesto_Candidato_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatoPuesto_Puesto_PuestoId",
                        column: x => x.PuestoId,
                        principalTable: "Puesto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Candidato",
                columns: new[] { "Id", "AspiracionSalarialMinima", "Cedula", "Correo", "Nombre" },
                values: new object[,]
                {
                    { new Guid("50572eb9-c995-4268-b717-ceeffea6b925"), 2000.0, "123456789", "maria.garcia@example.com", "María García" },
                    { new Guid("55494aa6-96f7-4b0c-abba-b928c6d4e686"), 1800.0, "987654321", "cfernandez@example.com", "Carlos Fernández" },
                    { new Guid("ee18fb59-2db0-4ed6-a119-818659404120"), 2200.0, "456789123", "anarod@example.com", "Ana Rodríguez" },
                    { new Guid("00713a73-f14c-44c1-bb54-0df2e63c22b9"), 1900.0, "654321987", "juan.lopez@example.com", "Juan López" },
                    { new Guid("d6f7a138-1aeb-4750-bdff-700979a73fc9"), 2100.0, "789123456", "laura.martinez@example.com", "Laura Martínez" },
                    { new Guid("30bdd8f3-2892-42fa-9d2b-9fe93fa90b74"), 1950.0, "321654987", "pdiaz@example.com", "Pedro Díaz" },
                    { new Guid("67bb7d5e-71ca-487f-8260-9e1bdb77cf59"), 2050.0, "135792468", "slo@example.com", "Sofía López" },
                    { new Guid("4ec59a44-918e-4663-b3e4-e8a011269053"), 1980.0, "246813579", "mgonzalez@example.com", "Miguel González" },
                    { new Guid("d5ab1ccc-ad65-43db-904e-a79dc6129dc7"), 2250.0, "9876543210", "elenas@example.com", "Elena Sánchez" },
                    { new Guid("0599cbf7-5438-4682-9014-10737ed08c72"), 1800.0, "123098765", "david.perez@example.com", "David Pérez" }
                });

            migrationBuilder.InsertData(
                table: "Puesto",
                columns: new[] { "Id", "Codigo", "Nombre", "Salario", "Status" },
                values: new object[,]
                {
                    { new Guid("d63d9bc8-2054-4687-8b9b-52c6c3e1440c"), "1", "Backend C# Developer", 5000.0, "Vacante" },
                    { new Guid("7ac80a41-85ca-4fbc-8dd4-a439f42e5ea5"), "2", "Frontend Developer", 4800.0, "Vacante" },
                    { new Guid("ec4bf0eb-91f0-4ab5-81ed-d05f6db21107"), "3", "Software Engineer", 5500.0, "Vacante" },
                    { new Guid("3d3997b1-49ea-491d-85b1-e1b4477d28f5"), "4", "Data Scientist", 6000.0, "Vacante" },
                    { new Guid("9862c24a-06ac-4767-a2f8-ce3f9f3890ec"), "5", "DevOps Engineer", 5800.0, "Vacante" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidatoPuesto_CandidatoId",
                table: "CandidatoPuesto",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatoPuesto_PuestoId",
                table: "CandidatoPuesto",
                column: "PuestoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatoPuesto");

            migrationBuilder.DeleteData(
                table: "Candidato",
                keyColumn: "Id",
                keyValue: new Guid("00713a73-f14c-44c1-bb54-0df2e63c22b9"));

            migrationBuilder.DeleteData(
                table: "Candidato",
                keyColumn: "Id",
                keyValue: new Guid("0599cbf7-5438-4682-9014-10737ed08c72"));

            migrationBuilder.DeleteData(
                table: "Candidato",
                keyColumn: "Id",
                keyValue: new Guid("30bdd8f3-2892-42fa-9d2b-9fe93fa90b74"));

            migrationBuilder.DeleteData(
                table: "Candidato",
                keyColumn: "Id",
                keyValue: new Guid("4ec59a44-918e-4663-b3e4-e8a011269053"));

            migrationBuilder.DeleteData(
                table: "Candidato",
                keyColumn: "Id",
                keyValue: new Guid("50572eb9-c995-4268-b717-ceeffea6b925"));

            migrationBuilder.DeleteData(
                table: "Candidato",
                keyColumn: "Id",
                keyValue: new Guid("55494aa6-96f7-4b0c-abba-b928c6d4e686"));

            migrationBuilder.DeleteData(
                table: "Candidato",
                keyColumn: "Id",
                keyValue: new Guid("67bb7d5e-71ca-487f-8260-9e1bdb77cf59"));

            migrationBuilder.DeleteData(
                table: "Candidato",
                keyColumn: "Id",
                keyValue: new Guid("d5ab1ccc-ad65-43db-904e-a79dc6129dc7"));

            migrationBuilder.DeleteData(
                table: "Candidato",
                keyColumn: "Id",
                keyValue: new Guid("d6f7a138-1aeb-4750-bdff-700979a73fc9"));

            migrationBuilder.DeleteData(
                table: "Candidato",
                keyColumn: "Id",
                keyValue: new Guid("ee18fb59-2db0-4ed6-a119-818659404120"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "Id",
                keyValue: new Guid("3d3997b1-49ea-491d-85b1-e1b4477d28f5"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "Id",
                keyValue: new Guid("7ac80a41-85ca-4fbc-8dd4-a439f42e5ea5"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "Id",
                keyValue: new Guid("9862c24a-06ac-4767-a2f8-ce3f9f3890ec"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "Id",
                keyValue: new Guid("d63d9bc8-2054-4687-8b9b-52c6c3e1440c"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "Id",
                keyValue: new Guid("ec4bf0eb-91f0-4ab5-81ed-d05f6db21107"));

            migrationBuilder.InsertData(
                table: "Candidato",
                columns: new[] { "Id", "AspiracionSalarialMinima", "Cedula", "Correo", "Nombre" },
                values: new object[,]
                {
                    { new Guid("54a618cc-a19e-47a4-b6b2-19015df3a962"), 2000.0, "123456789", "maria.garcia@example.com", "María García" },
                    { new Guid("5ca974cd-b13e-4be3-a1f0-e95fb0bf564a"), 1800.0, "987654321", "cfernandez@example.com", "Carlos Fernández" },
                    { new Guid("5b00714a-3d47-4ebf-8e38-dce3980ce884"), 2200.0, "456789123", "anarod@example.com", "Ana Rodríguez" },
                    { new Guid("ee72df04-e42d-49cd-b787-35a081798a7e"), 1900.0, "654321987", "juan.lopez@example.com", "Juan López" },
                    { new Guid("3781e0ea-f9ab-47a4-892d-29ca9bb14703"), 2100.0, "789123456", "laura.martinez@example.com", "Laura Martínez" },
                    { new Guid("7cb1e326-4a81-41ea-8e09-ba0b68debc55"), 1950.0, "321654987", "pdiaz@example.com", "Pedro Díaz" },
                    { new Guid("0e6c1fac-8a16-4a66-b73a-cec784f960bd"), 2050.0, "135792468", "slo@example.com", "Sofía López" },
                    { new Guid("3d82ea8a-514e-4211-9b84-deb39b856a99"), 1980.0, "246813579", "mgonzalez@example.com", "Miguel González" },
                    { new Guid("2300da76-fab5-4e09-9340-010c72290a6c"), 2250.0, "9876543210", "elenas@example.com", "Elena Sánchez" },
                    { new Guid("07b4b871-36a1-4074-ab92-dac946cce88f"), 1800.0, "123098765", "david.perez@example.com", "David Pérez" }
                });

            migrationBuilder.InsertData(
                table: "Puesto",
                columns: new[] { "Id", "Codigo", "Nombre", "Salario", "Status" },
                values: new object[,]
                {
                    { new Guid("f38425cc-8499-4e75-8e8f-03519ef063f2"), "1", "Backend C# Developer", 5000.0, "Vacante" },
                    { new Guid("86c88cc5-1971-43b6-ad01-b0c21dbbeae2"), "2", "Frontend Developer", 4800.0, "Vacante" },
                    { new Guid("b706c933-ee44-4d00-af7c-b74349ecb791"), "3", "Software Engineer", 5500.0, "Vacante" },
                    { new Guid("7eb34709-f623-425e-ad5a-6c92149b7f91"), "4", "Data Scientist", 6000.0, "Vacante" },
                    { new Guid("3515bbf1-fd21-4320-a2a4-eebaafe46b4e"), "5", "DevOps Engineer", 5800.0, "Vacante" }
                });
        }
    }
}
