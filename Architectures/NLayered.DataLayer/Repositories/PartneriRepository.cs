using Microsoft.EntityFrameworkCore;
using NLayered.Contracts.Models;
using NLayered.Contracts.Repository;
using NLayered.DataLayer.DbContexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLayered.DataLayer.Repositories
{
    public class PartneriRepository : RepositoryBase<Partner>, IPartneriRepository
    {
        public PartneriRepository(FirmaContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Partner>> GetAll(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .Include(x => x.SjedisteNavigation)
                .ToListAsync();
        }

        public async Task<string> GetNaziv(int id, bool trackChanges)
        {
            var partner = await FindByCondition(x => x.Id == id, trackChanges).FirstOrDefaultAsync();

            return partner.Naziv;
        }
    }
}

