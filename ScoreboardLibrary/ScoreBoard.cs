using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace ScoreboardLibrary
{
    public class ScoreBoard
    {
        private readonly List<PlayerScore> scoreList = new();
        private readonly string saveFile = "scoreboard.json";

        public List<PlayerScore> PlayerScores { get { return scoreList; } }

        public ScoreBoard()
        {
            Load(); // Ensure scores are loaded on initialization
        }

        public ScoreBoard(string saveFile)
        {
            this.saveFile = saveFile;
            Load(); // Ensure scores are loaded on initialization
        }

        public void AddPlayer(PlayerScore player)
        {
            scoreList.Add(player);
            SortScoreBoard(); // Sort the scoreboard after adding a new player
            Save(); // Save the scoreboard after adding a new player
        }

        public void AddPlayer(string player, int score)
        {
            scoreList.Add(new PlayerScore(player, score));
            SortScoreBoard(); // Sort the scoreboard after adding a new player
            Save(); // Save the scoreboard after adding a new player
        }

        public void SortScoreBoard()
        {
            PlayerScores.Sort((player1, player2) => player2.Score.CompareTo(player1.Score));
        }

        public void Clear(bool clearSaveFile = true)
        {
            scoreList.Clear();
            if (clearSaveFile)
                DeleteSaveFile();
        }

        private bool SaveFileExists()
        {
            return File.Exists(saveFile);
        }

        public void DeleteSaveFile()
        {
            if (SaveFileExists())
                File.Delete(saveFile);
        }

        public List<PlayerScore> Load()
        {
            scoreList.Clear();
            if (SaveFileExists())
            {
                using StreamReader reader = new(saveFile);
                string json = reader.ReadToEnd();
                var loadedScores = JsonSerializer.Deserialize<List<PlayerScore>>(json);
                if (loadedScores != null)
                {
                    scoreList.AddRange(loadedScores);
                }
            }
            return scoreList;
        }

        public void Save()
        {
            using StreamWriter writer = new(saveFile);
            writer.Write(JsonSerializer.Serialize(scoreList));
        }

        public override string ToString()
        {
            return $"Scoreboard: {string.Join(", ", scoreList)}";
        }
    }
}
