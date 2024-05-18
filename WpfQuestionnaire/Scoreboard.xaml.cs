using ScoreboardLibrary;
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

namespace WpfQuestionnaire
{
    public partial class ScoreboardWindow : Window
    {
        private ScoreboardLibrary.ScoreBoard scoreboard;

        public ScoreboardWindow()
        {
            InitializeComponent();
            scoreboard = new ScoreboardLibrary.ScoreBoard();
            LoadScoreboard();
        }

        private void LoadScoreboard()
        {
            try
            {
                scoreboard.Load();
                // Bind scoreboard data to UI controls here
                scoreboardPanel.Children.Clear();
                foreach (var playerScore in scoreboard.PlayerScores)
                {
                    TextBlock textBlock = new TextBlock
                    {
                        Text = playerScore.ToString(),
                        // Set desired text style properties
                        FontSize = 20,
                        FontWeight = FontWeights.Bold,
                        Foreground = Brushes.White,
                        Margin = new Thickness(0, 30, 0, 0) // Add a top margin of 30
                    };
                    scoreboardPanel.Children.Add(textBlock);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load scoreboard: {ex.Message}");
            }
        }


        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            // Close the application
            Application.Current.Shutdown();
        }

    }
}