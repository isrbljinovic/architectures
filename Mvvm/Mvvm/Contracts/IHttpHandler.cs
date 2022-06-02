using System.Threading.Tasks;

namespace Mvvm.Contracts
{
    public interface IHttpHandler
    {
        Task<T> GetAsync<T>(string uri, string authToken = "");

        Task<T> PostAsync<T>(string uri, T data, string authToken = "");

        Task<T> PutAsync<T>(string uri, T data, string authToken = "");

        Task DeleteAsync(string uri, string authToken = "");
    }
}

