using System.Collections.Generic;
using System.Threading.Tasks;
using NLayered.Contracts.Models;

namespace NLayered.Contracts.Repository
{
    public interface IArtikliRepository
	{
		Task<IEnumerable<Artikl>> GetAll(bool trackChanges);

		Task<string> GetNaziv(int sifra, bool trackChanges);
	}
}

