using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimonVR.Assets.Scripts.GameManagement
{
    public class DisplayPanel : MonoBehaviour
    {
        [SerializeField]
        private Material materialOff;
        [SerializeField]
        private Material materialOn;

        private Renderer renderer;
        private AudioSource audioSource;

        public int PanelId;

        private void Awake()
        {
            renderer = GetComponent<Renderer>();
            audioSource = GetComponent<AudioSource>();
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
