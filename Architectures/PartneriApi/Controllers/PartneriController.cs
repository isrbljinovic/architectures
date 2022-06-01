using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PartneriApi.Contracts;
using PartneriApi.DataTransferObjects;

namespace PartneriApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PartneriController : ControllerBase
    {
        private readonly IPartneriService _partneriService;
        private readonly ILogger<PartneriController> _logger;

        public PartneriController(
            IPartneriService partneriService,
            ILogger<PartneriController> logger)
        {
            _partneriService = partneriService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<PartnerDto>> GetAll()
        {
            return await _partneriService.GetAll(trackChanges: false);
        }

        [HttpGet("{id}")]
        public async Task<PartnerDto> Get(int id)
        {
            return await _partneriService.Get(id, false);
        }

        [HttpPost]
        public async Task Create([FromBody] PartnerDto partnerDto)
        {
            await _partneriService.Create(partnerDto);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _partneriService.Delete(id);
        }
    }
}