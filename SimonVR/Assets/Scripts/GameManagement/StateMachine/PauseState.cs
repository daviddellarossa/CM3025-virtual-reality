using System;

namespace SimonVR.Assets.Scripts.GameManagement.StateMachine
{
    public class PauseState : State
    {
        public PauseState(GameManagement.GameManager gameManager) : base(gameManager)
        { }

        public override event EventHandler<State> ChangeStateRequestEvent;
    }
}
