using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreboardLibrary
{
    public class ScoreBoard
    {

        private readonly List<PlayerScore> scoreList = new();
        private readonly string saveFile = "scoreboard.json";

        public List<PlayerScore> PlayerScores { get { return scoreList; } }

        public ScoreBoard() { }

        public ScoreBoard(string saveFile) { this.saveFile = saveFile; }

        public void AddPlayer(PlayerScore player)
        {
            scoreList.Add(player);
        }

        public void AddPlayer(string player, int score)
        {
            scoreList.Add(new PlayerScore(player, score));
        }

        public override string ToString()
        {
            return $"Scoreboard: {string.Join(", ", scoreList)}";
        }


    }
}
