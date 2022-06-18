using Microsoft.EntityFrameworkCore;
using PartneriApi.Contracts.Repository;
using PartneriApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PartneriApi.Services.Repository
{
    public class PartneriRepository : RepositoryBase<Partner>, IPartneriRepository
    {
        public PartneriRepository(PartneriContext dbContext) : base(dbContext)
        {
        }

        public void CreatePartner(Partner partner)
        {
            Create(partner);
        }

        public void DeletePartner(Partner partner)
        {
            Delete(partner);
        }

        public async Task<Partner> Get(int id, bool trackChanges)
        {
            return await FindByCondition(d => d.Id.Equals(id), trackChanges)
                .Include(s => s.IdMjestaNavigation)
                .SingleAsync();
        }

        public async Task<IEnumerable<Partner>> GetAll(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .Include(s => s.IdMjestaNavigation)
                .ToListAsync();
        }
    }
}
