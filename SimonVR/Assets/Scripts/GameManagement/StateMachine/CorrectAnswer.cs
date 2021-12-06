using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonVR.Assets.Scripts.GameManagement.StateMachine
{
    public class CorrectAnswer : PlaySubState
    {
        public override event EventHandler<PlaySubState> ChangeStateRequestEvent;

        public CorrectAnswer(Play parentState, int level) : base(parentState, level)
        {
        }

    }
}
