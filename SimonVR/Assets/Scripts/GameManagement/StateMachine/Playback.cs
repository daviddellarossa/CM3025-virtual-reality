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
    /// This state controls when the sequence is played back.
    /// </summary>
    public class Playback : PlaySubState
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
        public Playback(Play parentState, int level) : base(parentState, level)
        {
        }

        /// <inheritdoc/>
        public override void OnEnter()
        {
            base.OnEnter();

            var sequenceLength = (int)Mathf.Sqrt(Level);
            var sequence = ParentState.SequenceGenerator.GetSequence(sequenceLength);

            this.ParentState.GameManager.HintManager.DisplayText("Wait for the sound sequence to complete");

            ParentState.GameManager.StartCoroutine(StartPlayIteration(sequence));
        }

        /// <summary>
        /// Coroutine that executes the sequence.
        /// </summary>
        /// <param name="sequence">Sequence to execute.</param>
        /// <returns>Nothing.</returns>
        private IEnumerator StartPlayIteration(Sequence sequence)
        {
            Debug.Log("StartPlayIteration coroutine started");

            for (int i = 0; i < sequence.Count; ++i)
            {
                if(sequence[i].InitialPad > 0)
                {
                    yield return new WaitForSeconds(sequence[i].InitialPad);
                }

                ParentState.GameManager.PanelsManager.SwitchPanelOn(sequence[i].Value);

                yield return new WaitForSeconds(sequence[i].Duration);

                ParentState.GameManager.PanelsManager.SwitchPanelOff(sequence[i].Value);

                if (sequence[i].FinalPad > 0)
                {
                    yield return new WaitForSeconds(sequence[i].FinalPad);
                }
            }
            yield return null;

           this.ParentState.GameManager.StartCoroutine(CoChangeState(new UserInput(this.ParentState, Level, sequence)));
        }

        /// <summary>
        /// Coroutine that manages a change in state.
        /// </summary>
        /// <param name="state">New state.</param>
        /// <returns></returns>
        protected IEnumerator CoChangeState(PlaySubState state)
        {
            if(ChangeStateDelay > 0)
            {
                yield return new WaitForSeconds(ChangeStateDelay);
            }

            ChangeStateRequestEvent?.Invoke(this, state);
        }
    }
}
