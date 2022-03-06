using SimonVR.Assets.Scripts.AppManagement.StateMachine;
using UnityEngine;

namespace SimonVR.Assets.Scripts.AppManagement
{
    /// <summary>
    /// Manage the overall lifecycle of the game.
    /// </summary>
    public class AppManager : MonoBehaviour
    {
        /// <summary>
        /// Gets or sets the current state for AppManager.
        /// </summary>
        public State CurrentState { get; private set; }

        void Start()
        {
            ChangeStateRequestEventHandler(this, new MenuState(this));
        }

        /// <summary>
        /// EventHandler for a request to change state.
        /// </summary>
        /// <param name="sender">The state sending the request.</param>
        /// <param name="e">The new state.</param>
        protected void ChangeStateRequestEventHandler(object sender, State e)
        {
            if (CurrentState != null)
            {
                CurrentState.ChangeStateRequestEvent -= ChangeStateRequestEventHandler;
                CurrentState.OnExit();
            }
            CurrentState = e;
            CurrentState.ChangeStateRequestEvent += ChangeStateRequestEventHandler;
            CurrentState.OnEnter();
        }
    }
}
