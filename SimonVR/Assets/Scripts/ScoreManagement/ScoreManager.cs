using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimonVR.Assets.Scripts.ScoreManagement
{
    public class ScoreManager : MonoBehaviour, IScoreManager
    {
        public Score CurrentScore;
        public HighScoreRecorder HighScores;

        void Start()
        {
            ResetCurrentScore();
        }


        public void AddToHighScore()
        {
            if(CurrentScore.Value == 0)
            {
                return;
            }
            CurrentScore.Date = DateTime.Now.ToString("s");
            CurrentScore.Name = "DDR";
            HighScores.HighScores.Add(CurrentScore);
        }

        public void AddToScore(int score)
        {
            CurrentScore.Value += score;
            Debug.Log($"Adding score {score}");
        }

        public void ResetCurrentScore()
        {
            CurrentScore = new Score();
        }

        public void ResetHighScore()
        {
            HighScores.HighScores.Clear();
        }
    }
}
