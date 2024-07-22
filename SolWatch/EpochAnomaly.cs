using System;

namespace SolWatch
{
    public readonly struct EpochAnomaly
    {
        public DateTime Epoch { get; }
        public float Anomaly { get; } // radians

        public EpochAnomaly(DateTime epoch, float anomaly)
        {
            Epoch = epoch;
            Anomaly = anomaly;
        }
    }
}
