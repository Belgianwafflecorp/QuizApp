
using TriviaApiLibrary;

namespace ConsoleQuizApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TriviaApiRequester Trivia = new TriviaApiRequester();

            Trivia.RequestRandomQuestion(IQuestionHandler handler);
        }
    }
}
