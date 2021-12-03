using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonVR.Assets.Scripts.GameManagement
{
    public class Sequence : List<SequenceStep>
    {

    }
    /// <summary>
    /// Values are in seconds
    /// </summary>
    public class SequenceStep
    {
        public float InitialPad { get; set; }
        public float FinalPad { get; set; }
        public float Duration { get; set; }
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
