using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimonVR.Assets.Scripts.GameManagement.StateMachine
{
    public class WrongAnswer : PlaySubState
    {
        public override event EventHandler<PlaySubState> ChangeStateRequestEvent;
        public override event EventHandler ExitPlayStateEvent;

        public virtual float ChangeStateDelay { get; set; } = 3;

        public WrongAnswer(Play parentState, int level) : base(parentState, level)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            this.ParentState.GameManager.HintManager.DisplayText("Ouch! Wrong selection! Game over");

            this.ParentState.GameManager.StartCoroutine(CoExitPlayState());
        }

        protected IEnumerator CoExitPlayState()
        {
            yield return new WaitForSeconds(ChangeStateDelay);
            ExitPlayStateEvent?.Invoke(this, new EventArgs());
        }

    }
}
