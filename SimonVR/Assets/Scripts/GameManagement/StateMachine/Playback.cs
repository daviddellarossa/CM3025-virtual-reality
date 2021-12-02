using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonVR.Assets.Scripts.GameManagement.StateMachine
{
    public class Playback : PlaySubState
    {
        public override event EventHandler<PlaySubState> ChangeStateRequestEvent;

        public Playback(GameManager gameManager) : base(gameManager)
        {
        }
    }
}
