using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonVR.Assets.Scripts.GameManagement.StateMachine
{
    public class Quitting : State
    {
        public override event EventHandler<State> ChangeStateRequestEvent;

        public Quitting(GameManager gameManager) : base(gameManager)
        {
        }
    }
}
