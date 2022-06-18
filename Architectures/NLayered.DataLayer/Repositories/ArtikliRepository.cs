using Microsoft.EntityFrameworkCore;
using NLayered.Contracts.Models;
using NLayered.Contracts.Repository;
using NLayered.DataLayer.DbContexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLayered.DataLayer.Repositories
{
    public class ArtikliRepository : RepositoryBase<Artikl>, IArtikliRepository
    {
        public ArtikliRepository(FirmaContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Artikl>> GetAll(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .ToListAsync();
        }

        public async Task<string> GetNaziv(int sifra, bool trackChanges)
        {
            var artikl = await FindByCondition(x => x.Sifra == sifra, trackChanges).FirstOrDefaultAsync();

            return artikl.Naziv;
        }
    }
}

