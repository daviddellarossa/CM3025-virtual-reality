using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonVR.Assets.Scripts.GameManagement.StateMachine
{
    /// <summary>
    /// State of GameManager.
    /// This state performs the actions (if any) before quitting a game.
    /// </summary>
    public class Quitting : State
    {
        /// <inheritdoc/>
        public override event EventHandler<State> ChangeStateRequestEvent;

        /// <summary>
        /// Constructor for the class.
        /// </summary>
        /// <param name="gameManager">Reference to the Game Manager.</param>
        public Quitting(GameManager gameManager) : base(gameManager)
        {
        }
    }
}
