using System;

namespace Candidate_Recruiter.Models
{
    public class CandidatoPuesto
    {
        public Guid Id { get; set; }
        public Guid PuestoId { get; set; }
        public Guid CandidatoId { get; set; }
        public Puesto Puesto { get; set; }
        public Candidato Candidato { get; set; }
    }
}
