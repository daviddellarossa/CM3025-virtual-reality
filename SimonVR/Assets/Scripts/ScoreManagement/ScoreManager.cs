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
        /// <summary>
        /// Gets or sets the current score.
        /// </summary>
        public Score CurrentScore;

        /// <summary>
        /// Reference to the high score recorder.
        /// </summary>
        public HighScoreRecorder HighScores;

        /// <summary>
        /// Reference to the High score display game object.
        /// </summary>
        [SerializeField]
        private GameObject HighScoreDisplayGO;

        /// <summary>
        /// Reference to the Score display game object.
        /// </summary>
        [SerializeField]
        private GameObject ScoreDisplayGO;

        /// <summary>
        /// Reference to the High score list of names' game object.
        /// </summary>
        [SerializeField]
        private GameObject HighScoreListNamesGO;

        /// <summary>
        /// Reference to the High score list of values' game object.
        /// </summary>
        [SerializeField]
        private GameObject HighScoreListValuesGO;

        /// <summary>
        /// Reference to the TextMeshPro controller for score.
        /// </summary>
        private TextMeshProUGUI ScoreDisplay;

        /// <summary>
        /// Reference to the TextMeshPro controller for high score.
        /// </summary>
        private TextMeshProUGUI HighScoreDisplay;

        /// <summary>
        /// Reference to the TextMeshPro controller for high score list of names.
        /// </summary>
        private TextMeshProUGUI HighScoreListNames;

        /// <summary>
        /// Reference to the TextMeshPro controller for high score list of values.
        /// </summary>
        private TextMeshProUGUI HighScoreListValues;

        /// <summary>
        /// Length of the high score list
        /// </summary>
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

        /// <summary>
        /// Update the high score panel.
        /// </summary>
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

        /// <summary>
        /// Update the score panel.
        /// </summary>
        /// <param name="score">The score to display on the panel.</param>
        private void UpdateScorePanel(Score score)
        {
            if (ScoreDisplay != null)
            {
                ScoreDisplay.text = score.Value.ToString();
            }
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public void AddToScore(int score)
        {
            CurrentScore.Value += score;
            Debug.Log($"Adding score {score}");
            UpdateScorePanel(CurrentScore);
        }

        /// <inheritdoc/>
        public void ResetCurrentScore()
        {
            CurrentScore = new Score();
            UpdateScorePanel(CurrentScore);
        }

        /// <inheritdoc/>
        public void ResetHighScore()
        {
            HighScores.HighScores.Clear();
            UpdateHighScorePanel();
        }
    }
}
