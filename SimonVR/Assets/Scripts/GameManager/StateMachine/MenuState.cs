using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonVR.Assets.Scripts.GameManager.StateMachine
{
    public class MenuState : State
    {
        public override event EventHandler<State> ChangeStateRequestEvent;

        public MenuState(GameManager gameManager) : base(gameManager)
        { }

    }
}
