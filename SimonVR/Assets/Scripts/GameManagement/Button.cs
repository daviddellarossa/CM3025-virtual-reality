using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace SimonVR.Assets.Scripts.GameManagement
{
    public class Button : MonoBehaviour
    {
        [SerializeField]
        private Material materialOff;
        [SerializeField]
        private Material materialOn;

        private Renderer renderer;
        private Interactable interactable;
        private AudioSource audioSource;

        public int ButtonId;
        public bool IsButtonActive;

        public event Action<Button> ButtonDownEvent;
        public event Action<Button> ButtonUpEvent;

        public void SetActive(bool isActive)
        {
            IsButtonActive = isActive;
            interactable.highlightOnHover = isActive;
        }

        private void Awake()
        {
            renderer = GetComponentInChildren<Renderer>();
            interactable = GetComponent<Interactable>();
            audioSource = GetComponent<AudioSource>();
        }

        public void OnButtonDown(Hand fromHand)
        {
            if (!IsButtonActive) return;
            TurnOn();
            fromHand.TriggerHapticPulse(1000);
            ButtonDownEvent?.Invoke(this);
        }

        public void OnButtonUp(Hand fromHand)
        {
            if(!IsButtonActive) return;
            TurnOff();
            ButtonUpEvent?.Invoke(this);
        }


        public void TurnOn()
        {
            renderer.material = materialOn;
            audioSource.Play();
        }
        public void TurnOff()
        {
            renderer.material = materialOff;
            audioSource.Stop();
        }

    }
}
