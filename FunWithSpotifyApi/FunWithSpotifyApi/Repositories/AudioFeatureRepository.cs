using System.Collections.Generic;
using System.IO;
using System.Linq;
using FunWithSpotifyApi.Interfaces;
using FunWithSpotifyApi.Models.SpotifyApi;
using Newtonsoft.Json;

namespace FunWithSpotifyApi.Repositories
{
    public class AudioFeatureRepository : IAudioFeatureRepository
    {
        private const string pathString = "./audio_features_collection.json";
        private List<TunableTrack> _tunableTracks;

        public AudioFeatureRepository()
        {
            _tunableTracks = new List<TunableTrack>();
            _tunableTracks = ReadJsonFile();
        }
        public TunableTrack GetAudioFeature(string id)
        {
            return _tunableTracks.FirstOrDefault(x => x.Id == id);
        }

        private List<TunableTrack> ReadJsonFile()
        {
            List<TunableTrack> list;
            using (StreamReader file = File.OpenText(pathString))
            {
                string json = file.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<TunableTrack>>(json);
            }

            return list;
        }
    }
}
