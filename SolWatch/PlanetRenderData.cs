using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SolWatch
{
    public class PlanetRenderData
    {
        public Planet Planet { get; }
        public string SpriteName { get; }
        public Color Color { get; }
        public Texture2D Symbol { get; set; }
        public float Anomaly { get; set; }

        public PlanetRenderData(Planet planet, string sprite, Color color)
        {
            Planet = planet;
            SpriteName = sprite;
            Color = color;
        }
    }
}
