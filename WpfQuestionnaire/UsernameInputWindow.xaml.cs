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

        public UsernameInputWindow(int correctAnswerCount)
        {
            InitializeComponent();
            correctAnswersTextBlock.Text = $"You answered {correctAnswerCount} questions correctly.";
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                Username = txtUsername.Text;
                DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid username.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}