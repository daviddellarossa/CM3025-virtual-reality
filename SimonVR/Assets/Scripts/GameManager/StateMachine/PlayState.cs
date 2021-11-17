using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonVR.Assets.Scripts.GameManager.StateMachine
{
    public class PlayState : State
    {
        public PlayState(GameManager gameManager) : base(gameManager)
        { }

        public override event EventHandler<State> ChangeStateRequestEvent;
    }
}
