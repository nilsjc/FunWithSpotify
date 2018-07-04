using System;

namespace FunWithSpotifyApi.Helpers
{
    public static class ControllerResolver
    {
        public static string GetUrlName(Type controller)
        {
            var name = controller.Name;
            return name.EndsWith("Controller") ? name.Substring(0, name.Length - 10) : name;
        }
    }
}
