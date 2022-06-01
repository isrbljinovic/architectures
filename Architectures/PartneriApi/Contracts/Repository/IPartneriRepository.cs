using System.Collections.Generic;
using System.Threading.Tasks;
using PartneriApi.Models;

namespace PartneriApi.Contracts.Repository
{
    public interface IPartneriRepository
    {
        Task<IEnumerable<Partner>> GetAll(bool trackChanges);

        Task<Partner> Get(int id, bool trackChanges);

        void CreatePartner(Partner partner);

        void DeletePartner(Partner partner);
    }
}
