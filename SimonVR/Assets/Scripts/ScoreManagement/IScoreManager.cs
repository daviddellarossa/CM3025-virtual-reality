using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonVR.Assets.Scripts.ScoreManagement
{
    /// <summary>
    /// Manager of the player's score
    /// </summary>
    public interface IScoreManager
    {
        /// <summary>
        /// Add a score to the high score list.
        /// </summary>
        void AddToHighScore();
        
        /// <summary>
        /// Add score to the current score.
        /// </summary>
        /// <param name="score">Score to add to the current score.</param>
        void AddToScore(int score);
        
        /// <summary>
        /// Reset the current score to 0.
        /// </summary>
        void ResetCurrentScore();

        /// <summary>
        /// Reset the high score list.
        /// </summary>
        void ResetHighScore();

    }
}
