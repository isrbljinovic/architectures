using NLayered.Contracts.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLayered.Contracts.Services
{
    public interface IStavkeService
    {
        Task<List<StavkaDto>> GetAll(int dokumentId, bool trackChanges);

        Task Update(int dokumentId, StavkaDto stavka);

        Task Create(int dokumentId, StavkaDto stavkaDto);

        Task Delete(StavkaDto stavka);
    }
}
