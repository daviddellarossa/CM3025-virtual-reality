using System;
using UnityEngine;

namespace SimonVR.Assets.Scripts.AppManagement.StateMachine
{
    public abstract class State
    {
        public abstract event EventHandler<State> ChangeStateRequestEvent;
        public AppManager GameManager { get; protected set; }

        public State(AppManager gameManager)
        {
            GameManager = gameManager;
        }

        public virtual void OnEnter()
        {
            Debug.Log($"Entering { GetType().Name} state");
        }

        public virtual void OnExit()
        {
            Debug.Log($"Exiting { GetType().Name} state");
        }
    }
}
