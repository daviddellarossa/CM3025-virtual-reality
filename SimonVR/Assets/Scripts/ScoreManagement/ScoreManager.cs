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

        [SerializeField]
        private GameObject HighScoreListNamesGO;
        [SerializeField]
        private GameObject HighScoreListValuesGO;

        private TextMeshProUGUI ScoreDisplay;
        private TextMeshProUGUI HighScoreDisplay;
        private TextMeshProUGUI HighScoreListNames;
        private TextMeshProUGUI HighScoreListValues;

        [SerializeField] 
        [Range(1, 10)]
        private int HighScoreListLength = 5;
        

        void Start()
        {
            ScoreDisplay = ScoreDisplayGO.GetComponent<TextMeshProUGUI>();
            HighScoreDisplay = HighScoreDisplayGO.GetComponent<TextMeshProUGUI>();
            HighScoreListNames = HighScoreListNamesGO.GetComponent<TextMeshProUGUI>();
            HighScoreListValues = HighScoreListValuesGO.GetComponent<TextMeshProUGUI>();

            ResetCurrentScore();
            UpdateHighScorePanel();
            //Valve.VR.SteamVR.instance.overlay.ShowKeyboard(0, 0, "Description", 256, "", true);
        }

        private void UpdateHighScorePanel()
        {
            var highScores = HighScores.HighScores.OrderByDescending(x => x.Value).Take(3).ToArray();
            if (!highScores.Any())
            {
                HighScoreListNames.text = String.Empty;
                HighScoreListValues.text = String.Empty;
                return;

            }

            if (HighScoreDisplay != null)
            {
                var highScore = highScores.FirstOrDefault();
                HighScoreDisplay.text = highScore?.Value.ToString() ?? "0";
            }


            if (HighScoreListNames != null)
            {
                var names = String.Join("\n", highScores.Select(x => x.Name));

                HighScoreListNames.text = names;
            }

            if(HighScoreListValues != null)
            {
                var values = String.Join("\n", highScores.Select(x => x.Value));
                HighScoreListValues.text = values;
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
