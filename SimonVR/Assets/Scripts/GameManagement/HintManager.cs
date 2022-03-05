using System;
using TMPro;
using UnityEngine;

namespace SimonVR.Assets.Scripts.GameManagement
{
    /// <summary>
    /// This object manages the display of information on the Console panel.
    /// </summary>
    public class HintManager : MonoBehaviour
    {
        /// <summary>
        /// Reference to the Hint Header game object.
        /// </summary>
        [SerializeField]
        private GameObject HintHeaderGO;

        /// <summary>
        /// Reference to the Hint Text game object.
        /// </summary>
        [SerializeField]
        private GameObject HintGO;

        /// <summary>
        /// Reference to the Hint Header object.
        /// </summary>
        private TextMeshProUGUI HintHeader;

        /// <summary>
        /// Reference to the Hint Text Object.
        /// </summary>
        private TextMeshProUGUI Hint;

        private void Awake()
        {
            // Initialize the Hint objects.
            HintHeader = HintHeaderGO.GetComponent<TextMeshProUGUI>();
            Hint = HintGO.GetComponent<TextMeshProUGUI>();
        }

        void start()
        {
            // Set the initial text to empty.
            Hint.text = String.Empty;
        }

        /// <summary>
        /// Display a text on the hint text element.
        /// </summary>
        /// <param name="text">Text to display.</param>
        public void DisplayText(string text)
        {
            Hint.text = text;
        }
    }
}
