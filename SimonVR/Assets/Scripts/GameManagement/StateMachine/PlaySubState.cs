using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimonVR.Assets.Scripts.GameManagement.StateMachine
{
    public abstract class PlaySubState
    {
        public abstract event EventHandler<PlaySubState> ChangeStateRequestEvent;

        public GameManager GameManager { get; set; }

        public PlaySubState(GameManager gameManager)
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
