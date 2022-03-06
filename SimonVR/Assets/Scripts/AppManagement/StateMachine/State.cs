using System;
using UnityEngine;

namespace SimonVR.Assets.Scripts.AppManagement.StateMachine
{

    /// <summary>
    /// Generic abstract state for AppManager
    /// </summary>
    public abstract class State
    {
        /// <summary>
        /// Event raised to invoke a change of state.
        /// </summary>
        public abstract event EventHandler<State> ChangeStateRequestEvent;

        /// <summary>
        /// Reference to the AppManager script.
        /// </summary>
        public AppManager AppManager { get; protected set; }

        /// <summary>
        /// Constructor for the class.
        /// </summary>
        /// <param name="appManager"></param>
        public State(AppManager appManager)
        {
            AppManager = appManager;
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
