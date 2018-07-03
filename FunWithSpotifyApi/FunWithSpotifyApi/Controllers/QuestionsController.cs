using System;
using System.Linq;
using FunWithSpotifyApi.Models;
using FunWithSpotifyApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FunWithSpotifyApi.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly int _maxQuestionsInDb;
        private readonly QuestionRepository _repository;

        public QuestionsController(QuestionRepository repository)
        {
            _repository = repository;
            _maxQuestionsInDb = repository.Count;
        }

        [Route("/questions")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/questions/get")]
        public IActionResult GetQuestion()
        {
            return Json(QuestionGenerator(null));
        }

        [HttpPost]
        [Route("/questions/post")]
        public void Submit([FromBody] Answer answer)
        {

        }

        private QuestionHolder QuestionGenerator(int? lastQuestionId = 0)
        {
            var rnd = new Random();
            int id;

            do
            {
                id = rnd.Next(1, _maxQuestionsInDb);
            } while (id == lastQuestionId);

            var result = _repository.Questions().FirstOrDefault(q => q.Id == id);
            return result;
        }
    }
}