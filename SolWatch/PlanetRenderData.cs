using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SolWatch
{
    public class PlanetRenderData
    {
        public string PlanetName { get; }
        public string SpriteName { get; }
        public Color Color { get; }
        public Texture2D Symbol { get; set; }
        public int Radius { get; set; }
        public float Angle { get; set; }

        public PlanetRenderData(string planetName, string sprite, Color color)
        {
            PlanetName = planetName;
            SpriteName = sprite;
            Color = color;
        }
    }
}
