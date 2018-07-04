using System.IO;
using Newtonsoft.Json;

namespace FunWithSpotifyApi.Helpers
{
    public static class JsonHelp
    {
        public static T Deserialize<T>(string json)
        {
            JsonSerializer s = new JsonSerializer();
            return s.Deserialize<T>(new JsonTextReader(new StringReader(json)));
        }
    }
}
