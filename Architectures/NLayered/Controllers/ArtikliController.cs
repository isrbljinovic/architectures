using Microsoft.AspNetCore.Mvc;
using NLayered.Contracts.DataTransferObjects;
using NLayered.Contracts.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLayered.Controllers
{
    [Route("[controller]")]
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

        [HttpGet("{id}/naziv")]
        public async Task<string> GetNaziv(int id)
        {
            return await _artikliService.GetNaziv(id, false);
        }
    }
}