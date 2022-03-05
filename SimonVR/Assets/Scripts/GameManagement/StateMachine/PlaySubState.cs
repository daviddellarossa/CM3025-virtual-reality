using System;
using UnityEngine;

namespace SimonVR.Assets.Scripts.GameManagement.StateMachine
{
    /// <summary>
    /// Generic abstract state for a Play sub-state.
    /// </summary>
    public abstract class PlaySubState
    {
        /// <summary>
        /// Event raised to invoke a change of state.
        /// </summary>
        public abstract event EventHandler<PlaySubState> ChangeStateRequestEvent;

        /// <summary>
        /// Event raised to invoke an exit from the Play state.
        /// </summary>
        public abstract event EventHandler ExitPlayStateEvent;

        /// <summary>
        /// Gets or sets the delay to wait before changing state.
        /// </summary>
        public virtual float ChangeStateDelay { get; set; } = 2f;

        /// <summary>
        /// Parent state. Reference to Play state.
        /// </summary>
        public Play ParentState { get; protected set; }

        /// <summary>
        /// Current difficulty level.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Constructor of the class.
        /// </summary>
        /// <param name="parentState">Reference to the parent Play state.</param>
        /// <param name="level"></param>
        public PlaySubState(Play parentState, int level)
        {
            ParentState = parentState;
            Level = level;
        }

        /// <summary>
        /// Invoked when the state enters..
        /// </summary>
        public virtual void OnEnter()
        {
            Debug.Log($"Entering { GetType().Name} state");
        }

        /// <summary>
        /// Invoked when the state exits.
        /// </summary>
        public virtual void OnExit()
        {
            Debug.Log($"Exiting { GetType().Name} state");
        }
    }
}
