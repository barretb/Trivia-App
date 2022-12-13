using System.Net;
using Trivia_App;

Console.WriteLine("Hello, and welcome to our Trivia App!");

//setup game and get questions from the API
var game = new Game();
await game.GetQuestions();

Console.WriteLine("Are you ready to start?");
Console.ReadLine();

//iterate the questions
while (game.CurrentQuestion < game.TotalQuestions)
{
    var question = game.GetCurrentQuestion();

    //build our list of answers
    var strAnswers = new List<string>
    {
        WebUtility.HtmlDecode(question.correct_answer)
    };
    foreach (var item in question.incorrect_answers)
    {
        strAnswers.Add(WebUtility.HtmlDecode(item));
    }
    strAnswers.Shuffle();

    //build the answer output and store which one is correct
    var answers = new Dictionary<int, string>();
    int correct = 0;
    for (var i = 1; i <= strAnswers.Count; i++)
    {
        answers[i] = strAnswers[i - 1];
        if (string.Equals(strAnswers[i - 1], question.correct_answer)) { correct = i; }
    }
    var totalAnswers = strAnswers.Count;

    //ask our question and get the answer
    Console.WriteLine();
    Console.WriteLine("-------------------------------------");
    Console.WriteLine($"Question #{game.CurrentQuestion}");
    Console.WriteLine();
    Console.WriteLine(WebUtility.HtmlDecode(question.question));
    Console.WriteLine();
    for (var a = 1; a <= totalAnswers; a++)
    {
        Console.WriteLine($"{a}: {answers[a]}");
    }
    Console.Write("Please select number of the correct answer: ");
    var userKeyAnswer = Console.ReadLine();

    //check if the answer is correct and process result
    var userAnswer = 0;
    int.TryParse(userKeyAnswer, out userAnswer);
    if (userAnswer == correct && userAnswer != 0)
    {
        game.CurrentScore++;
        Console.WriteLine();
        Console.WriteLine("CORRECT!!!!!");
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Sorry, that's wrong!!!!!");
    }
}


//display final score
Console.WriteLine();
Console.WriteLine("-------------------------------------");
Console.WriteLine($"You final score: {game.CurrentScore} out of {game.TotalQuestions}");
Console.WriteLine("-------------------------------------");
Console.ReadLine();

