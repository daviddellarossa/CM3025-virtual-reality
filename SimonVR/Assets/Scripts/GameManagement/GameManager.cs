using SimonVR.Assets.Scripts.GameManagement.StateMachine;
using System;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace SimonVR.Assets.Scripts.GameManagement
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject console;
        [SerializeField]
        private GameObject displayPanels;
        [SerializeField]
        private GameObject soundManager;

        public PanelsManager PanelsManager { get; protected set; }
        public ConsoleManager ConsoleManager { get; protected set; }
        public SoundManager SoundManager { get; protected set; }

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
            PanelsManager = displayPanels.GetComponent<PanelsManager>();
            ConsoleManager = console.GetComponent<ConsoleManager>();
            SoundManager = soundManager.GetComponent<SoundManager>();

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

        protected void OnRightTriggerPressed(SourceActionDelegateKey key)
        {
            CurrentState.OnRightTriggerPressed();
        }
    }

    public class SourceActionDelegateKey : IEquatable<SourceActionDelegateKey>
    {
        public SteamVR_Input_Sources Source { get; protected set; }
        public string Action { get; protected set; }


        public SourceActionDelegateKey(SteamVR_Input_Sources source, string action)
        {
            Source = source;
            Action = action;
        }


        public static bool operator ==(SourceActionDelegateKey obj1, SourceActionDelegateKey obj2)
        {
            if (ReferenceEquals(obj1, obj2))
            {
                return true;
            }
            if (ReferenceEquals(obj1, null))
            {
                return false;
            }
            if (ReferenceEquals(obj2, null))
            {
                return false;
            }

            return obj1.Equals(obj2);
        }

        public static bool operator !=(SourceActionDelegateKey obj1, SourceActionDelegateKey obj2) => !(obj1 == obj2);

        public bool Equals(SourceActionDelegateKey other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return (Source == other.Source && Action == other.Action);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SourceActionDelegateKey)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int)Source) ^ Action.GetHashCode();
            }
        }
    }
}
