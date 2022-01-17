using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimonVR.Assets.Scripts.ScoreManagement
{
    [CreateAssetMenu(fileName = "High score", menuName = "Score/High Score")]
    public class HighScoreRecorder : ScriptableObject
    {
        public List<Score> HighScores;
    }
}
