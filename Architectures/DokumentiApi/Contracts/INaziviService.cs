using System.Threading.Tasks;

namespace DokumentiApi.Contracts
{
    public interface INaziviService
    {
        Task<string> GetArtikl(int sifraArtikla);

        Task<string> GetPartner(int id);
    }
}
