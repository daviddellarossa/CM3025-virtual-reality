using System;

namespace SimonVR.Assets.Scripts.GameManagement.StateMachine
{
    public class GameOverState : State
    {
        public GameOverState(GameManagement.GameManager gameManager) : base(gameManager)
        { }

        public override event EventHandler<State> ChangeStateRequestEvent;
    }
}
