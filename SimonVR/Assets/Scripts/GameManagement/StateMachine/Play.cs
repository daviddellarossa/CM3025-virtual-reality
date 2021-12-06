using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonVR.Assets.Scripts.GameManagement.StateMachine
{
    public class Play : State
    {
        public override event EventHandler<State> ChangeStateRequestEvent;
        public PlaySubState CurrentState { get; protected set; }
        public SequenceGenerator SequenceGenerator { get; protected set; }

        public int CurrentLevel { get; protected set; }

        public Play(GameManager gameManager) : base(gameManager)
        {
            //TODO: Automate MaxValue
            SequenceGenerator = new SequenceGenerator(maxValue: 4, duration: 1, minValue: 0, finalPad: 0.4f);
            CurrentLevel = 1;

        }
        public override void OnEnter()
        {
            base.OnEnter();

            ChangeStateRequestEventHandler(this, new Playback(this, CurrentLevel));
        }

        protected void ChangeStateRequestEventHandler(object sender, PlaySubState state)
        {
            if (CurrentState != null)
            {
                CurrentState.ChangeStateRequestEvent -= ChangeStateRequestEventHandler;
                CurrentState.OnExit();
            }
            CurrentState = state;
            CurrentState.ChangeStateRequestEvent += ChangeStateRequestEventHandler;
            CurrentState.OnEnter();
        }
    }
}
