using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonVR.Assets.Scripts.ScoreManagement
{
    /// <summary>
    /// Stores an instance of the score.
    /// </summary>
    [Serializable]
    public class Score
    {
        /// <summary>
        /// Value of the score.
        /// </summary>
        public int Value;

        /// <summary>
        /// Name of the player.
        /// </summary>
        public string Name;

        /// <summary>
        /// Date when the score was achieved.
        /// </summary>
        public string Date;
    }
}
