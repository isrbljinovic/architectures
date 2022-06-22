using ArtikliApi.Contracts;
using ArtikliApi.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtikliApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtikliController : ControllerBase
    {
        private readonly IArtikliService _artikliService;
        private readonly ILogger<ArtikliController> _logger;

        public ArtikliController(
            IArtikliService artikliService,
            ILogger<ArtikliController> logger)
        {
            _artikliService = artikliService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<ArtiklDto>> GetAll()
        {
            return await _artikliService.GetAll(trackChanges: false);
        }

        [HttpGet("{id}")]
        public async Task<ArtiklDto> Get(int id)
        {
            return await _artikliService.Get(id, false);
        }

        [HttpPost]
        public async Task Create([FromBody] ArtiklDto dokumentDto)
        {
            await _artikliService.Create(dokumentDto);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _artikliService.Delete(id);
        }

        [HttpGet("{id}/naziv")]
        public async Task<string> GetNaziv(int id)
        {
            var artikl = await _artikliService.Get(id, false);
            return artikl.Naziv;
        }

        [HttpPut]
        public Task Update([FromBody] ArtiklDto dokumentDto)
        {
            throw new NotImplementedException();
        }
    }
}