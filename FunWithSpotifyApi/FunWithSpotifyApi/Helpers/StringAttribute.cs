using System;

namespace FunWithSpotifyApi.Helpers
{
    public sealed class StringAttribute : Attribute
    {
        public string Text { get; set; }

        public StringAttribute(string text)
        {
            Text = text;
        }
    }
}
