using ArtikliApi.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtikliApi.Contracts
{
    public interface IArtikliService
    {
        Task<List<ArtiklDto>> GetAll(bool trackChanges);

        Task<ArtiklDto> Get(int sifraArtikla, bool trackChanges);

        Task Create(ArtiklDto artiklDto);

        Task Delete(int sifraArtikla);
    }
}
