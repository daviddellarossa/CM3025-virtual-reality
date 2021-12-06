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

        public int ButtonId;

        private void Start()
        {
            renderer = GetComponentInChildren<Renderer>();
        }

        public void OnButtonDown(Hand fromHand)
        {
            TurnOn();
            fromHand.TriggerHapticPulse(1000);
        }

        public void OnButtonUp(Hand fromHand)
        {
            TurnOff();
        }


        public void TurnOn()
        {
            renderer.material = materialOn;
        }
        public void TurnOff()
        {
            renderer.material = materialOff;
        }

    }
}
