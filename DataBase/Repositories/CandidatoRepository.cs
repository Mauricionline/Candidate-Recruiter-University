using Candidate_Recruiter.DataBase.Context;
using Candidate_Recruiter.DataBase.Repositories.Interfaces;
using Candidate_Recruiter.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace Candidate_Recruiter.DataBase.Repositories
{
    public class CandidatoRepository : Repository<Candidato>, ICandidatoRepository
    {
        public CandidatoRepository(IDataContext affiliationContext) : base(affiliationContext)
        {
        }
    }
}
