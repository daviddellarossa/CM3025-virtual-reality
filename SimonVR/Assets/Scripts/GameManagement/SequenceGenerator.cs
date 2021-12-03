using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonVR.Assets.Scripts.GameManagement
{
    public class SequenceGenerator
    {
        public int MinValue { get; protected set; }
        public int MaxValue { get; protected set; }
        public int Duration { get; protected set; }
        public Random Random { get; set; }
        public SequenceGenerator(int maxValue, int duration, int minValue = 0)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            Duration = duration;

            Random = new Random(Guid.NewGuid().GetHashCode());
            
        }
        public Sequence GetSequence(uint level)
        {
            var sequence = new Sequence();

            for(int i = 0; i < level; i++)
            {
                sequence.Add(new SequenceStep(Random.Next(MinValue, MaxValue), Duration));
            }
            return sequence;
        }
    }
}
