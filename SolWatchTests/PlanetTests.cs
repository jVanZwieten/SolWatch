namespace SolWatch.Tests
{
    [TestClass]
    public class PlanetTests
    {
        const float angularAccuracyDegrees = .1f;
        readonly Planet[] Planets =
        {
            new(
                name: "Earth",
                semiMajorAxis: 149598023f,
                longitudeOfAscendingNode: Utilities.NormalizeAngle(Utilities.RadiansFromDegrees(-11.26f)),
                argumentOfPeriapsis: Utilities.RadiansFromDegrees(114.2f),
                referencePosition: new EpochAnomaly(new DateTime(2024, 7, 21), Utilities.RadiansFromDegrees(358.62f)))
        };

        [TestMethod]
        [DataRow("Earth", 2023, 5, 20, 296.8f)]
        [DataRow("Earth", 2024, 8, 1, 9.46f)]
        [DataRow("Earth", 2025, 1, 6, 165.19f)]
        public void AnomalyTest(string planetName, int year, int month, int day, float expectedOutputDegrees)
        {
            var planet = Planets.Where(planet => planet.Name == planetName).FirstOrDefault();
            var epoch = new DateTime(year, month, day);

            var result = planet.Anomaly(epoch);

            Assert.AreEqual(Utilities.RadiansFromDegrees(expectedOutputDegrees), result, Utilities.RadiansFromDegrees(angularAccuracyDegrees));
        }
    }
}