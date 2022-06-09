using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mvvm.Constants;
using Mvvm.Contracts;
using Mvvm.Models;

namespace Mvvm.Services
{
	public class ArtikliService : IArtikliService
	{
        private readonly IHttpHandler _httpHandler;

        public ArtikliService(IHttpHandler httpHandler)
        {
            _httpHandler = httpHandler;
        }

        public async Task<List<Artikl>> GetAll()
        {
            string url = ApiConstants.BaseUrl + ApiConstants.GetArtikli;

            var artikli = await _httpHandler.GetAsync<List<Artikl>>(url);

            return artikli;
        }
    }
}

