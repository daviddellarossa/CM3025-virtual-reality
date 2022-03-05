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
    /// This state controls the check of the user inputted sequence against the current sequence.
    /// </summary>
    public class CorrectAnswer : PlaySubState
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
        public CorrectAnswer(Play parentState, int level) : base(parentState, level)
        {
        }

        /// <inheritdoc/>
        public override void OnEnter()
        {
            base.OnEnter();
            this.ParentState.GameManager.HintManager.DisplayText("Nice! Selection correct");

            this.ParentState.GameManager.ScoreManager.AddToScore(1);
            this.ParentState.GameManager.StartCoroutine(CoChangeState(new Playback(ParentState, ++Level)));
        }

        /// <summary>
        /// Coroutine that manages a change in state.
        /// </summary>
        /// <param name="state">New state.</param>
        /// <returns></returns>
        protected IEnumerator CoChangeState(PlaySubState state)
        {
            yield return new WaitForSeconds(ChangeStateDelay);
            ChangeStateRequestEvent?.Invoke(this, state);
        }
    }
}
