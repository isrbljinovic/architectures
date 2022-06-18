using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLayered.Contracts.DataTransferObjects;
using NLayered.Contracts.Services;

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

        [HttpGet("{sifra}/naziv")]
        public async Task<string> GetNaziv(int sifra)
        {
            return await _partneriService.GetNaziv(sifra, false);
        }
    }
}