﻿using ScoreboardLibrary;
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
    public partial class ScoreboardWindow : Window
    {
        private ScoreBoard scoreboard;

        public ScoreboardWindow(ScoreBoard scoreboard)
        {
            InitializeComponent();
            this.scoreboard = scoreboard;
            LoadScoreboard();
        }

        private void LoadScoreboard()
        {
            try
            {
                scoreboard.Load();
                // Bind scoreboard data to UI controls here
                scoreboardPanel.Children.Clear();
                foreach (PlayerScore player in scoreboard.PlayerScores)
                {
                    TextBlock textBlock = new TextBlock
                    {
                        Text = player.ToString(),
                        // Set desired text style properties
                        FontSize = 20,
                        FontWeight = FontWeights.Bold,
                        Foreground = Brushes.White,
                        Margin = new Thickness(0, 20, 0, 0) // top margin of 30
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