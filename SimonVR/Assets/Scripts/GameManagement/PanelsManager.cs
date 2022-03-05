using System.Linq;
using UnityEngine;

namespace SimonVR.Assets.Scripts.GameManagement
{
    /// <summary>
    /// Manager for the front panel.
    /// </summary>
    public class PanelsManager : MonoBehaviour
    {
        /// <summary>
        /// Collection of references to the display panels.
        /// </summary>
        private DisplayPanel[] panelsCollection;

        private void Start()
        {
            // Setup the panels collection
            var panels = GetComponentsInChildren<DisplayPanel>();
            panelsCollection = panels.OrderBy(x=>x.PanelId).ToArray();
        }

        /// <summary>
        /// Switch on a panel by Id.
        /// </summary>
        /// <param name="panelId"></param>
        public void SwitchPanelOn(int panelId)
        {
            panelsCollection[panelId].TurnOn();
        }

        /// <summary>
        /// Switch off a panel by Id.
        /// </summary>
        /// <param name="panelId"></param>
        public void SwitchPanelOff(int panelId)
        {
            panelsCollection[panelId].TurnOff();
        }
    }
}
