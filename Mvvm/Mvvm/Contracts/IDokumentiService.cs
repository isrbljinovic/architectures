using System.Collections.Generic;
using System.Threading.Tasks;
using Mvvm.Models;

namespace Mvvm.Contracts
{
    public interface IDokumentiService
	{
		Task<List<Dokument>> GettAll();

		Task Create(Dokument dokument);

		Task<string> GetNazivArtikla(int sifraArtikla);
	}
}

