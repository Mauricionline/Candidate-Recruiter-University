using Candidate_Recruiter.Models;
using System.Threading.Tasks;

namespace Candidate_Recruiter.DataBase.Repositories.Interfaces
{
    public interface IPuestoRepository: IRepository<Puesto>
    {
        Task<Puesto> BuscarPorCodigo(string codigo);
    }
}
