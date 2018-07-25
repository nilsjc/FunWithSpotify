using System;
using System.Collections.Generic;
using FunWithSpotifyApi.Interfaces;
using FunWithSpotifyApi.Models;
using FunWithSpotifyApi.Models.SpotifyApi;
using FunWithSpotifyApi.Repositories;

namespace FunWithSpotifyApi.Services
{
    public class RecommendationBuilder : IRecommendationBuilder
    {
        private RecommendationModel _model;
        private QuestionRepository  _questionRepository;
        private IAudioFeatureRepository _audioFeatureRepo;
        private int _score;

        public RecommendationBuilder(AppSettings appSettings, IAudioFeatureRepository audioFeatureRepo, QuestionRepository questionRepository)
        {
            _model = new RecommendationModel();
            _model.Limit = 20;
            _questionRepository = questionRepository;
            _audioFeatureRepo = audioFeatureRepo;
            _model.Market = appSettings.Region;
        }

        public RecommendationModel CalculateFromQuestions(List<Answer> answers)
        {
            var recommendationList = new List<AnswerSetUp>();
            var audioFeatureList = new List<TunableTrack>();

            foreach (var answer in answers)
            {
                var id = int.Parse(answer.Id);

                var plus = _audioFeatureRepo.GetAudioFeature(
                    _questionRepository
                        .GetQuestion(id)
                        .ReferenceTrackPlus);

                var minus = _audioFeatureRepo.GetAudioFeature(
                    _questionRepository
                        .GetQuestion(id)
                        .ReferenceTrackMinus);

                var answerSetUp = new AnswerSetUp()
                {
                    Minus = minus,
                    Plus = plus,
                    Score = int.Parse(answer.Value)
                };

                recommendationList.Add(answerSetUp);
                var filteredValue = CalculateAudioFeatures(answerSetUp.Minus,answerSetUp.Plus,answerSetUp.Score);
                audioFeatureList.Add(filteredValue);
            }

            TunableTrack averageValue = new TunableTrack();

            for(int f = 0; f < audioFeatureList.Count - 1; f++)
            {
                averageValue = CalculateAudioFeatures(audioFeatureList[f], audioFeatureList[f + 1], 3);
                audioFeatureList[f] = averageValue;
            }

            //TODO make this part of interactive selection
            _model.GenreSeed = new List<string>()
            {
                "rock",
                "pop",
                "new age",
                "classical"
            };
            _model.Target = averageValue;
            return _model;
        }

        public RecommendationModel AddAudioFeaturesFromModels(AnswerSetUp answerSetUp)
        {
            _score = answerSetUp.Score;
            _model.Target = CalculateAudioFeatures(answerSetUp.Minus, answerSetUp.Plus, 3);
            return _model;
        }

        public RecommendationModel AddArtists(RecommendationModel model, List<string> artists)
        {
            _model = model;
            _model.ArtistSeed = artists;
            return _model;
        }

        public RecommendationModel AddGenres(RecommendationModel model, List<string> genres)
        {
            _model = model;
            _model.GenreSeed = genres;
            return _model;
        }


        private TunableTrack CalculateAudioFeatures(TunableTrack a, TunableTrack b, int score)
        {
            _score = score;
            return new TunableTrack()
            {
                Acousticness = WeightDiff(a.Acousticness, b.Acousticness),
                Danceability = WeightDiff(a.Danceability, b.Danceability),
                DurationMs = null,
                Energy = null, //WeightDiff(a.Energy, b.Energy),
                Instrumentalness = WeightDiff(a.Instrumentalness, b.Instrumentalness),
                Key = null,
                Liveness = null,    //WeightDiff(a.Liveness, b.Liveness),
                Loudness = null,    //WeightDiff(a.Loudness, b.Loudness),
                Popularity = null,
                Speechiness = null, //WeightDiff(a.Speechiness, b.Speechiness),
                Tempo = null,
                Valence = WeightDiff(a.Valence, b.Valence)
            };
        }
        

        private float? WeightDiff(float? a, float? b)
        {
            Random rnd = new Random();
            if (a == null)
                a = (float)rnd.Next(0,1)/10;
            if (b == null)
                b = (float)rnd.Next(0,1)/10;

            var difference = (float)Math.Abs((decimal)a - (decimal)b);
            difference /= 2.0f;
            switch (_score)
            {
                case 1:
                    return a;

                case 2:
                    return (a < b) ? a + difference : a - difference;

                case 3:
                    return difference * 2.0f;

                case 4:
                    return (b > a) ? b - difference : b + difference;

                case 5:
                    return b;
            }

            return null;
        }
        
    }
}
