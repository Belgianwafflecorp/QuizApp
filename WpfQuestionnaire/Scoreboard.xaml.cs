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
        public ScoreboardWindow(ScoreBoard scoreboard)
        {
            InitializeComponent();
            DisplayScores(scoreboard);
        }

        private void DisplayScores(ScoreBoard scoreboard)
        {
            scoreboard.SortScoreBoard();
            foreach (var player in scoreboard.PlayerScores)
            {
                TextBlock playerScore = new TextBlock
                {
                    Text = $"{player.Player}: {player.Score} points",
                    FontSize = 30,
                    Foreground = new SolidColorBrush(Color.FromRgb(224, 226, 219)),
                    Padding = new Thickness(40, 10, 40, 5)
                };
                scoreboardPanel.Children.Add(playerScore);
            }
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
