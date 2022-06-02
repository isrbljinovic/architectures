using System.Threading.Tasks;
using ArtikliApi.Contracts.Repository;
using ArtikliApi.Models;

namespace ArtikliApi.Services.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private ArtikliContext _context;
        private IArtikliRepository _artikliRepository;

        public RepositoryManager(ArtikliContext dbContext)
        {
            _context = dbContext;
        }

        public IArtikliRepository Artikli => (_artikliRepository is null) ?
            new ArtikliRepository(_context) : _artikliRepository;

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
