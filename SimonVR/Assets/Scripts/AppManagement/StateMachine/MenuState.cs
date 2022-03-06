using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonVR.Assets.Scripts.AppManagement.StateMachine
{
    /// <summary>
    /// State of AppManager. This state controls the Main Menu.
    /// </summary>
    public class MenuState : State
    {
        /// <inheritdoc/>
        public override event EventHandler<State> ChangeStateRequestEvent;

        /// <summary>
        /// Constructor for the class
        /// </summary>
        /// <param name="appManager">Reference to the AppManager.</param>
        public MenuState(AppManager appManager) : base(appManager)
        { }
    }
}
