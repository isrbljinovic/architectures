using PartneriApi.Contracts;
using PartneriApi.Contracts.Repository;
using PartneriApi.DataTransferObjects;
using PartneriApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PartneriApi.Services
{
    public class PartneriService : IPartneriService
    {
        private readonly IRepositoryManager _repositoryManager;

        public PartneriService(
            IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task Create(PartnerDto partnerDto)
        {
            var dokument = Partner.FromDto(partnerDto);
            _repositoryManager.Partneri.CreatePartner(dokument);
            await _repositoryManager.Save();
        }

        public async Task Delete(int partnerId)
        {
            var dokumentToDelete = await _repositoryManager.Partneri.Get(partnerId, true);
            _repositoryManager.Partneri.DeletePartner(dokumentToDelete);
            await _repositoryManager.Save();
        }

        public async Task<PartnerDto> Get(int partnerId, bool trackChanges)
        {
            var dok = await _repositoryManager.Partneri.Get(partnerId, trackChanges);

            return Partner.ToDto(dok);
        }

        public async Task<List<PartnerDto>> GetAll(bool trackChanges)
        {
            var dox = await _repositoryManager.Partneri.GetAll(trackChanges);
            List<PartnerDto> dokumenti = new();

            foreach (var doc in dox)
            {
                dokumenti.Add(Partner.ToDto(doc));
            }

            return dokumenti;
        }
    }
}
