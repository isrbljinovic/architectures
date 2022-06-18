using Microsoft.AspNetCore.Mvc;
using NLayered.Contracts.DataTransferObjects;
using NLayered.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLayered.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DokumentiController : ControllerBase
    {
        private readonly IDokumentiService _dokumentiService;

        public DokumentiController(
            IDokumentiService dokumentiService)
        {
            _dokumentiService = dokumentiService;
        }

        [HttpGet]
        public async Task<IEnumerable<DokumentDto>> GetAll()
        {
            return await _dokumentiService.GetAll(trackChanges: false);
        }

        [HttpGet("{id}")]
        public async Task<DokumentDto> Get(int id)
        {
            return await _dokumentiService.Get(id, false);
        }

        [HttpPost]
        public async Task Create([FromBody] DokumentDto dokumentDto)
        {
            await _dokumentiService.Create(dokumentDto);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _dokumentiService.Delete(id);
        }

        [HttpPut]
        public async Task Update(DokumentDto dokument)
        {
            throw new NotImplementedException();
        }
    }
}
