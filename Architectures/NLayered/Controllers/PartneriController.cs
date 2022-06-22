using Microsoft.AspNetCore.Mvc;
using NLayered.Contracts.DataTransferObjects;
using NLayered.Contracts.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLayered.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PartneriController : ControllerBase
    {
        private readonly IPartneriService _partneriService;

        public PartneriController(IPartneriService partneriService)
        {
            _partneriService = partneriService;
        }

        [HttpGet]
        public async Task<IEnumerable<PartnerDto>> GetAll()
        {
            return await _partneriService.GetAll(trackChanges: false);
        }

        [HttpGet("{id}/naziv")]
        public async Task<string> GetNaziv(int id)
        {
            return await _partneriService.GetNaziv(id, false);
        }
    }
}