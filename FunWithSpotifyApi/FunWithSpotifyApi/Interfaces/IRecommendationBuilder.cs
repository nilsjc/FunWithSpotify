using System.Collections.Generic;
using FunWithSpotifyApi.Models;

namespace FunWithSpotifyApi.Interfaces
{
    public interface IRecommendationBuilder
    {
        RecommendationModel CalculateFromQuestions(List<Answer> answers);
        RecommendationModel AddAudioFeaturesFromModels(AnswerSetUp answerSetUp);
        RecommendationModel AddArtists(RecommendationModel model, List<string> Artists);
        RecommendationModel AddGenres(RecommendationModel model, List<string> Genres);
    }
}
