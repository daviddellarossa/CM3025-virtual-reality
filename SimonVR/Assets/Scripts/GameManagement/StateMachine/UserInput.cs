using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimonVR.Assets.Scripts.GameManagement.StateMachine
{
    /// <summary>
    /// Sub-state for the Play state.
    /// This state controls when the user inputs the sequence.
    /// </summary>
    public class UserInput : PlaySubState
    {
        /// <inheritdoc/>
        public override event EventHandler<PlaySubState> ChangeStateRequestEvent;

        /// <inheritdoc/>
        public override event EventHandler ExitPlayStateEvent;
        
        /// <summary>
        /// Sequence to match.
        /// </summary>
        public Sequence Sequence {  get; protected set; }

        /// <summary>
        /// Input from the user.
        /// </summary>
        public Queue<SequenceStep> StepQueue { get; protected set; }

        /// <summary>
        /// Constructor for the class.
        /// </summary>
        /// <param name="parentState">The parent Play state.</param>
        /// <param name="level">The current Level.</param>
        /// <param name="sequence">The current sequence.</param>
        public UserInput(Play parentState, int level, Sequence sequence) : base(parentState, level)
        {
            this.Sequence = sequence;
            this.StepQueue = new Queue<SequenceStep>(this.Sequence);
        }

        /// <inheritdoc/>
        public override void OnEnter()
        {
            base.OnEnter();
            this.ParentState.GameManager.HintManager.DisplayText("Enter your sequence");

            ParentState.GameManager.ConsoleManager.ButtonDownEvent += ConsoleManager_ButtonDownEvent;
            ParentState.GameManager.ConsoleManager.ButtonUpEvent += ConsoleManager_ButtonUpEvent;
            ParentState.GameManager.ConsoleManager.SetActive(true);
        }

        /// <inheritdoc/>
        public override void OnExit()
        {
            base.OnExit();
            ParentState.GameManager.ConsoleManager.ButtonDownEvent -= ConsoleManager_ButtonDownEvent;
            ParentState.GameManager.ConsoleManager.ButtonUpEvent -= ConsoleManager_ButtonUpEvent;
            ParentState.GameManager.ConsoleManager.SetActive(false);
        }

        /// <summary>
        /// Event handler for the button up event raised by the ConsoleManager.
        /// </summary>
        /// <param name="obj">The button pressed.</param>
        private void ConsoleManager_ButtonUpEvent(Button obj)
        {
            Debug.Log($"User input detected: buttonId: {obj.ButtonId}");

            var step = StepQueue.Dequeue();
            if(step.Value != obj.ButtonId)
            {
                Debug.Log("Wrong answer!");
                ChangeStateRequestEvent(this, new WrongAnswer(ParentState, Level));
                return;
            }

            if(StepQueue.Count == 0)
            {
                Debug.Log("Correct answer");
                ChangeStateRequestEvent(this, new CorrectAnswer(ParentState, Level));
            }
        }

        /// <summary>
        /// Event handler for the button down event raised by the ConsoleManager.
        /// </summary>
        /// <param name="obj">The button pressed.</param>
        private void ConsoleManager_ButtonDownEvent(Button obj)
        {
        }

    }
}
