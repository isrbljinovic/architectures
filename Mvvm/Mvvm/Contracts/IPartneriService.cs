using System.Collections.Generic;
using System.Threading.Tasks;
using Mvvm.Models;

namespace Mvvm.Contracts
{
    public interface IPartneriService
	{
		Task<List<Partner>> GetAll();
	}
}

