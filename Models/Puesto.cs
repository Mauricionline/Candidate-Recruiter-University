using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidate_Recruiter.Models
{
    public class Puesto
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public double Salario { get; set; }
        public string Status { get; set; }

        public List<CandidatoPuesto> CandidatoPuestos { get; set; }
    }
}
