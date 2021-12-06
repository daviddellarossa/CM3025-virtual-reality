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

        public int PanelId;

        private void Start()
        {
            renderer = GetComponent<Renderer>();
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
