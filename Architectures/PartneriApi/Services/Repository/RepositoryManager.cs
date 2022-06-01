using System.Threading.Tasks;
using PartneriApi.Contracts.Repository;
using PartneriApi.Models;

namespace PartneriApi.Services.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private PartneriContext _context;
        private IPartneriRepository _dokumentRepository;

        public RepositoryManager(PartneriContext dbContext)
        {
            _context = dbContext;
        }

        public IPartneriRepository Partneri => (_dokumentRepository is null) ?
            new PartneriRepository(_context) : _dokumentRepository;

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
