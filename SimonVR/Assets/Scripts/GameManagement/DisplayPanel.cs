using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimonVR.Assets.Scripts.GameManagement
{
    /// <summary>
    /// Script for display panels.
    /// </summary>
    public class DisplayPanel : MonoBehaviour
    {
        /// <summary>
        /// Material for when the Display panel is off.
        /// </summary>
        [SerializeField]
        private Material materialOff;

        /// <summary>
        /// Material for when the Display panel is on.
        /// </summary>
        [SerializeField]
        private Material materialOn;

        private Renderer renderer;
        private AudioSource audioSource;

        /// <summary>
        /// Id of the panel.
        /// </summary>
        public int PanelId;

        private void Awake()
        {
            // Set the references to components.
            renderer = GetComponent<Renderer>();
            audioSource = GetComponent<AudioSource>();
        }

        /// <summary>
        /// Turn the display panels on.
        /// </summary>
        public void TurnOn()
        {
            renderer.material = materialOn;
            audioSource.Play();

        }

        /// <summary>
        /// Turn the display panels off.
        /// </summary>
        public void TurnOff()
        {
            renderer.material = materialOff;
            audioSource.Stop();
        }
    }
}
