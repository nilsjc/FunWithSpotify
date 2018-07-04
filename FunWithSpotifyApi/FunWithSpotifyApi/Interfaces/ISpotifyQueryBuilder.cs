using FunWithSpotifyApi.Models;

namespace FunWithSpotifyApi.Interfaces
{
    public interface ISpotifyQueryBuilder
    {
        string GetAlbum(string id, string market);

        string GetRecommendations(RecommendationModel recommendation);
    }
}