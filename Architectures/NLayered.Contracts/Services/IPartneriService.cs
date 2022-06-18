using System.Collections.Generic;
using System.Threading.Tasks;
using NLayered.Contracts.DataTransferObjects;

namespace NLayered.Contracts.Services
{
    public interface IPartneriService
	{
		Task<IEnumerable<PartnerDto>> GetAll(bool trackChanges);

		Task<string> GetNaziv(int id, bool trackChanges);
	}
}

