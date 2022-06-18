using DokumentiApi.Contracts.Repository;
using DokumentiApi.Models;
using System.Threading.Tasks;

namespace DokumentiApi.Services.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private DokumentiContext _context;
        private IDokumentiRepository _dokumentRepository;

        public RepositoryManager(DokumentiContext dbContext)
        {
            _context = dbContext;
        }

        public IDokumentiRepository Dokumenti => (_dokumentRepository is null) ?
            new DokumentiRepository(_context) : _dokumentRepository;

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
