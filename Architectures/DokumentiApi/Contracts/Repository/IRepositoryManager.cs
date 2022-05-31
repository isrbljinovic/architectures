using System.Threading.Tasks;

namespace DokumentiApi.Contracts.Repository
{
    public interface IRepositoryManager
    {
        public IDokumentiRepository Dokumenti { get; }

        Task Save();
    }
}
