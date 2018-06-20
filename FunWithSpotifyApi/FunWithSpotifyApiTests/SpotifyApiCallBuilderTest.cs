using System;
using System.Collections.Generic;
using System.Text;
using FunWithSpotifyApi.Services;
using NUnit.Framework;

namespace FunWithSpotifyApiTests
{
    [TestFixture]
    public class SpotifyApiCallBuilderTest
    {
        private SpotifyApiCallBuilder _builder;
        [SetUp]
        public void TestSetUp()
        {
            _builder = new SpotifyApiCallBuilder();
        }
    }
}
