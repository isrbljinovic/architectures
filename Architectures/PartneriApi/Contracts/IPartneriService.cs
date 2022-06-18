using PartneriApi.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PartneriApi.Contracts
{
    public interface IPartneriService
    {
        Task<List<PartnerDto>> GetAll(bool trackChanges);

        Task<PartnerDto> Get(int partnerId, bool trackChanges);

        Task Create(PartnerDto partnerDto);

        Task Delete(int partnerId);
    }
}
