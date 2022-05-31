using System.Collections.Generic;
using System.Threading.Tasks;
using ArtikliApi.Contracts.Repository;
using ArtikliApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtikliApi.Services.Repository
{
    public class ArtikliRepository : RepositoryBase<Artikl>, IArtikliRepository
    {
        public ArtikliRepository(ArtikliContext dbContext) : base(dbContext)
        {
        }

        public void CreateArtikl(Artikl dokument)
        {
            Create(dokument);
        }

        public void DeleteArtikl(Artikl dokument)
        {
            Delete(dokument);
        }

        public async Task<Artikl> Get(int sifra, bool trackChanges)
        {
            return await FindByCondition(d => d.Sifra.Equals(sifra), trackChanges)
                .SingleAsync();
        }

        public async Task<IEnumerable<Artikl>> GetAll(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .ToListAsync();
        }
    }
}
