using System.Collections.Generic;
using System.Threading.Tasks;
using ArtikliApi.Models;

namespace ArtikliApi.Contracts.Repository
{
    public interface IArtikliRepository
    {
        Task<IEnumerable<Artikl>> GetAll(bool trackChanges);

        Task<Artikl> Get(int sifra, bool trackChanges);

        void CreateArtikl(Artikl artikl);

        void DeleteArtikl(Artikl artikl);
    }
}
