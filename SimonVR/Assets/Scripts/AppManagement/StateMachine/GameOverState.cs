using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonVR.Assets.Scripts.AppManagement.StateMachine
{
    /// <summary>
    /// State of AppManager. This state controls the Game over state.
    /// </summary>
    public class GameOverState : State
    {
        /// <summary>
        /// Constructor for the class.
        /// </summary>
        /// <param name="appManager">Reference to the AppManager.</param>
        public GameOverState(AppManager gameManager) : base(gameManager)
        { }

        /// <inheritdoc/>
        public override event EventHandler<State> ChangeStateRequestEvent;
    }
}
