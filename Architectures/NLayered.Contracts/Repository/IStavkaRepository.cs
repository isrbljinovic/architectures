using System.Collections.Generic;
using System.Threading.Tasks;
using NLayered.Contracts.Models;

namespace NLayered.Contracts.Repository
{
    public interface IStavkaRepository
    {
        Task<IEnumerable<Stavka>> GetAll(int dokumentId, bool trackChanges);

        void CreateStavka(int dokumentId, Stavka stavka);

        void DeleteStavka(Stavka stavka);

        Task<Stavka> GetStavka(int dokumentId, int stavkaId, bool trackChanges);
    }
}
