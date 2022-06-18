using Mvvm.Constants;
using Mvvm.Contracts;
using Mvvm.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mvvm.Services
{
    public class PartneriService : IPartneriService
    {
        private readonly IHttpHandler _httpHandler;

        public PartneriService(IHttpHandler httpHandler)
        {
            _httpHandler = httpHandler;
        }

        public async Task<List<Partner>> GetAll()
        {
            var url = ApiConstants.BaseUrl + ApiConstants.GetPartneri;

            var partneri = await _httpHandler.GetAsync<List<Partner>>(url);

            return partneri;
        }
    }
}

