using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonVR.Assets.Scripts.ScoreManagement
{
    public interface IScoreManager
    {
        void AddToHighScore();
        void AddToScore(int score);
        void ResetCurrentScore();
        void ResetHighScore();

    }
}
