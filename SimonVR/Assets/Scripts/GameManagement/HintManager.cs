using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace SimonVR.Assets.Scripts.GameManagement
{
    public class HintManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject HintHeaderGO;
        [SerializeField]
        private GameObject HintGO;

        private TextMeshProUGUI HintHeader;
        private TextMeshProUGUI Hint;

        private void Awake()
        {
            HintHeader = HintHeaderGO.GetComponent<TextMeshProUGUI>();
            Hint = HintGO.GetComponent<TextMeshProUGUI>();
        }

        void start()
        {
            Hint.text = String.Empty;
        }

        public void DisplayText(string text)
        {
            Hint.text = text;
        }

        public void DisplayAlert(string text)
        {

        }
    }
}
