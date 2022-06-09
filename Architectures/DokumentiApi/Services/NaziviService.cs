using System;
using System.Net.Http;
using System.Threading.Tasks;
using DokumentiApi.Contracts;

namespace DokumentiApi.Services
{
    public class NaziviService : INaziviService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NaziviService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetArtikl(int sifraArtikla)
        {
            var artikliHttpClient = _httpClientFactory.CreateClient("ArtikliApi");

            var httpResponse = await artikliHttpClient.GetAsync($"{sifraArtikla}/naziv");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();

            return content;
        }

        public async Task<string> GetPartner(int id)
        {
            var partnerHttpClient = _httpClientFactory.CreateClient("PartneriApi");

            var httpResponse = await partnerHttpClient.GetAsync($"{id}/naziv");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();

            return content;
        }
    }
}
