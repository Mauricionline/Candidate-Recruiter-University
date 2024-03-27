using Candidate_Recruiter.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidate_Recruiter.DataBase.Repositories.Interfaces
{
    public interface ICandidatoPuestoRepository : IRepository<CandidatoPuesto>
    {
        Task<List<Candidato>> CandidatosPorPuesto(Guid puestoId);
        Task<List<Puesto>> PuestosPorCandidato(Guid candidatoId);
        Task<List<Puesto>> PuestosNoSuscritosPorCandidato(Guid candidatoId);
        Task<CandidatoPuesto> AddSubscripcion(CandidatoPuesto candidatoPuesto);
        Task<CandidatoPuesto> RemoveSubscripcion(Guid Id);
    }
}
