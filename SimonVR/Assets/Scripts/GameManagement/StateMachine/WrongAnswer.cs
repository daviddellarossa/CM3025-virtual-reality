using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimonVR.Assets.Scripts.GameManagement.StateMachine
{
    /// <summary>
    /// Sub-state for the Play state.
    /// This state controls when the user inputted sequence is incorrect.
    /// </summary>
    public class WrongAnswer : PlaySubState
    {
        /// <inheritdoc/>
        public override event EventHandler<PlaySubState> ChangeStateRequestEvent;

        /// <inheritdoc/>
        public override event EventHandler ExitPlayStateEvent;

        /// <summary>
        /// Constructor for the class.
        /// </summary>
        /// <param name="parentState">The parent Play state.</param>
        /// <param name="level">The current difficulty level.</param>
        public WrongAnswer(Play parentState, int level) : base(parentState, level)
        {
        }

        /// <inheritdoc/>
        public override void OnEnter()
        {
            base.OnEnter();
            this.ParentState.GameManager.HintManager.DisplayText("Ouch! Wrong selection! Game over");

            this.ParentState.GameManager.StartCoroutine(CoExitPlayState());
        }

        /// <summary>
        /// Coroutine that invokes an exit from the Play stae.
        /// </summary>
        /// <returns>Nothing.</returns>
        protected IEnumerator CoExitPlayState()
        {
            yield return new WaitForSeconds(ChangeStateDelay);
            ExitPlayStateEvent?.Invoke(this, new EventArgs());
        }

    }
}
