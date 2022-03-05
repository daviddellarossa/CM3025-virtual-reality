using System;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace SimonVR.Assets.Scripts.GameManagement
{
    /// <summary>
    /// A button on the user console.
    /// </summary>
    public class Button : MonoBehaviour
    {
        /// <summary>
        /// Material for when the button is switched off.
        /// </summary>
        [SerializeField]
        private Material materialOff;

        /// <summary>
        /// Material for when the button is switched off.
        /// </summary>
        [SerializeField]
        private Material materialOn;

        private Renderer renderer;
        private Interactable interactable;
        private AudioSource audioSource;

        public int ButtonId;
        public bool IsButtonActive;

        /// <summary>
        /// Notify observers when the Button is down.
        /// </summary>
        public event Action<Button> ButtonDownEvent;

        /// <summary>
        /// Notify observers when the Button is up.
        /// </summary>
        public event Action<Button> ButtonUpEvent;

        /// <summary>
        /// Set the button active/non active.
        /// </summary>
        /// <param name="isActive"></param>
        public void SetActive(bool isActive)
        {
            IsButtonActive = isActive;
            interactable.highlightOnHover = isActive;
        }

        private void Awake()
        {
            // Set references to components.
            renderer = GetComponentInChildren<Renderer>();
            interactable = GetComponent<Interactable>();
            audioSource = GetComponent<AudioSource>();
        }
        
        /// <summary>
        /// Event handler for Button down event.
        /// </summary>
        /// <param name="fromHand">Hand controller generating the event.</param>
        public void OnButtonDown(Hand fromHand)
        {
            if (!IsButtonActive) return;
            TurnOn();
            fromHand.TriggerHapticPulse(1000);
            ButtonDownEvent?.Invoke(this);
        }

        /// <summary>
        /// Event handler for Button up event.
        /// </summary>
        /// <param name="fromHand">Hand controller generating the event.</param>
        public void OnButtonUp(Hand fromHand)
        {
            if(!IsButtonActive) return;
            TurnOff();
            ButtonUpEvent?.Invoke(this);
        }

        /// <summary>
        /// Turn on the button.
        /// </summary>
        public void TurnOn()
        {
            renderer.material = materialOn;
            audioSource.Play();
        }

        /// <summary>
        /// Turn off the button.
        /// </summary>
        public void TurnOff()
        {
            renderer.material = materialOff;
            audioSource.Stop();
        }

    }
}
