using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimonVR.Assets.Scripts.GameManagement.StateMachine
{
    public class UserInput : PlaySubState
    {
        public override event EventHandler<PlaySubState> ChangeStateRequestEvent;
        public override event EventHandler ExitPlayStateEvent;

        public Sequence Sequence {  get; protected set; }
        public Queue<SequenceStep> StepQueue { get; protected set; }
        public UserInput(Play parentState, int level, Sequence sequence) : base(parentState, level)
        {
            this.Sequence = sequence;
            this.StepQueue = new Queue<SequenceStep>(this.Sequence);
        }
        public override void OnEnter()
        {
            base.OnEnter();
            ParentState.GameManager.ConsoleManager.ButtonDownEvent += ConsoleManager_ButtonDownEvent;
            ParentState.GameManager.ConsoleManager.ButtonUpEvent += ConsoleManager_ButtonUpEvent;
            ParentState.GameManager.ConsoleManager.SetActive(true);

        }

        public override void OnExit()
        {
            base.OnExit();
            ParentState.GameManager.ConsoleManager.ButtonDownEvent -= ConsoleManager_ButtonDownEvent;
            ParentState.GameManager.ConsoleManager.ButtonUpEvent -= ConsoleManager_ButtonUpEvent;
            ParentState.GameManager.ConsoleManager.SetActive(false);
        }

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

        private void ConsoleManager_ButtonDownEvent(Button obj)
        {
        }

    }
}
