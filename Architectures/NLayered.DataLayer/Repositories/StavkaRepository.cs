using Microsoft.EntityFrameworkCore;
using NLayered.Contracts.Models;
using NLayered.Contracts.Repository;
using NLayered.DataLayer.DbContexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLayered.DataLayer.Repositories
{
    public class StavkaRepository : RepositoryBase<Stavka>, IStavkaRepository
    {
        public StavkaRepository(FirmaContext dbContext) : base(dbContext)
        {
        }

        public void CreateStavka(int dokumentId, Stavka stavka)
        {
            stavka.DokumentId = dokumentId;
            Create(stavka);
        }

        public void DeleteStavka(Stavka stavka)
        {
            Delete(stavka);
        }

        public async Task<IEnumerable<Stavka>> GetAll(int dokumentId, bool trackChanges)
        {
            return await FindByCondition(s => s.DokumentId.Equals(dokumentId), trackChanges).ToListAsync();
        }

        public async Task<Stavka> GetStavka(int dokumentId, int stavkaId, bool trackChanges)
        {
            return await FindByCondition(s => s.DokumentId.Equals(dokumentId) && s.Id.Equals(stavkaId), trackChanges).SingleOrDefaultAsync();
        }
    }
}
