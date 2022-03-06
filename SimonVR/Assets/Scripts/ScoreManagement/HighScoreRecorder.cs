using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimonVR.Assets.Scripts.ScoreManagement
{
    /// <summary>
    /// Stores persistently the list of high scores.
    /// </summary>
    [CreateAssetMenu(fileName = "High score", menuName = "Score/High Score")]
    public class HighScoreRecorder : ScriptableObject
    {
        /// <summary>
        /// List of high scores.
        /// </summary>
        public List<Score> HighScores;
    }
}
