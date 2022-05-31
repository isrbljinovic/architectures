using System.Threading.Tasks;
using ArtikliApi.Contracts.Repository;
using ArtikliApi.Models;

namespace ArtikliApi.Services.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private ArtikliContext _context;
        private IArtikliRepository _dokumentRepository;

        public RepositoryManager(ArtikliContext dbContext)
        {
            _context = dbContext;
        }

        public IArtikliRepository Artikli => (_dokumentRepository is null) ?
            new ArtikliRepository(_context) : _dokumentRepository;

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
