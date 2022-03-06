using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonVR.Assets.Scripts.AppManagement.StateMachine
{
    /// <summary>
    /// State of AppManager. This state controls the Pause state.
    /// </summary>
    public class PauseState : State
    {

        /// <summary>
        /// Constructor for the class.
        /// </summary>
        /// <param name="appManager">Reference to the AppManager.</param>
        public PauseState(AppManager appManager) : base(appManager)
        { }

        /// <inheritdoc/>
        public override event EventHandler<State> ChangeStateRequestEvent;
    }
}
