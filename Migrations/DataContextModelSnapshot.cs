﻿// <auto-generated />
using System;
using Candidate_Recruiter.DataBase.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Candidate_Recruiter.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Candidate_Recruiter.Models.Candidato", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AspiracionSalarialMinima")
                        .HasColumnType("float");

                    b.Property<string>("Cedula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Candidato");

                    b.HasData(
                        new
                        {
                            Id = new Guid("50572eb9-c995-4268-b717-ceeffea6b925"),
                            AspiracionSalarialMinima = 2000.0,
                            Cedula = "123456789",
                            Correo = "maria.garcia@example.com",
                            Nombre = "María García"
                        },
                        new
                        {
                            Id = new Guid("55494aa6-96f7-4b0c-abba-b928c6d4e686"),
                            AspiracionSalarialMinima = 1800.0,
                            Cedula = "987654321",
                            Correo = "cfernandez@example.com",
                            Nombre = "Carlos Fernández"
                        },
                        new
                        {
                            Id = new Guid("ee18fb59-2db0-4ed6-a119-818659404120"),
                            AspiracionSalarialMinima = 2200.0,
                            Cedula = "456789123",
                            Correo = "anarod@example.com",
                            Nombre = "Ana Rodríguez"
                        },
                        new
                        {
                            Id = new Guid("00713a73-f14c-44c1-bb54-0df2e63c22b9"),
                            AspiracionSalarialMinima = 1900.0,
                            Cedula = "654321987",
                            Correo = "juan.lopez@example.com",
                            Nombre = "Juan López"
                        },
                        new
                        {
                            Id = new Guid("d6f7a138-1aeb-4750-bdff-700979a73fc9"),
                            AspiracionSalarialMinima = 2100.0,
                            Cedula = "789123456",
                            Correo = "laura.martinez@example.com",
                            Nombre = "Laura Martínez"
                        },
                        new
                        {
                            Id = new Guid("30bdd8f3-2892-42fa-9d2b-9fe93fa90b74"),
                            AspiracionSalarialMinima = 1950.0,
                            Cedula = "321654987",
                            Correo = "pdiaz@example.com",
                            Nombre = "Pedro Díaz"
                        },
                        new
                        {
                            Id = new Guid("67bb7d5e-71ca-487f-8260-9e1bdb77cf59"),
                            AspiracionSalarialMinima = 2050.0,
                            Cedula = "135792468",
                            Correo = "slo@example.com",
                            Nombre = "Sofía López"
                        },
                        new
                        {
                            Id = new Guid("4ec59a44-918e-4663-b3e4-e8a011269053"),
                            AspiracionSalarialMinima = 1980.0,
                            Cedula = "246813579",
                            Correo = "mgonzalez@example.com",
                            Nombre = "Miguel González"
                        },
                        new
                        {
                            Id = new Guid("d5ab1ccc-ad65-43db-904e-a79dc6129dc7"),
                            AspiracionSalarialMinima = 2250.0,
                            Cedula = "9876543210",
                            Correo = "elenas@example.com",
                            Nombre = "Elena Sánchez"
                        },
                        new
                        {
                            Id = new Guid("0599cbf7-5438-4682-9014-10737ed08c72"),
                            AspiracionSalarialMinima = 1800.0,
                            Cedula = "123098765",
                            Correo = "david.perez@example.com",
                            Nombre = "David Pérez"
                        });
                });

            modelBuilder.Entity("Candidate_Recruiter.Models.CandidatoPuesto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CandidatoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PuestoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CandidatoId");

                    b.HasIndex("PuestoId");

                    b.ToTable("CandidatoPuesto");
                });

            modelBuilder.Entity("Candidate_Recruiter.Models.Puesto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salario")
                        .HasColumnType("float");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Puesto");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d63d9bc8-2054-4687-8b9b-52c6c3e1440c"),
                            Codigo = "1",
                            Nombre = "Backend C# Developer",
                            Salario = 5000.0,
                            Status = "Vacante"
                        },
                        new
                        {
                            Id = new Guid("7ac80a41-85ca-4fbc-8dd4-a439f42e5ea5"),
                            Codigo = "2",
                            Nombre = "Frontend Developer",
                            Salario = 4800.0,
                            Status = "Vacante"
                        },
                        new
                        {
                            Id = new Guid("ec4bf0eb-91f0-4ab5-81ed-d05f6db21107"),
                            Codigo = "3",
                            Nombre = "Software Engineer",
                            Salario = 5500.0,
                            Status = "Vacante"
                        },
                        new
                        {
                            Id = new Guid("3d3997b1-49ea-491d-85b1-e1b4477d28f5"),
                            Codigo = "4",
                            Nombre = "Data Scientist",
                            Salario = 6000.0,
                            Status = "Vacante"
                        },
                        new
                        {
                            Id = new Guid("9862c24a-06ac-4767-a2f8-ce3f9f3890ec"),
                            Codigo = "5",
                            Nombre = "DevOps Engineer",
                            Salario = 5800.0,
                            Status = "Vacante"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Candidate_Recruiter.Models.CandidatoPuesto", b =>
                {
                    b.HasOne("Candidate_Recruiter.Models.Candidato", "Candidato")
                        .WithMany("CandidatoPuestos")
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Candidate_Recruiter.Models.Puesto", "Puesto")
                        .WithMany("CandidatoPuestos")
                        .HasForeignKey("PuestoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}