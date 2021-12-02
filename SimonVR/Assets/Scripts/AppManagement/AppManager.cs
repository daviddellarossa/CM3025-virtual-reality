using Codice.CM.Common;
using SimonVR.Assets.Scripts.AppManagement.StateMachine;
using UnityEngine;

namespace SimonVR.Assets.Scripts.AppManagement
{
    public class AppManager : MonoBehaviour
    {
        public State CurrentState { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            ChangeStateRequestEventHandler(this, new MenuState(this));
        }

        protected void ChangeStateRequestEventHandler(object sender, State e)
        {
            //Debug.Log($"Changing state from {sender} to {e}");
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
