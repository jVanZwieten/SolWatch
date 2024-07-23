using Microsoft.Xna.Framework;

namespace SolWatch
{
    public static class SolarSystemData
    {
        public static Planet[] Planets =
        {
                new("Mercury", 5.791e7f, 48.33f, 29.12f, new(new(2024, 7, 22), 174.8f), true),
                new("Venus", 1.0821e8f, 76.68f, 54.88f, new(new(2024, 7, 22), 50.12f), true),
                new("Earth", 149598023f, -11.26f, 114.21f, new(new(2024, 7, 22), 358.617f), true),
                new("Mars", 227939366f, 49.58f, 286.5f, new(new(2024, 7, 22), 19.41f), true),
                new("Jupiter", 7.78e8f , 100.46f, 273.87f, new(new(2024, 7, 22), 20.02f), true),
                new("Saturn", 1.43353e9f, 113.67f, 339.39f, new(new(2024, 7, 22), 317.02f), true),
                new("Uranus", 2.870972e9f, 74.01f, 97f, new(new(2024, 7, 22), 142.24f), true),
                new("Neptune", 4.50e9f, 131.78f, 273.19f, new(new(2024, 7, 22), 259.88f), true),
        };

        public static PlanetRenderData[] RenderDatas =
        {
            new(
                "Mercury",
                "sol-symbol",
                Color.Brown),
            new(
                "Venus",
                "sol-symbol",
                Color.Yellow),
            new(
                "Earth",
                "sol-symbol",
                Color.Blue),
            new(
                "Mars",
                "sol-symbol",
                Color.Red),
            new(
                "Jupiter",
                "sol-symbol",
                Color.Orange),
            new(
                "Saturn",
                "sol-symbol",
                Color.Tan),
            new(
                "Uranus",
                "sol-symbol",
                Color.PaleTurquoise),
            new(
                "Neptune",
                "sol-symbol",
                Color.SeaGreen),
        };
    }
}
