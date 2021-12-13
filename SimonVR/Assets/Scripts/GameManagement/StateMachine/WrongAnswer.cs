using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonVR.Assets.Scripts.GameManagement.StateMachine
{
    public class WrongAnswer : PlaySubState
    {
        public override event EventHandler<PlaySubState> ChangeStateRequestEvent;
        public override event EventHandler ExitPlayStateEvent;

        public WrongAnswer(Play parentState, int level) : base(parentState, level)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            ExitPlayStateEvent?.Invoke(this, new EventArgs());
        }
    }
}
