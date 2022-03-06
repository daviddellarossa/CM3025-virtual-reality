using System;
using System.Linq;
using UnityEngine;

namespace SimonVR.Assets.Scripts.GameManagement
{
    /// <summary>
    /// Manager for the user console.
    /// </summary>
    public class ConsoleManager : MonoBehaviour
    {
        /// <summary>
        /// An array containing the buttons on the user console.
        /// </summary>
        private Button[] buttonsCollection;

        /// <summary>
        /// Event raised when a console button is pressed.
        /// </summary>
        public event Action<Button> ButtonDownEvent;

        /// <summary>
        /// Event raised when a console button is released.
        /// </summary>
        public event Action<Button> ButtonUpEvent;

        /// <summary>
        /// Enable/Disable the buttons.
        /// </summary>
        /// <param name="isActive"></param>
        public void SetActive(bool isActive)
        {
            foreach(var button in buttonsCollection)
            {
                button.SetActive(isActive);
            }
        }

        private void Awake()
        {
            // Setup the buttons collection
            var buttons = GetComponentsInChildren<Button>();
            buttonsCollection = buttons.OrderBy(x => x.ButtonId).ToArray();
        }

        private void Start()
        {
            // Setup the handlers for buttons' events.
            foreach(var button in buttonsCollection)
            {
                button.ButtonUpEvent += Button_ButtonUpEvent;
                button.ButtonDownEvent += Button_ButtonDownEvent;
            }

            SetActive(false);
        }

        /// <summary>
        /// Event handler for button down event.
        /// </summary>
        /// <param name="button"></param>
        private void Button_ButtonDownEvent(Button button)
        {
            ButtonDownEvent?.Invoke(button);
        }

        /// <summary>
        /// Event handler for button up event.
        /// </summary>
        /// <param name="button"></param>
        private void Button_ButtonUpEvent(Button button)
        {
            ButtonUpEvent?.Invoke(button);
        }
    }
}
