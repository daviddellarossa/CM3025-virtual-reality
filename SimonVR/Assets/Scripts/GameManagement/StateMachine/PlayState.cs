using System;

namespace SimonVR.Assets.Scripts.GameManagement.StateMachine
{
    public class PlayState : State
    {
        public PlayState(GameManagement.GameManager gameManager) : base(gameManager)
        { }

        public override event EventHandler<State> ChangeStateRequestEvent;
    }
}
