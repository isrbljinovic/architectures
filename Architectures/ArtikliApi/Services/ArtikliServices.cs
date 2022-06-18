using ArtikliApi.Contracts;
using ArtikliApi.Contracts.Repository;
using ArtikliApi.DataTransferObjects;
using ArtikliApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtikliApi.Services
{
    public class ArtikliService : IArtikliService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ArtikliService(
            IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task Create(ArtiklDto dokumentDto)
        {
            var dokument = Artikl.FromDto(dokumentDto);
            _repositoryManager.Artikli.CreateArtikl(dokument);
            await _repositoryManager.Save();
        }

        public async Task Delete(int dokumentId)
        {
            var dokumentToDelete = await _repositoryManager.Artikli.Get(dokumentId, true);
            _repositoryManager.Artikli.DeleteArtikl(dokumentToDelete);
            await _repositoryManager.Save();
        }

        public async Task<ArtiklDto> Get(int dokumentId, bool trackChanges)
        {
            var dok = await _repositoryManager.Artikli.Get(dokumentId, trackChanges);

            return Artikl.ToDto(dok);
        }

        public async Task<List<ArtiklDto>> GetAll(bool trackChanges)
        {
            var dox = await _repositoryManager.Artikli.GetAll(trackChanges);
            List<ArtiklDto> dokumenti = new();

            foreach (var doc in dox)
            {
                dokumenti.Add(Artikl.ToDto(doc));
            }

            return dokumenti;
        }
    }
}
