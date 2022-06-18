using Mvvm.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mvvm.Contracts
{
    public interface IPartneriService
    {
        Task<List<Partner>> GetAll();
    }
}

