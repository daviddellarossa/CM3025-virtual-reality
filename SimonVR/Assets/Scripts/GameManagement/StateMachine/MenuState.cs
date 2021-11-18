using System;

namespace SimonVR.Assets.Scripts.GameManagement.StateMachine
{
    public class MenuState : State
    {
        public override event EventHandler<State> ChangeStateRequestEvent;

        public MenuState(GameManagement.GameManager gameManager) : base(gameManager)
        { }

    }
}
