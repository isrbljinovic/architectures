using System.Collections.Generic;
using System.Threading.Tasks;
using NLayered.Contracts.DataTransferObjects;

namespace NLayered.Contracts.Services
{
    public interface IArtikliService
	{
		Task<IEnumerable<ArtiklDto>> GetAll(bool trackChanges);

		Task<string> GetNaziv(int sifra, bool trackChanges);
	}
}

