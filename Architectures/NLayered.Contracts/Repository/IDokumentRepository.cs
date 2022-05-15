using System.Collections.Generic;
using System.Threading.Tasks;
using NLayered.Contracts.Models;

namespace NLayered.Contracts.Repository
{
    public interface IDokumentRepository
    {
        Task<IEnumerable<Dokument>> GetAll(bool trackChanges);

        Task<Dokument> Get(int id, bool trackChanges);

        void CreateDokument(Dokument dokument);

        void DeleteDokument(Dokument dokument);
    }
}
