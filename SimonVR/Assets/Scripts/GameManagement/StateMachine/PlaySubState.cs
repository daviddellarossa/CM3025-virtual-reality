using System;
using System.Collections;
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
        public abstract event EventHandler ExitPlayStateEvent;

        public Play ParentState { get; protected set; }

        public int Level { get; set; }

        public PlaySubState(Play parentState, int level)
        {
            ParentState = parentState;
            Level = level;
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
