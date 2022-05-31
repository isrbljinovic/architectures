using System.Collections.Generic;
using System.Threading.Tasks;
using DokumentiApi.Contracts;
using DokumentiApi.Contracts.Repository;
using DokumentiApi.DataTransferObjects;
using DokumentiApi.Models;

namespace DokumentiApi.Services
{
    public class DokumentiService : IDokumentiService
    {
        private readonly IRepositoryManager _repositoryManager;

        public DokumentiService(
            IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task Create(DokumentDto dokumentDto)
        {
            var dokument = Dokument.FromDto(dokumentDto);
            _repositoryManager.Dokumenti.CreateDokument(dokument);
            await _repositoryManager.Save();
        }

        public async Task Delete(int dokumentId)
        {
            var dokumentToDelete = await _repositoryManager.Dokumenti.Get(dokumentId, true);
            _repositoryManager.Dokumenti.DeleteDokument(dokumentToDelete);
            await _repositoryManager.Save();
        }

        public async Task<DokumentDto> Get(int dokumentId, bool trackChanges)
        {
            var dok = await _repositoryManager.Dokumenti.Get(dokumentId, trackChanges);

            return Dokument.ToDto(dok);
        }

        public async Task<List<DokumentDto>> GetAll(bool trackChanges)
        {
            var dox = await _repositoryManager.Dokumenti.GetAll(trackChanges);
            List<DokumentDto> dokumenti = new();

            foreach (var doc in dox)
            {
                dokumenti.Add(Dokument.ToDto(doc));
            }

            return dokumenti;
        }
    }
}
