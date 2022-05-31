using System.Threading.Tasks;

namespace ArtikliApi.Contracts.Repository
{
    public interface IRepositoryManager
    {
        public IArtikliRepository Artikli { get; }

        Task Save();
    }
}
