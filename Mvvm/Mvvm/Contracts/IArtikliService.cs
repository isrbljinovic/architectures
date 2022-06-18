using Mvvm.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mvvm.Contracts
{
    public interface IArtikliService
    {
        Task<List<Artikl>> GetAll();
    }
}

