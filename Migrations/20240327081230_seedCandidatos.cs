using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Candidate_Recruiter.Migrations
{
    public partial class seedCandidatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "Id",
                keyValue: new Guid("4ba4ac7c-2d0c-434f-b4c8-ce0ca7bf6c86"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "Id",
                keyValue: new Guid("627448e9-96e6-435f-8b34-40f69f5b86c8"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "Id",
                keyValue: new Guid("7c76f91e-2f3d-4d23-8a29-743f27dec599"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "Id",
                keyValue: new Guid("d61932a3-487f-4b06-88e5-56e6cfced782"));

            migrationBuilder.DeleteData(
                table: "Puesto",
                keyColumn: "Id",
                keyValue: new Guid("fa471d27-0f75-4aeb-8656-527e03084b72"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Puesto",
                columns: new[] { "Id", "Codigo", "Nombre", "Salario", "Status" },
                values: new object[,]
                {
                    { new Guid("fa471d27-0f75-4aeb-8656-527e03084b72"), "1", "Backend C# Developer", 5000.0, "Vacante" },
                    { new Guid("7c76f91e-2f3d-4d23-8a29-743f27dec599"), "2", "Frontend Developer", 4800.0, "Vacante" },
                    { new Guid("d61932a3-487f-4b06-88e5-56e6cfced782"), "3", "Software Engineer", 5500.0, "Vacante" },
                    { new Guid("627448e9-96e6-435f-8b34-40f69f5b86c8"), "4", "Data Scientist", 6000.0, "Vacante" },
                    { new Guid("4ba4ac7c-2d0c-434f-b4c8-ce0ca7bf6c86"), "5", "DevOps Engineer", 5800.0, "Vacante" }
                });
        }
    }
}
