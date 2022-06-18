using System.Threading.Tasks;

namespace NLayered.Contracts.Repository
{
    public interface IRepositoryManager
    {
        public IDokumentRepository Dokumenti { get; }
        public IStavkaRepository Stavka { get; }
        public IArtikliRepository Artikli { get; }
        public IPartneriRepository Partneri { get; }

        Task Save();
    }
}
