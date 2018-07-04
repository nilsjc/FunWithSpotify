using System.Collections.Generic;
using System.Linq;
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

        public QuestionHolder GetQuestion(int id)
        {
            return _questions.FirstOrDefault(x => x.Id == id);
        }

        private void AddQuestions()
        {
            _questions.Add(
                new QuestionHolder
                {
                    Id = 1,
                    Question = "Do you enjoy pictures of roadways in desert?",
                    ReferenceTrackPlus = "7GDIQqD5pdHCda5rpZ98Ie",
                    ReferenceTrackMinus = "5eqZWYQ5tbIehx00NeKXz7"
                });

            _questions.Add(
                new QuestionHolder
                {
                    Id = 2,
                    Question = "Do you care about gnomes?",
                    ReferenceTrackPlus = "5YW97EKh6V7LESoAAhal3e",
                    ReferenceTrackMinus = "7GDIQqD5pdHCda5rpZ98Ie"
                });

            _questions.Add(
                new QuestionHolder
                {
                    Id=3,
                    Question = "Do you sometimes reflecting over the songs of the birds?",
                    ReferenceTrackPlus = "3T5mKbl0S0dYwv7Ik4ffCp",
                    ReferenceTrackMinus = "7GDIQqD5pdHCda5rpZ98Ie"
                });

            _questions.Add(
                new QuestionHolder
                {
                    Id=4,
                    Question = "Is Whiskey much better than wine?",
                    ReferenceTrackPlus = "4g45LlqLS3TUoQkBCKvHFO",
                    ReferenceTrackMinus = "6H5YL4uoSBMiIDkhfKMbBl"
                }
                );

            _questions.Add(
                new QuestionHolder
                {
                    Id=5,
                    Question = "Lets go trucking? What do you think?",
                    ReferenceTrackPlus = "2zYzyRzz6pRmhPzyfMEC8s",
                    ReferenceTrackMinus = "3T5mKbl0S0dYwv7Ik4ffCp"
                }
                );

            _questions.Add(
                new QuestionHolder
                {
                    Id=6,
                    Question = "Do you avoid children´s party?",
                    ReferenceTrackPlus = "17CyJTMzvygZggYVVaZMH9",
                    ReferenceTrackMinus = "5YW97EKh6V7LESoAAhal3e"
                });

            _questions.Add(
                new QuestionHolder
                {
                    Id=7,
                    Question = "Rate New York!",
                    ReferenceTrackPlus = "5isA9icHWl2651hvfr1EOV",
                    ReferenceTrackMinus = "5eqZWYQ5tbIehx00NeKXz7"
                }
                );

            _questions.Add(
                new QuestionHolder
                {
                    Id=8,
                    Question = "Do you watch prison documentaries?",
                    ReferenceTrackPlus = "2zYzyRzz6pRmhPzyfMEC8s",
                    ReferenceTrackMinus = "3T5mKbl0S0dYwv7Ik4ffCp"
                }
                );
        }
    }
}