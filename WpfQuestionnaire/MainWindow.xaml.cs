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
using System.Diagnostics.Eventing.Reader;
using System.Windows.Media.Animation;

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

            // Initialize and load the scoreboard
            scoreboard = new ScoreBoard();
            scoreboard.Load(); // Load existing scores

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
                ShowUsernameInputDialog();
            }
        }

        private void ShowUsernameInputDialog()
        {
            UsernameInputWindow usernameWindow = new UsernameInputWindow(correctAnswerCount);
            if (usernameWindow.ShowDialog() == true)
            {
                string username = usernameWindow.Username;
                ProcessScore(username);

                // Display the scoreboard window with the existing scoreboard instance
                ScoreboardWindow scoreboardWindow = new ScoreboardWindow(scoreboard);
                scoreboardWindow.Show();
            }
        }


        private void ProcessScore(string username)
        {
            scoreboard.AddPlayer(username, correctAnswerCount);
            scoreboard.Save(); // Save the scoreboard data
        }

        private void ShowScoreboard()
        {
            scoreboard.Load();
            scoreboard.SortScoreBoard();
        }

        public void ProcessQuestion(TriviaMultipleChoiceQuestion question)
        {
            if (question != null)
            {
                questions.Add(question);
                if (questions.Count == 1) // Present the first question immediately
                {
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
                questions.RemoveAt(0);

                // Update the questions_left TextBlock
                questions_left.Text = $"Question: {questionCount + 1}/10";

                // Update the questionTextBlock and answer buttons
                questionTextBlock.Text = currentQuestion.Question.Text;
                List<string> allAnswers = new List<string>(currentQuestion.IncorrectAnswers)
                {
                    currentQuestion.CorrectAnswer
                };
                allAnswers = ShuffleAnswers(allAnswers);

                AnswerA.Content = allAnswers[0];
                AnswerB.Content = allAnswers[1];
                AnswerC.Content = allAnswers[2];
                AnswerD.Content = allAnswers[3];
            }
        }

        private List<string> ShuffleAnswers(List<string> answers)
        {
            Random rnd = new Random();
            return answers.OrderBy(a => rnd.Next()).ToList();
        }

        private void HandleAnswerClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            string selectedAnswer = clickedButton.Content.ToString();
            string correctAnswer = currentQuestion.CorrectAnswer;

            if (selectedAnswer == correctAnswer)
            {
                CustomMessageBox.Show("Correct!", "You got the correct answer!");
                correctAnswerCount++;
            }
            else
            {
                CustomMessageBox.Show("Incorrect", "The right answer is: \n" + correctAnswer);
            }

            questionCount++;

            if (questionCount < 10)
            {
                FetchRandomQuestion();
                PresentQuestion();
            }
            else
            {
                ShowUsernameInputDialog();
            }
        }
    }
}