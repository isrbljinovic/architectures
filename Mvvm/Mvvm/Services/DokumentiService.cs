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

        public async Task Create(Dokument dokument)
        {
            var url = ApiConstants.BaseUrl + ApiConstants.PostDokument;

            await _httpHandler.PostAsync(url, dokument);

            return; 
        }

        public async Task<string> GetNazivArtikla(int sifraArtikla)
        {
            var url = $"{ApiConstants.BaseUrl}artikli/{sifraArtikla}/naziv";

            var naziv = await _httpHandler.GetAsync<string>(url);

            return naziv;
        }

        public async Task<List<Dokument>> GettAll()
        {
            string url = ApiConstants.BaseUrl + ApiConstants.GetDokumenti;

            var dokumenti = await _httpHandler.GetAsync<List<Dokument>>(url);

            return dokumenti;
        }
    }
}

