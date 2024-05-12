using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ScoreboardLibrary;

namespace WpfQuestionnaire
{
    public partial class UsernameInputWindow : Window
    {
        private int correctAnswerCount;

        public string Username { get; private set; }

        public UsernameInputWindow(int correctAnswerCount)
        {
            InitializeComponent();
            this.correctAnswerCount = correctAnswerCount;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            Username = txtUsername.Text;

            // Call the method in ScoreboardLibrary to add the username and score
            ScoreboardLibrary.ScoreBoard scoreboard = new ScoreboardLibrary.ScoreBoard();
            scoreboard.AddPlayer(Username, correctAnswerCount);

            DialogResult = true;

            // Close the UsernameInputWindow
            Close();
        }
    }
}

