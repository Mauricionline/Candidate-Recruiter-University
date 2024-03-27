using Candidate_Recruiter.DataBase.Context;
using Candidate_Recruiter.DataBase.Repositories.Interfaces;
using Candidate_Recruiter.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Candidate_Recruiter.DataBase.Repositories
{
    public class PuestoRepository : Repository<Puesto>, IPuestoRepository
    {
        public PuestoRepository(IDataContext affiliationContext) : base(affiliationContext)
        {
        }

        public async Task<Puesto> BuscarPorCodigo(string codigo)
        {
            return await GetAll().Where(x=> x.Codigo == codigo).FirstOrDefaultAsync();
        }
    }
}
