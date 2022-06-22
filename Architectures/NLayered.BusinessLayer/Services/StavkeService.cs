using NLayered.Contracts.DataTransferObjects;
using NLayered.Contracts.Models;
using NLayered.Contracts.Repository;
using NLayered.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLayered.BusinessLayer.Services
{
    public class StavkeService : IStavkeService
    {
        private readonly IRepositoryManager _repositoryManager;

        public StavkeService(
            IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task Create(int dokumentId, StavkaDto stavkaDto)
        {
            var newStavka = Stavka.FromDto(stavkaDto);
            _repositoryManager.Stavka.CreateStavka(dokumentId, newStavka);
            await _repositoryManager.Save();
        }

        public async Task Delete(StavkaDto stavkaDto)
        {
            var stavkaToDelete = Stavka.FromDto(stavkaDto);
            _repositoryManager.Stavka.DeleteStavka(stavkaToDelete);
            await _repositoryManager.Save();
        }

        public Task<StavkaDto> Get(int dokumentId, int stavkaId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public async Task<List<StavkaDto>> GetAll(int dokumentId, bool trackChanges)
        {
            var stavke = await _repositoryManager.Stavka.GetAll(dokumentId, trackChanges);
            List<StavkaDto> stavkaDtos = new();
            foreach (var stavka in stavke)
            {
                stavkaDtos.Add(Stavka.ToDto(stavka));
            }

            return stavkaDtos;
        }

        public async Task Update(int dokumentId, StavkaDto stavkaDto)
        {
            var stavka = await _repositoryManager.Stavka.GetStavka(dokumentId, stavkaDto.IdStavke, true);
            Stavka.Update(stavka, stavkaDto);
            await _repositoryManager.Save();
        }
    }
}
