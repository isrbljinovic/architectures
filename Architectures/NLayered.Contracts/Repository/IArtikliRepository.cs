using NLayered.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLayered.Contracts.Repository
{
    public interface IArtikliRepository
    {
        Task<IEnumerable<Artikl>> GetAll(bool trackChanges);

        Task<string> GetNaziv(int id, bool trackChanges);
    }
}

