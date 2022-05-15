using System.Threading.Tasks;
using NLayered.Contracts.Repository;
using NLayered.DataLayer.DbContexts;

namespace NLayered.DataLayer.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private FirmaContext _context;
        private IDokumentRepository _dokumentRepository;
        private IStavkaRepository _stavkaRepository;

        public RepositoryManager(FirmaContext dbContext)
        {
            _context = dbContext;
        }

        public IDokumentRepository Dokumenti => (_dokumentRepository is null) ?
            new DokumentRepository(_context) : _dokumentRepository;

        public IStavkaRepository Stavka => (_stavkaRepository is null) ?
            new StavkaRepository(_context) : _stavkaRepository;

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
