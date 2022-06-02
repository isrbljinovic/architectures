using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mvvm.Constants;
using Mvvm.Contracts;
using Mvvm.Models;

namespace Mvvm.Services
{
	public class DokumentiService : IDokumentiService
	{
        private readonly IHttpHandler _httpHandler;

        public DokumentiService(IHttpHandler httpHandler)
		{
            _httpHandler = httpHandler;
        }

        public Task Create(Dokument dokument)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Dokument>> GettAll()
        {
            string url = ApiConstants.BaseUrl + ApiConstants.GetDokumenti;

            var dokumenti = await _httpHandler.GetAsync<List<Dokument>>(url);

            return dokumenti;
        }
    }
}

