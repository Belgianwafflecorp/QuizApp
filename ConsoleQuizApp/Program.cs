
using QuestionnaireLibrary;
using ScoreboardLibrary;
using TriviaApiLibrary;
using ScoreboardLibrary;

namespace ConsoleQuizApp
{
    internal class Program
    {
        private static readonly int numberOfQuestions = 10;
        private static List<Question> questions = new();
        private static List<Answer> guesses = new();

        private class QuestionHandler : IQuestionHandler
        {
            public void ProcessQuestion(TriviaMultipleChoiceQuestion question)
            {
                Question newQuestion = new(question.Question.Text);
                newQuestion.Add(new Answer(question.CorrectAnswer, true));
                foreach (string incorrectAnswer in question.IncorrectAnswers)
                {
                    newQuestion.Add(new Answer(incorrectAnswer, false));
                }
                questions.Add(newQuestion);
            }
        }

        static void WelcomeMessage()
        {
            Console.Title = "Quiz App";
            Console.WriteLine("Welcome to the QUIZ APP!");
            Console.WriteLine("You will be presented with 10 questions.");
            Console.WriteLine("To answer type a, b, c or d and press enter.");
            Console.WriteLine("Will you be able to conquer the leaderboard?\n");
        }

        static async Task Main(string[] args)
        {
            WelcomeMessage();

            IQuestionHandler handler = new QuestionHandler();

            Task[] tasks = new Task[numberOfQuestions];
            for (int i = 0; i < numberOfQuestions; i++)
            {
                tasks[i] = TriviaApiRequester.RequestRandomQuestion(handler);
            }
            await Task.WhenAll(tasks);

            foreach (Question question in questions)
            {
                PromptQuestion(question, guesses);
            }

            Console.WriteLine("\nYou have answered all questions.");
            int score = questions.Count(q => q.Answers.Any(a => a.IsCorrect && guesses.Contains(a)));
            Console.WriteLine($"You have {score} out of {questions.Count} right.\n");
            Console.Write("Enter your name: ");
            string? name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Without a name you can't save your score.");
                Console.WriteLine("Goodbye.");
                return;
            }

            ScoreBoard scoreboard = new();
            scoreboard.Load();
            scoreboard.AddPlayer(name, score);
            scoreboard.SortScoreBoard();
            scoreboard.Save();

            Console.WriteLine($"Very well, {name}. You have been added to the scoreboard.\n");

            Console.WriteLine("Scoreboard:");
            foreach (PlayerScore player in scoreboard.PlayerScores)
            {
                Console.WriteLine($"{player.Player,10}: \t{player.Score}/{questions.Count}");
            }
        }

        static void PromptQuestion(Question question, List<Answer> guesses)
        {
            Console.WriteLine();
            DisplayQuestion(question);

            List<int> shuffledIndices = Enumerable.Range(0, question.Answers.Count).OrderBy(x => Guid.NewGuid()).ToList();

            for (int i = 0; i < shuffledIndices.Count; i++)
            {
                int index = shuffledIndices[i];
                Console.WriteLine($"{(char)('a' + i)}. {question.GetAnswer(index).Text}");
            }

            string userAnswer = Console.ReadLine()?.Trim().ToLower();
            int answerIndex = userAnswer switch
            {
                "a" => shuffledIndices[0],
                "b" => shuffledIndices[1],
                "c" => shuffledIndices[2],
                "d" => shuffledIndices[3],
                _ => -1
            };

            if (answerIndex >= 0 && answerIndex < question.Answers.Count)
            {
                guesses.Add(question.GetAnswer(answerIndex));
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a, b, c, or d.");
                PromptQuestion(question, guesses);
            }
        }

        static void DisplayQuestion(Question question)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(question.Text);
            Console.ResetColor();
        }
    }
}
