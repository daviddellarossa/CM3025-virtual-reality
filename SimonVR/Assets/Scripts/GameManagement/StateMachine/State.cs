using System;
using UnityEngine;

namespace SimonVR.Assets.Scripts.GameManagement.StateMachine
{
    /// <summary>
    /// Generic abstract state for GameManager
    /// </summary>
    public abstract class State
    {
        /// <summary>
        /// Event raised to invoke a change of state.
        /// </summary>
        public abstract event EventHandler<State> ChangeStateRequestEvent;

        /// <summary>
        /// Reference to the GameManager script.
        /// </summary>
        public GameManager GameManager { get; protected set; }

        /// <summary>
        /// Constructor for the class.
        /// </summary>
        /// <param name="gameManager"></param>
        public State(GameManager gameManager)
        {
            GameManager = gameManager;
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

        /// <summary>
        /// Event handler for a right trigger click.
        /// </summary>
        public virtual void OnRightTriggerPressed()
        {
            Debug.Log("Right Trigger pressed");
        }

    }
}
