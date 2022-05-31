using System.Collections.Generic;
using System.Threading.Tasks;
using DokumentiApi.Contracts;
using DokumentiApi.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DokumentiApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DokumentiController : ControllerBase
    {
        private readonly IDokumentiService _dokumentiService;
        private readonly ILogger<DokumentiController> _logger;

        public DokumentiController(
            IDokumentiService dokumentiService,
            ILogger<DokumentiController> logger)
        {
            _dokumentiService = dokumentiService;
            _logger = logger;
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
    }
}