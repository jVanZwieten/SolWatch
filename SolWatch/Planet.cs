using System;
using System.Collections.Generic;

namespace SolWatch
{
    public class Planet
    {
        public string Name { get; }
        public float SemiMajorAxis { get; } // km
        public float LongitudeOfAscendingNode { get; } // radians
        public float ArgumentOfPeriapsis { get; } // radians

        readonly EpochAnomaly referencePosition;

        float meanMotion { get => MathF.Sqrt(Utilities.GravitationalParameter_Sol / MathF.Pow(SemiMajorAxis, 3)); } // radians/s
        float period { get => Utilities.FullCircle / meanMotion; } // s

        public Planet(string name, float semiMajorAxis, float longitudeOfAscendingNode, float argumentOfPeriapsis, EpochAnomaly referencePosition)
        {
            Name = name;
            SemiMajorAxis = semiMajorAxis;
            LongitudeOfAscendingNode = longitudeOfAscendingNode;
            ArgumentOfPeriapsis = argumentOfPeriapsis;
            this.referencePosition = referencePosition;
        }

        /// <summary>
        /// Gets the planet's position at a given DateTime as an angle through its orbit.
        /// </summary>
        /// <param name="epoch">The moment at which you want the planet's position.</param>
        /// <returns>Mean/true anomaly (approximating a circular orbit) of the planet at the requested epoch. Angle through its orbit, in radians.</returns>
        public float Anomaly(DateTime epoch) => Utilities.NormalizeAngle(referencePosition.TrueAnomaly + (meanMotion * (float)(epoch - referencePosition.Epoch).TotalSeconds));
    }
}
