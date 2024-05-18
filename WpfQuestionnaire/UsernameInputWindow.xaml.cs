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
        public string Username { get; private set; }
        private int correctAnswerCount;

        public UsernameInputWindow(int correctAnswerCount)
        {
            InitializeComponent();
            this.correctAnswerCount = correctAnswerCount;
            correctAnswersTextBlock.Text = $"You answered {correctAnswerCount} questions correctly.";
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            // Check if the username is not null, empty, or whitespace
            if (!string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                // Check if the length of the username is within the allowed limit (20 characters)
                if (txtUsername.Text.Length <= 25)
                {
                    Username = txtUsername.Text;
                    DialogResult = true;
                    this.Close();
                }
                else
                {
                    // Show an error message if the username exceeds the maximum length
                    MessageBox.Show("Username cannot exceed 25 characters.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                // Show an error message if the username is empty
                MessageBox.Show("Please enter a valid username.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}