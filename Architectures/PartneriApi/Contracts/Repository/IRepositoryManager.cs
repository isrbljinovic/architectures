using System.Threading.Tasks;

namespace PartneriApi.Contracts.Repository
{
    public interface IRepositoryManager
    {
        public IPartneriRepository Partneri { get; }

        Task Save();
    }
}
