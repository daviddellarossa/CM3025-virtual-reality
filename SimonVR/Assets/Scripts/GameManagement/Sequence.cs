using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonVR.Assets.Scripts.GameManagement
{
    /// <summary>
    /// A sequence of sounds.
    /// </summary>
    public class Sequence : List<SequenceStep>
    {

    }
    /// <summary>
    /// Step of a sequence. Values are in seconds
    /// </summary>
    public class SequenceStep
    {
        /// <summary>
        /// Gets or sets the initial silence length.
        /// </summary>
        public float InitialPad { get; set; }

        /// <summary>
        /// Gets or sets the final silence length.
        /// </summary>
        public float FinalPad { get; set; }

        /// <summary>
        /// Gets or sets the duration of the step.
        /// </summary>
        public float Duration { get; set; }

        /// <summary>
        /// Gets or sets the value for the step.
        /// </summary>
        public int Value { get; set; }

        public SequenceStep(int value, float duration, float initialPad = 0f, float finalPad = 0f)
        {
            this.InitialPad = initialPad;
            this.FinalPad = finalPad;
            Duration = duration;
            Value = value;
        }
    }
}
