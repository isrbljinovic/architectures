using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLayered.Contracts.Models;
using NLayered.Contracts.Repository;
using NLayered.DataLayer.DbContexts;

namespace NLayered.DataLayer.Repositories
{
    public class DokumentRepository : RepositoryBase<Dokument>, IDokumentRepository
    {
        public DokumentRepository(FirmaContext dbContext) : base(dbContext)
        {
        }

        public void CreateDokument(Dokument dokument)
        {
            Create(dokument);
        }

        public void DeleteDokument(Dokument dokument)
        {
            Delete(dokument);
        }

        public async Task<Dokument> Get(int id, bool trackChanges)
        {
            return await FindByCondition(d => d.Id.Equals(id), trackChanges)
                .Include(d => d.Stavkas)
                .SingleAsync();
        }

        public async Task<IEnumerable<Dokument>> GetAll(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .Include(s => s.Stavkas)
                .ToListAsync();
        }
    }
}
