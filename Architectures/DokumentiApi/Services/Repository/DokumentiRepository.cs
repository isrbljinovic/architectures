using System.Collections.Generic;
using System.Threading.Tasks;
using DokumentiApi.Contracts.Repository;
using DokumentiApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DokumentiApi.Services.Repository
{
    public class DokumentiRepository : RepositoryBase<Dokument>, IDokumentiRepository
    {
        public DokumentiRepository(DokumentiContext dbContext) : base(dbContext)
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
                .Include(s => s.Stavkas)
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
