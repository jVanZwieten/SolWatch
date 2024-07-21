using System;
using System.Collections.Generic;

namespace SolWatch
{
    public class Planet
    {
        public string Name { get; }
        public float SemiMajorAxis { get; } // AU
        public float LongitudeOfAscendingNode { get; } // radians
        public float ArgumentOfPeriapsis { get; } // radians
        public List<SolarPosition> Anomalies { get; }

        public Planet(string name, float semiMajorAxis, float longitudeOfAscendingNode, float argumentOfPeriapsis)
        {
            Name = name;
            SemiMajorAxis = semiMajorAxis;
            LongitudeOfAscendingNode = longitudeOfAscendingNode;
            ArgumentOfPeriapsis = argumentOfPeriapsis;
            Anomalies = new List<SolarPosition>();
        }

        /// <summary>
        /// Gets the planet's position at a given DateTime as a angle through it's orbit.
        /// </summary>
        /// <param name="epoch">The moment at which you want the planet's position.</param>
        /// <returns>Mean/true anomaly (approximating a circular orbit) of the planet at the requested epoch. Angle through its orbit, in radians.</returns>
        public float Anomaly(DateTime epoch)
        {
            throw new NotImplementedException();
        }
    }
}
