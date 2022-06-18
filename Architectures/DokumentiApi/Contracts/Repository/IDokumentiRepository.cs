using DokumentiApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DokumentiApi.Contracts.Repository
{
    public interface IDokumentiRepository
    {
        Task<IEnumerable<Dokument>> GetAll(bool trackChanges);

        Task<Dokument> Get(int id, bool trackChanges);

        void CreateDokument(Dokument dokument);

        void DeleteDokument(Dokument dokument);

        void Update(Dokument dokument);
    }
}
