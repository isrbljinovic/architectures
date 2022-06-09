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
        private readonly INaziviService _naziviService;

        public DokumentiService(
            IRepositoryManager repositoryManager,
            INaziviService naziviService)
        {
            _repositoryManager = repositoryManager;
            _naziviService = naziviService;
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
                var dto = Dokument.ToDto(doc);
                foreach (var stavka in dto.Stavkas)
                {
                    stavka.NazivArtikla = await _naziviService.GetArtikl(stavka.SifraArtikla);
                }
                dto.PartnerNaziv = await _naziviService.GetPartner(doc.PartnerId.Value);
                dokumenti.Add(dto);
            }

            return dokumenti;
        }

        public async Task Update(DokumentDto dokumentDto)
        {
            var dokumentToUpdate = await _repositoryManager.Dokumenti.Get(dokumentDto.Id, true);

            Dokument.Map(dokumentDto, dokumentToUpdate);

            _repositoryManager.Dokumenti.Update(dokumentToUpdate);

            await _repositoryManager.Save();
        }
    }
}
