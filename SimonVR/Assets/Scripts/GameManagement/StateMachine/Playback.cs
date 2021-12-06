using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimonVR.Assets.Scripts.GameManagement.StateMachine
{
    public class Playback : PlaySubState
    {
        public override event EventHandler<PlaySubState> ChangeStateRequestEvent;
        public Playback(Play parentState, int level) : base(parentState, level)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            var sequence = ParentState.SequenceGenerator.GetSequence(Level);

            ParentState.GameManager.StartCoroutine(StartPlayIteration(sequence));
        }

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

            ChangeStateRequestEvent?.Invoke(this, new UserInput(this.ParentState, Level, sequence));
        }
    }
}
