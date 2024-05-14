using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QuestionnaireLibrary;
using TriviaApiLibrary;
using ScoreboardLibrary;
using ConsoleQuizApp;

namespace WpfQuestionnaire
{
    public partial class MainWindow : Window, IQuestionHandler
    {
        private int questionCount;
        private int correctAnswerCount;
        private List<TriviaMultipleChoiceQuestion> questions;
        private TriviaMultipleChoiceQuestion currentQuestion;
        private ScoreBoard scoreboard;

        public MainWindow()
        {
            InitializeComponent();
            questionCount = 0;
            correctAnswerCount = 0;
            questions = new List<TriviaMultipleChoiceQuestion>();
            scoreboard = new ScoreBoard();
            FetchRandomQuestion();
        }

        private async void FetchRandomQuestion()
        {
            if (questionCount < 10)
            {
                await TriviaApiRequester.RequestRandomQuestion(this);
            }
            else
            {
                MessageBox.Show("All questions fetched. Calculating score...");
                ShowUsernameInputDialog();
            }
        }

        private void ShowUsernameInputDialog()
        {
            UsernameInputWindow usernameWindow = new UsernameInputWindow(correctAnswerCount);
            if (usernameWindow.ShowDialog() == true)
            {
                string username = usernameWindow.Username;
                // Process the username if needed
            }
        }


        private void ProcessScore(string username)
        {
            scoreboard.AddPlayer(username, correctAnswerCount);
            ShowScoreboard();
        }

        private void ShowScoreboard()
        {
            // Display the scoreboard using a new window or any other method you prefer
            MessageBox.Show(scoreboard.ToString());
        }

        public void ProcessQuestion(TriviaMultipleChoiceQuestion question)
        {
            if (question != null)
            {
                questions.Add(question);
                questionCount++;
                if (questionCount < 10)
                {
                    FetchRandomQuestion();
                }
                else
                {
                    // Start presenting questions to the user
                    PresentQuestion();
                }
            }
            else
            {
                MessageBox.Show("Failed to fetch question.");
            }
        }

        private void PresentQuestion()
        {
            // Present the first question to the user
            if (questions.Count > 0)
            {
                currentQuestion = questions[0];
                ProcessQuestion(currentQuestion);
                questions.RemoveAt(0);
            }
        }


        private void HandleAnswerClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            string selectedAnswer = clickedButton.Content.ToString();
            string correctAnswer = currentQuestion.CorrectAnswer;

            if (selectedAnswer == correctAnswer)
            {
                MessageBox.Show("Correct!");
                correctAnswerCount++; // Increment the correct answer count
            }

            else
            {
                MessageBox.Show("Incorrect. Try again!");
            }

            // Present the next question
            PresentQuestion();

        }

    }
}
