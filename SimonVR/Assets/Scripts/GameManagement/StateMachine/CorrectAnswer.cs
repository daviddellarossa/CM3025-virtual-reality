using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimonVR.Assets.Scripts.GameManagement.StateMachine
{
    public class CorrectAnswer : PlaySubState
    {
        public override event EventHandler<PlaySubState> ChangeStateRequestEvent;
        public override event EventHandler ExitPlayStateEvent;

        public virtual float ChangeStateDelay { get; set; } = 1;

        public CorrectAnswer(Play parentState, int level) : base(parentState, level)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            this.ParentState.GameManager.ScoreManager.AddToScore(1);
            this.ParentState.GameManager.StartCoroutine(CoChangeState(new Playback(ParentState, ++Level)));
        }

        protected IEnumerator CoChangeState(PlaySubState state)
        {
            yield return new WaitForSeconds(ChangeStateDelay);
            ChangeStateRequestEvent?.Invoke(this, state);
        }
    }
}
