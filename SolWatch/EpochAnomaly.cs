using System;

namespace SolWatch
{
    public readonly struct EpochAnomaly
    {
        public DateTime Epoch { get; }
        public float TrueAnomaly { get; } // radians

        public EpochAnomaly(DateTime epoch, float trueAnomaly)
        {
            Epoch = epoch;
            TrueAnomaly = trueAnomaly;
        }
    }
}
