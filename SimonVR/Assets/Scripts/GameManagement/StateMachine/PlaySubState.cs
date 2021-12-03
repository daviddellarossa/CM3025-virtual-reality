﻿using System;
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

        //public GameManager GameManager { get; set; }
        public Play ParentState { get; protected set; }

        public uint Level { get; set; }

        public PlaySubState(Play parentState, uint level)
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
