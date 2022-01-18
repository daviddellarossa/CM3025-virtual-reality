using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace SimonVR.Assets.Scripts.ScoreManagement
{
    public class ScoreManager : MonoBehaviour, IScoreManager
    {
        public Score CurrentScore;
        public HighScoreRecorder HighScores;

        [SerializeField]
        private GameObject HighScoreDisplayGO;
        [SerializeField]
        private GameObject ScoreDisplayGO;

        private TextMeshProUGUI ScoreDisplay;
        private TextMeshProUGUI HighScoreDisplay;

        

        void Start()
        {
            ScoreDisplay = ScoreDisplayGO.GetComponent<TextMeshProUGUI>();
            HighScoreDisplay = HighScoreDisplayGO.GetComponent<TextMeshProUGUI>();

            ResetCurrentScore();
            UpdateHighScorePanel();
            //Valve.VR.SteamVR.instance.overlay.ShowKeyboard(0, 0, "Description", 256, "", true);
        }

        private void UpdateHighScorePanel()
        {
            if(HighScoreDisplay != null)
            {
                var highScore = HighScores.HighScores.OrderByDescending(x => x.Value).FirstOrDefault();
                HighScoreDisplay.text = highScore?.Value.ToString() ?? "0";
            }
        }

        private void UpdateScorePanel(Score score)
        {
            if (ScoreDisplay != null)
            {
                ScoreDisplay.text = score.Value.ToString();
            }
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
            UpdateHighScorePanel();
        }

        public void AddToScore(int score)
        {
            CurrentScore.Value += score;
            Debug.Log($"Adding score {score}");
            UpdateScorePanel(CurrentScore);
        }

        public void ResetCurrentScore()
        {
            CurrentScore = new Score();
            UpdateScorePanel(CurrentScore);
        }

        public void ResetHighScore()
        {
            HighScores.HighScores.Clear();
            UpdateHighScorePanel();
        }
    }
}
