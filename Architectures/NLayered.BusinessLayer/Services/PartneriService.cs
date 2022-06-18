using NLayered.Contracts.DataTransferObjects;
using NLayered.Contracts.Models;
using NLayered.Contracts.Repository;
using NLayered.Contracts.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLayered.BusinessLayer.Services
{
    public class PartneriService : IPartneriService
    {
        private readonly IRepositoryManager _repositoryManager;

        public PartneriService(
            IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<PartnerDto>> GetAll(bool trackChanges)
        {
            var partneri = await _repositoryManager.Partneri.GetAll(trackChanges);

            var partneriDto = new List<PartnerDto>();

            foreach (var partner in partneri)
            {
                partneriDto.Add(Partner.ToDto(partner));
            }

            return partneriDto;
        }

        public async Task<string> GetNaziv(int id, bool trackChanges)
        {
            return await _repositoryManager.Partneri.GetNaziv(id, trackChanges);
        }
    }
}

