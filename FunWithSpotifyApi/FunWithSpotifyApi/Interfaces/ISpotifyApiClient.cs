using System.Threading.Tasks;

namespace FunWithSpotifyApi.Interfaces
{
    public interface ISpotifyApiClient
    {
        Task<string> GetData(string query, string bearerToken);
    }
}
