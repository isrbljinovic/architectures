using NLayered.Contracts.DataTransferObjects;
using NLayered.Contracts.Models;
using NLayered.Contracts.Repository;
using NLayered.Contracts.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLayered.BusinessLayer.Services
{
    public class ArtikliService : IArtikliService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ArtikliService(
            IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<ArtiklDto>> GetAll(bool trackChanges)
        {
            var artikli = await _repositoryManager.Artikli.GetAll(trackChanges);

            var artikliDto = new List<ArtiklDto>();

            foreach (var artikl in artikli)
            {
                artikliDto.Add(Artikl.ToDto(artikl));
            }

            return artikliDto;
        }

        public async Task<string> GetNaziv(int sifra, bool trackChanges)
        {
            return await _repositoryManager.Artikli.GetNaziv(sifra, trackChanges);
        }
    }
}

