using Mvvm.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mvvm.Contracts
{
    public interface IDokumentiService
    {
        Task<List<Dokument>> GettAll();

        Task Create(Dokument dokument);

        Task<string> GetNazivArtikla(int sifraArtikla);

        Task Update(Dokument dokument);

        Task Delete(int id);
    }
}

