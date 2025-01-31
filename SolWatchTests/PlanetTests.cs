﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolWatch;

namespace SolWatch.Tests
{
    [TestClass]
    public class PlanetTests
    {
        const float angularAccuracyDegrees = .1f;
        readonly Planet[] testPlanets =
        {
            new(
                name: "Earth",
                semiMajorAxis: 149598023f,
                longitudeOfAscendingNode: Utilities.NormalizeAngle(Utilities.RadiansFromDegrees(-11.26f)),
                argumentOfPeriapsis: Utilities.RadiansFromDegrees(114.2f),
                referenceEpochAnomaly: new EpochAnomaly(new DateTime(2024, 7, 21), Utilities.RadiansFromDegrees(358.62f)))
        };

        [TestMethod]
        [DataRow("Earth", 2023, 5, 20, 296.8f)]
        [DataRow("Earth", 2024, 8, 1, 9.46f)]
        [DataRow("Earth", 2025, 1, 6, 165.19f)]
        public void AnomalyTest(string planetName, int year, int month, int day, float expectedOutputDegrees)
        {
            var testPlanet = testPlanets.FirstOrDefault(planet => planet.Name == planetName);
            var epoch = new DateTime(year, month, day);

            var result = testPlanet.Anomaly(epoch);

            Assert.AreEqual(
                Utilities.RadiansFromDegrees(expectedOutputDegrees),
                result,
                Utilities.RadiansFromDegrees(angularAccuracyDegrees));
        }

        [TestMethod]
        [DataRow("Earth", 2023, 5, 20, 0.6934f)]
        [DataRow("Earth", 2024, 8, 1, 1.9617f)]
        [DataRow("Earth", 2025, 1, 6, 4.6798f)]
        public void TrueLongitudeAtEpochTest(string planetName, int year, int month, int day, float expectedOutputRadians)
        {
            var testPlanet = testPlanets.FirstOrDefault(planet => planet.Name == planetName);
            var epoch = new DateTime(year, month, day);

            var result = testPlanet.TrueLongitudeAtEpoch(epoch);

            Assert.AreEqual(
                expectedOutputRadians,
                result,
                Utilities.RadiansFromDegrees(angularAccuracyDegrees));
        }
    }
}