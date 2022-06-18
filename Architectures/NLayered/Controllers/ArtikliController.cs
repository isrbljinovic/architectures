using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLayered.Contracts.DataTransferObjects;
using NLayered.Contracts.Services;

namespace NLayered.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtikliController : ControllerBase
    {
        private readonly IArtikliService _artikliService;

        public ArtikliController(IArtikliService artikliService)
        {
            _artikliService = artikliService;
        }

        [HttpGet]
        public async Task<IEnumerable<ArtiklDto>> GetAll()
        {
            return await _artikliService.GetAll(trackChanges: false);
        }

        [HttpGet("{sifra}")]
        public async Task<string> GetNaziv(int sifra)
        {
            return await _artikliService.GetNaziv(sifra, false);
        }
    }
}