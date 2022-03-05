using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonVR.Assets.Scripts.GameManagement.StateMachine
{
    /// <summary>
    /// State of GameManager.
    /// This state controls when the player plays a match.
    /// It has a set of sub-states.
    /// </summary>
    public class Play : State
    {
        /// <inheritdoc/>
        public override event EventHandler<State> ChangeStateRequestEvent;
        public PlaySubState CurrentState { get; protected set; }
        public SequenceGenerator SequenceGenerator { get; protected set; }

        /// <summary>
        /// Gets or sets the current difficulty level.
        /// </summary>
        public int CurrentLevel { get; protected set; }

        /// <summary>
        /// Constructor for the class
        /// </summary>
        /// <param name="gameManager">Reference to the Game Manager.</param>
        public Play(GameManager gameManager) : base(gameManager)
        {
            SequenceGenerator = new SequenceGenerator(maxValue: 4, duration: 1, minValue: 0, finalPad: 0.4f);
            CurrentLevel = 1;
        }

        /// <inheritdoc/>
        public override void OnEnter()
        {
            base.OnEnter();

            this.GameManager.ScoreManager.ResetCurrentScore();

            ChangeStateRequestEventHandler(this, new Playback(this, CurrentLevel));
        }

        /// <inheritdoc/>
        public override void OnExit()
        {
            base.OnExit();

            this.GameManager.ScoreManager.AddToHighScore();
        }

        /// <summary>
        /// Event handler for a request of changing the current sub-state.
        /// </summary>
        /// <param name="sender">State raising the event.</param>
        /// <param name="state">New state.</param>
        protected void ChangeStateRequestEventHandler(object sender, PlaySubState state)
        {
            if (CurrentState != null)
            {
                CurrentState.ChangeStateRequestEvent -= ChangeStateRequestEventHandler;
                CurrentState.ExitPlayStateEvent -= ExitPlayStateEventHandler;
                CurrentState.OnExit();
            }
            CurrentState = state;
            CurrentState.ChangeStateRequestEvent += ChangeStateRequestEventHandler;
            CurrentState.ExitPlayStateEvent += ExitPlayStateEventHandler;
            CurrentState.OnEnter();
        }

        /// <summary>
        /// Event handler for a request of exiting the Play state.
        /// </summary>
        /// <param name="sender">State raising the event.</param>
        /// <param name="e">Empty eventhandler.</param>
        private void ExitPlayStateEventHandler(object sender, EventArgs e)
        {
            ChangeStateRequestEvent?.Invoke(this, new WaitForStart(this.GameManager));
        }
    }
}
