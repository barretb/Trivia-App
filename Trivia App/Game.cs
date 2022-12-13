using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Trivia_App
{
    public class Game
    {
        private Result[] _questions;
        public int TotalQuestions;
        public int CurrentQuestion;
        public int CurrentScore;

        public Game()
        {
            TotalQuestions = 5;
            CurrentQuestion = 0;
            CurrentScore = 0;
        }

        public async Task GetQuestions()
        {
            _questions = new Result[TotalQuestions];
            CurrentQuestion = 0;
            CurrentScore = 0;

            var uri = $"https://opentdb.com/api.php?amount={TotalQuestions}";
            var client = new HttpClient();
            var myJsonResponse = await client.GetFromJsonAsync<Root>(uri);

            if (myJsonResponse != null && myJsonResponse.results.Any())
            {
                _questions = myJsonResponse.results.ToArray();
            }
        }

        public Result GetCurrentQuestion()
        {
            CurrentQuestion++;
            return _questions[CurrentQuestion - 1];
        }
    }
}
