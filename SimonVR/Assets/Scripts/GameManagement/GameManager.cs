using SimonVR.Assets.Scripts.GameManagement.StateMachine;
using SimonVR.Assets.Scripts.ScoreManagement;
using System;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace SimonVR.Assets.Scripts.GameManagement
{
    /// <summary>
    /// Orchestrator of the game.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// A reference to the console game object.
        /// </summary>
        [SerializeField]
        private GameObject console;

        /// <summary>
        /// A reference to the Display panels game object.
        /// </summary>
        [SerializeField]
        private GameObject displayPanels;

        /// <summary>
        /// A reference to the sound manager game object.
        /// </summary>
        [SerializeField]
        private GameObject soundManager;

        /// <summary>
        /// A reference to the PanelsManager script
        /// </summary>
        public PanelsManager PanelsManager { get; protected set; }

        /// <summary>
        /// A reference to the ConsoleManager script.
        /// </summary>
        public ConsoleManager ConsoleManager { get; protected set; }

        /// <summary>
        /// A reference to the ScoreManager script.
        /// </summary>
        public ScoreManager ScoreManager { get; protected set; }

        /// <summary>
        /// A reference to the HintManager script.
        /// </summary>
        public HintManager HintManager { get; protected set; }

        /// <summary>
        /// The current state the GameManager is in.
        /// </summary>
        public State CurrentState { get; protected set; }

        private SteamVR_Behaviour_Boolean steamVR_Behaviour_Boolean;
        private IDictionary<SourceActionDelegateKey, Action<SourceActionDelegateKey>> sourceActionDelegates = new Dictionary<SourceActionDelegateKey, Action<SourceActionDelegateKey>>()
        {

        };
            
        private void Awake()
        {
            sourceActionDelegates.Add(new SourceActionDelegateKey(SteamVR_Input_Sources.RightHand, "/actions/default/in/InteractUI"), OnRightTriggerPressed);
        }

        void Start()
        {
            // Initialize the managers
            PanelsManager = displayPanels.GetComponent<PanelsManager>();
            ConsoleManager = console.GetComponent<ConsoleManager>();
            ScoreManager = GetComponent<ScoreManager>();
            HintManager = GetComponent<HintManager>();

            var steamVR_Behaviour_Boolean = GetComponent<SteamVR_Behaviour_Boolean>();
            steamVR_Behaviour_Boolean.onPressUpEvent += SteamVR_Behaviour_Boolean_onPressUpEvent;

            ChangeStateRequestEventHandler(this, new WaitForStart(this));
        }

        private void SteamVR_Behaviour_Boolean_onPressUpEvent(SteamVR_Behaviour_Boolean fromAction, SteamVR_Input_Sources fromSource)
        {
            var action = fromAction.booleanAction.fullPath;
            var actionSource = fromAction.booleanAction.activeDevice;

            Debug.Log($"Action detected: {action} from source {actionSource}");

            var key = new SourceActionDelegateKey(actionSource, action);
            if (sourceActionDelegates.ContainsKey(key))
            {
                sourceActionDelegates[key](key);
            }
        }

        /// <summary>
        /// Handler for a request to change current state.
        /// </summary>
        /// <param name="sender">The sender of the request.</param>
        /// <param name="e">The new state.</param>
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

        /// <summary>
        /// Handler for an event triggered when the player hits the right trigger.
        /// </summary>
        /// <param name="key"></param>
        protected void OnRightTriggerPressed(SourceActionDelegateKey key)
        {
            CurrentState.OnRightTriggerPressed();
        }
    }
}
