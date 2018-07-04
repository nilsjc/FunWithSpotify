using FunWithSpotifyApi.Models.SpotifyApi;

namespace FunWithSpotifyApi.Interfaces
{
    public interface IAudioFeatureRepository
    {
        TunableTrack GetAudioFeature(string id);
    }
}
