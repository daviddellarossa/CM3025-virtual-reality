using System;
using Valve.VR;

namespace SimonVR.Assets.Scripts.GameManagement
{
    public class SourceActionDelegateKey : IEquatable<SourceActionDelegateKey>
    {
        public SteamVR_Input_Sources Source { get; protected set; }
        public string Action { get; protected set; }


        public SourceActionDelegateKey(SteamVR_Input_Sources source, string action)
        {
            Source = source;
            Action = action;
        }


        public static bool operator ==(SourceActionDelegateKey obj1, SourceActionDelegateKey obj2)
        {
            if (ReferenceEquals(obj1, obj2))
            {
                return true;
            }
            if (ReferenceEquals(obj1, null))
            {
                return false;
            }
            if (ReferenceEquals(obj2, null))
            {
                return false;
            }

            return obj1.Equals(obj2);
        }

        public static bool operator !=(SourceActionDelegateKey obj1, SourceActionDelegateKey obj2) => !(obj1 == obj2);

        public bool Equals(SourceActionDelegateKey other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return (Source == other.Source && Action == other.Action);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SourceActionDelegateKey)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int)Source) ^ Action.GetHashCode();
            }
        }
    }
}
