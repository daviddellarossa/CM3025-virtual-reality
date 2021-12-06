using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonVR.Assets.Scripts.GameManagement.StateMachine
{
    public class UserInput : PlaySubState
    {
        public override event EventHandler<PlaySubState> ChangeStateRequestEvent;

        public Sequence Sequence {  get; protected set; }
        public UserInput(Play parentState, int level, Sequence sequence) : base(parentState, level)
        {
            this.Sequence = sequence;
        }
    }
}
