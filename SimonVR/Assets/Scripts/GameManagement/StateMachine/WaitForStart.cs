using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimonVR.Assets.Scripts.GameManagement.StateMachine
{
    public class WaitForStart : State
    {
        public override event EventHandler<State> ChangeStateRequestEvent;

        public virtual float ChangeStateDelay { get; set; } = 2;

        public WaitForStart(GameManager gameManager) : base(gameManager)
        {
        }

        public override void OnEnter()
        {
            this.GameManager.HintManager.DisplayText("Press right trigger to start a new game");
            base.OnEnter();
        }

        public override void OnRightTriggerPressed()
        {
            base.OnRightTriggerPressed();
            this.GameManager.HintManager.DisplayText("Starting...");

            this.GameManager.StartCoroutine(CoChangeState(new Play(GameManager)));
        }

        protected IEnumerator CoChangeState(State state)
        {
            yield return new WaitForSeconds(ChangeStateDelay);
            ChangeStateRequestEvent?.Invoke(this, state);

        }

    }
}
