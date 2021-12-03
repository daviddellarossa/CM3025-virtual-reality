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

        public uint CurrentLevel { get; protected set; }

        public Play(GameManager gameManager) : base(gameManager)
        {
            //TODO: Automate MaxValue
            SequenceGenerator = new SequenceGenerator(4, 1, 0);
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
