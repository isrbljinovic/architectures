using NLayered.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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
