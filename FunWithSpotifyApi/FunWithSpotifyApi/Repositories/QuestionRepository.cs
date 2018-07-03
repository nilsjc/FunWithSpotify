using System.Collections.Generic;
using FunWithSpotifyApi.Models;

namespace FunWithSpotifyApi.Repositories
{
    public class QuestionRepository
    {
        private readonly List<QuestionHolder> _questions;

        public QuestionRepository()
        {
            _questions = new List<QuestionHolder>();
            AddQuestions();
        }

        public int Count => _questions.Count;

        public List<QuestionHolder> Questions()
        {
            return _questions;
        }

        private void AddQuestions()
        {
            _questions.Add(
                new QuestionHolder
                {
                    Id = 1,
                    Question = "Do you enjoy pictures of roadways in desert?",
                    ReferenceTrack = "Nebraska"
                });

            _questions.Add(
                new QuestionHolder
                {
                    Id = 2,
                    Question = "Do you care about gnomes?",
                    ReferenceTrack = "Smurfhits"
                });

            _questions.Add(
                new QuestionHolder
                {
                    Id=3,
                    Question = "Do you sometimes reflecting over the songs of the birds?",
                    ReferenceTrack = "New age"
                });

            _questions.Add(
                new QuestionHolder
                {
                    Id=4,
                    Question = "Is Whiskey much better than wine?",
                    ReferenceTrack = "Gunsroses"
                }
                );
        }
    }
}