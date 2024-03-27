using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Threading.Tasks;
using System;
using Candidate_Recruiter.Models;
using System.Collections.Generic;

namespace Candidate_Recruiter.DataBase.Context
{
    public class DataContext : IdentityDbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<TEntity> SetEntity<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public EntityEntry<TEntity> AddEntity<TEntity>(TEntity entity) where TEntity : class
        {
            return base.Add(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public void OpenDatabaseConnection()
        {
            this.Database.OpenConnection();
        }

        public void CloseDatabaseConnection()
        {
            this.Database.CloseConnection();
            var connection = this.Database.GetDbConnection();
            connection.Dispose();
        }

        public IDbContextTransaction StartTransaction(string nameSavepoint)
        {
            var transaction = this.Database.BeginTransaction();
            return transaction;
        }

        public void AddRangeEntity(params object[] entities)
        {
            base.AddRange(entities);
        }

        public EntityEntry<TEntity> UpdateEntity<TEntity>(TEntity entity) where TEntity : class
        {
            return base.Update(entity);
        }

        public EntityEntry<TEntity> RemoveEntity<TEntity>(TEntity entity) where TEntity : class
        {
            return base.Remove(entity);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Ignore<IdentityUserRole<string>>();
            modelBuilder.Ignore<IdentityUserClaim<string>>();
            modelBuilder.Ignore<IdentityUserToken<string>>();
            modelBuilder.Ignore<IdentityUser<string>>();
            var puestos = new List<Puesto>
            {
                new Puesto() { Id = Guid.NewGuid(),Nombre = "Backend C# Developer", Codigo = "1", Salario = 5000, Status = "Vacante" },
                new Puesto() { Id = Guid.NewGuid(),Nombre = "Frontend Developer", Codigo = "2", Salario = 4800, Status = "Vacante" },
                new Puesto() { Id = Guid.NewGuid(),Nombre = "Software Engineer", Codigo = "3", Salario = 5500, Status = "Vacante" },
                new Puesto() { Id = Guid.NewGuid(),Nombre = "Data Scientist", Codigo = "4", Salario = 6000, Status = "Vacante" },
                new Puesto() { Id = Guid.NewGuid(),Nombre = "DevOps Engineer", Codigo = "5", Salario = 5800, Status = "Vacante" }
            };
            var candidatos = new List<Candidato>
            {
                new Candidato
                {
                    Id = Guid.NewGuid(),
                    Cedula = "123456789",
                    Nombre = "María García",
                    Correo = "maria.garcia@example.com",
                    AspiracionSalarialMinima = 2000
                },
                new Candidato
                {
                    Id = Guid.NewGuid(),
                    Cedula = "987654321",
                    Nombre = "Carlos Fernández",
                    Correo = "cfernandez@example.com",
                    AspiracionSalarialMinima = 1800
                },
                new Candidato
                {Id = Guid.NewGuid(),
                    Cedula = "456789123",
                    Nombre = "Ana Rodríguez",
                    Correo = "anarod@example.com",
                    AspiracionSalarialMinima = 2200
                },
                new Candidato
                {Id = Guid.NewGuid(),
                    Cedula = "654321987",
                    Nombre = "Juan López",
                    Correo = "juan.lopez@example.com",
                    AspiracionSalarialMinima = 1900
                },
                new Candidato
                {Id = Guid.NewGuid(),
                    Cedula = "789123456",
                    Nombre = "Laura Martínez",
                    Correo = "laura.martinez@example.com",
                    AspiracionSalarialMinima = 2100
                },
                new Candidato
                {Id = Guid.NewGuid(),
                    Cedula = "321654987",
                    Nombre = "Pedro Díaz",
                    Correo = "pdiaz@example.com",
                    AspiracionSalarialMinima = 1950
                },
                new Candidato
                {Id = Guid.NewGuid(),
                    Cedula = "135792468",
                    Nombre = "Sofía López",
                    Correo = "slo@example.com",
                    AspiracionSalarialMinima = 2050
                },
                new Candidato
                {Id = Guid.NewGuid(),
                    Cedula = "246813579",
                    Nombre = "Miguel González",
                    Correo = "mgonzalez@example.com",
                    AspiracionSalarialMinima = 1980
                },
                new Candidato
                {Id = Guid.NewGuid(),
                    Cedula = "9876543210",
                    Nombre = "Elena Sánchez",
                    Correo = "elenas@example.com",
                    AspiracionSalarialMinima = 2250
                },
                new Candidato
                {Id = Guid.NewGuid(),
                    Cedula = "123098765",
                    Nombre = "David Pérez",
                    Correo = "david.perez@example.com",
                    AspiracionSalarialMinima = 1800
                }
            };
            modelBuilder.Entity<Puesto>(model =>
            {
                model.HasKey(x => x.Id);
                model.Property(x => x.Nombre);
                model.Property(x => x.Codigo);
                model.Property(x => x.Salario);
                model.Property(x => x.Status);
                model.HasData(puestos);
            });

            modelBuilder.Entity<Candidato>(model =>
            {
                model.HasKey(x => x.Id);
                model.Property(x => x.Cedula);
                model.Property(x => x.Nombre);
                model.Property(x => x.Correo);
                model.Property(x => x.AspiracionSalarialMinima);
                model.HasData(candidatos);
            });

            modelBuilder.Entity<CandidatoPuesto>(model =>
            {
                model.HasKey(x => x.Id);
                model.HasOne(x => x.Puesto).WithMany(x => x.CandidatoPuestos).HasForeignKey(x=> x.PuestoId);
                model.HasOne(x => x.Candidato).WithMany(x => x.CandidatoPuestos).HasForeignKey(x=> x.CandidatoId);
            });
        }
    }
}
