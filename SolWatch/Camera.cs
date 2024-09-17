using System;
using System.Collections.Generic;
using System.Linq;

namespace SolWatch
{
    internal static class Camera
    {
        const float zoomIncrement = .1f;
        const float minZoom = 1f;
        const float maxZoom = 20f;
        static float zoom = 1;

        public static void IncrementZoom()
        {
            zoom = Math.Min(maxZoom, zoom * (1 + zoomIncrement));
        }
        public static void DecrementZoom()
        {
            zoom = Math.Max(minZoom, zoom * (1 - zoomIncrement));
        }

        public static IEnumerable<PlanetRenderData> RenderPlanetsAtZoom(PlanetRenderData[] renderPlanets) =>
            renderPlanets.Select(original => new PlanetRenderData(original, zoom));
    }
}
