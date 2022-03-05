using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonVR.Assets.Scripts.GameManagement
{
    /// <summary>
    /// Generate a sequence of sounds.
    /// </summary>
    public class SequenceGenerator
    {
        /// <summary>
        /// Gets or sets Min value for the range to select from.
        /// </summary>
        public int MinValue { get; protected set; }

        /// <summary>
        /// Gets or sets Max value for the range to select from.
        /// </summary>
        public int MaxValue { get; protected set; }

        /// <summary>
        /// Gets or sets Duration of the sound. Not used.
        /// </summary>
        public float Duration { get; protected set; }

        /// <summary>
        /// Gets or sets Silence length added at the end of the sound.
        /// </summary>
        public float FinalPad { get; protected set; }

        /// <summary>
        /// Gets or sets Random number generator.
        /// </summary>
        public Random Random { get; set; }

        /// <summary>
        /// Create a new instance of the class.
        /// </summary>
        /// <param name="maxValue">Max value for the range to select from.</param>
        /// <param name="duration">Duration of the sound. Not used.</param>
        /// <param name="minValue">Min value for the range to select from.</param>
        /// <param name="finalPad">Silence length added at the end of the sound.</param>
        public SequenceGenerator(int maxValue, float duration, int minValue = 0, float finalPad = 0)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            Duration = duration;
            FinalPad = finalPad;
            Random = new Random(Guid.NewGuid().GetHashCode());
            
        }

        /// <summary>
        /// Create and return a new sequence.
        /// </summary>
        /// <param name="level">Difficulty level to create the sequene for.</param>
        /// <returns></returns>
        public Sequence GetSequence(int level)
        {
            var sequence = new Sequence();

            for(int i = 0; i < level; i++)
            {
                sequence.Add(new SequenceStep(Random.Next(MinValue, MaxValue), Duration, finalPad:FinalPad));
            }
            return sequence;
        }
    }
}
