using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimonVR.Assets.Scripts.GameManagement.StateMachine
{
    public abstract class State
    {
        public abstract event EventHandler<State> ChangeStateRequestEvent;

        public GameManager GameManager { get; protected set; }

        public State(GameManager gameManager)
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

        public virtual void OnRightTriggerPressed()
        {
            Debug.Log("Right Trigger pressed");
        }
    }
}
