using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLayered.Contracts.DataTransferObjects;
using NLayered.Contracts.Services;

namespace NLayered.Controllers
{
    [ApiController]
    [Route("dokumenti/{dokumentId}/stavke")]
    public class StavkeController : ControllerBase
    {
        private readonly IStavkeService _stavkeService;

        public StavkeController(IStavkeService stavkeService)
        {
            _stavkeService = stavkeService;
        }

        [HttpGet]
        public async Task<IEnumerable<StavkaDto>> GetStavke(int dokumentId)
        {
            return await _stavkeService.GetAll(dokumentId, false);
        }

        [HttpPost]
        public async Task Create(int dokumentId, [FromBody] StavkaDto stavkaDto)
        {
            await _stavkeService.Create(dokumentId, stavkaDto);
        }

        [HttpPut]
        public async Task Update(int dokumentId, [FromBody] StavkaDto stavka)
        {
            await _stavkeService.Update(dokumentId, stavka);
        }
    }
}