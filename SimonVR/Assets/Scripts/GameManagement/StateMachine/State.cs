using System;
using UnityEngine;

namespace SimonVR.Assets.Scripts.GameManagement.StateMachine
{
    public abstract class State
    {
        public abstract event EventHandler<State> ChangeStateRequestEvent;
        public GameManagement.GameManager GameManager { get; protected set; }

        public State(GameManagement.GameManager gameManager)
        {
            this.GameManager = gameManager;
        }

        public virtual void OnEnter()
        {
            Debug.Log($"Entering { this.GetType().Name} state");
        }

        public virtual void OnExit()
        {
            Debug.Log($"Exiting { this.GetType().Name} state");
        }
    }
}
