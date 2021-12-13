using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimonVR.Assets.Scripts.GameManagement
{
    public class ConsoleManager : MonoBehaviour
    {
        private Button[] buttonsCollection;

        public event Action<Button> ButtonDownEvent;
        public event Action<Button> ButtonUpEvent;

        public void SetActive(bool isActive)
        {
            foreach(var button in buttonsCollection)
            {
                button.SetActive(isActive);
            }
        }

        private void Awake()
        {
            var buttons = GetComponentsInChildren<Button>();
            buttonsCollection = buttons.OrderBy(x => x.ButtonId).ToArray();
        }

        private void Start()
        {
            //var buttons = GetComponentsInChildren<Button>();
            //buttonsCollection = buttons.OrderBy(x => x.ButtonId).ToArray();

            foreach(var button in buttonsCollection)
            {
                button.ButtonUpEvent += Button_ButtonUpEvent;
                button.ButtonDownEvent += Button_ButtonDownEvent;
            }

            SetActive(false);
        }

        

        private void Button_ButtonDownEvent(Button button)
        {
            ButtonDownEvent?.Invoke(button);
        }

        private void Button_ButtonUpEvent(Button button)
        {
            ButtonUpEvent?.Invoke(button);
        }
    }
}
