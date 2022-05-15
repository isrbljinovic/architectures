using System.Threading.Tasks;

namespace NLayered.Contracts.Repository
{
    public interface IRepositoryManager
    {
        public IDokumentRepository Dokumenti { get; }
        public IStavkaRepository Stavka { get; }

        Task Save();
    }
}
