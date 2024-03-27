using Candidate_Recruiter.DataBase.Context;
using Candidate_Recruiter.DataBase.Repositories.Interfaces;
using Candidate_Recruiter.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidate_Recruiter.DataBase.Repositories
{
    public class CandidatoPuestoRepository : Repository<CandidatoPuesto>, ICandidatoPuestoRepository
    {
        public CandidatoPuestoRepository(IDataContext affiliationContext) : base(affiliationContext)
        {
        }

        public async Task<CandidatoPuesto> AddSubscripcion(CandidatoPuesto candidatoPuesto)
        {
            return await Add(candidatoPuesto);
        }

        public async Task<CandidatoPuesto> RemoveSubscripcion(Guid Id)
        {
            var found = await GetByID(Id);
            return await Remove(found);
        }

        public async Task<List<Candidato>> CandidatosPorPuesto(Guid puestoId)
        {
            return await GetAll().Include(cp => cp.Candidato)
            .Where(cp => cp.PuestoId == puestoId)
            .Select(cp => cp.Candidato)
            .ToListAsync();
        }

        public async Task<List<Puesto>> PuestosPorCandidato(Guid candidatoId)
        {
            return await affiliationContext.SetEntity<Puesto>()
                .Where(p => p.CandidatoPuestos.Any(cp => cp.CandidatoId == candidatoId))
                .ToListAsync();
        }

        public async Task<List<Puesto>> PuestosNoSuscritosPorCandidato(Guid candidatoId)
        {
            return await affiliationContext.SetEntity<Puesto>()
                .Where(p => !p.CandidatoPuestos.Any(cp => cp.CandidatoId == candidatoId))
                .ToListAsync();
        }
    }
}
