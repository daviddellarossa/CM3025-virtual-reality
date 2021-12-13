using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimonVR.Assets.Scripts.GameManagement
{
    public class PanelsManager : MonoBehaviour
    {
        private DisplayPanel[] panelsCollection;

        private void Start()
        {
            var panels = GetComponentsInChildren<DisplayPanel>();
            panelsCollection = panels.OrderBy(x=>x.PanelId).ToArray();
        }
        public void SwitchPanelOn(int panelId)
        {
            panelsCollection[panelId].TurnOn();
        }
        public void SwitchPanelOff(int panelId)
        {
            panelsCollection[panelId].TurnOff();
        }
    }
}
