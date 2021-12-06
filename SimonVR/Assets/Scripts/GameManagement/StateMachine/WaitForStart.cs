using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonVR.Assets.Scripts.GameManagement.StateMachine
{
    public class WaitForStart : State
    {
        public override event EventHandler<State> ChangeStateRequestEvent;

        public WaitForStart(GameManager gameManager) : base(gameManager)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void OnRightTriggerPressed()
        {
            base.OnRightTriggerPressed();

            ChangeStateRequestEvent?.Invoke(this, new Play(GameManager));
        }
    }
}
