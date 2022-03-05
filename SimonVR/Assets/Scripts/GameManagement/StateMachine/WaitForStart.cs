using System;
using System.Collections;
using UnityEngine;

namespace SimonVR.Assets.Scripts.GameManagement.StateMachine
{
    /// <summary>
    /// State of GameManager.
    /// This state controls the phase of the game before starting a match.
    /// </summary>
    public class WaitForStart : State
    {
        /// <inheritdoc/>
        public override event EventHandler<State> ChangeStateRequestEvent;

        /// <summary>
        /// Gets or sets the delay in seconds during a change of state.
        /// </summary>
        public virtual float ChangeStateDelay { get; set; } = 2;

        /// <summary>
        /// Constructor for the class
        /// </summary>
        /// <param name="gameManager">Reference to the game manager.</param>
        public WaitForStart(GameManager gameManager) : base(gameManager)
        {
        }

        /// <inheritdoc/>
        public override void OnEnter()
        {
            this.GameManager.HintManager.DisplayText("Press right trigger to start a new game");
            base.OnEnter();
        }

        /// <summary>
        /// Event handler for a right trigger click.
        /// </summary>
        public override void OnRightTriggerPressed()
        {
            base.OnRightTriggerPressed();
            this.GameManager.HintManager.DisplayText("Starting...");

            this.GameManager.StartCoroutine(CoChangeState(new Play(GameManager)));
        }

        /// <summary>
        /// Coroutine that manages the state change.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        protected IEnumerator CoChangeState(State state)
        {
            yield return new WaitForSeconds(ChangeStateDelay);
            ChangeStateRequestEvent?.Invoke(this, state);
        }
    }
}
