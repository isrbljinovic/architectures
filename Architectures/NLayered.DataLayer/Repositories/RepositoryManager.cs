using NLayered.Contracts.Repository;
using NLayered.DataLayer.DbContexts;
using System.Threading.Tasks;

namespace NLayered.DataLayer.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private FirmaContext _context;
        private IDokumentRepository _dokumentRepository;
        private IStavkaRepository _stavkaRepository;
        private IArtikliRepository _artikliRepository;
        private IPartneriRepository _partneriRepository;

        public RepositoryManager(FirmaContext dbContext)
        {
            _context = dbContext;
        }

        public IDokumentRepository Dokumenti => (_dokumentRepository is null) ?
            new DokumentRepository(_context) : _dokumentRepository;

        public IStavkaRepository Stavka => (_stavkaRepository is null) ?
            new StavkaRepository(_context) : _stavkaRepository;

        public IArtikliRepository Artikli => (_artikliRepository is null) ?
            new ArtikliRepository(_context) : _artikliRepository;

        public IPartneriRepository Partneri => (_partneriRepository is null) ?
            new PartneriRepository(_context) : _partneriRepository;

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
