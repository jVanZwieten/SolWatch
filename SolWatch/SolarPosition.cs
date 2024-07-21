using System;

namespace SolWatch
{
    public readonly struct SolarPosition
    {
        public float TrueAnomaly { get; } // radians
        public DateTime Epoch { get; }

        public SolarPosition(float trueAnomaly, DateTime epoch)
        {
            TrueAnomaly = trueAnomaly;
            Epoch = epoch;
        }
    }
}
