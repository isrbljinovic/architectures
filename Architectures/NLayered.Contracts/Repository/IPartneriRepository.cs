using NLayered.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLayered.Contracts.Repository
{
    public interface IPartneriRepository
    {
        Task<IEnumerable<Partner>> GetAll(bool trackChanges);

        Task<string> GetNaziv(int id, bool trackChanges);
    }
}

