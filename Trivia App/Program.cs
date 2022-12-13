// See https://aka.ms/new-console-template for more information
using Trivia_App;

Console.WriteLine("Hello, and welcome to our Trivia App!");

//setup game and get questions from the API
var game = new Game();
await game.GetQuestions();

Console.WriteLine("Are you ready to start?");
Console.ReadLine();

while(game.CurrentQuestion < game.TotalQuestions)
{

}

