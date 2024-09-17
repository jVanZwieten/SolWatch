using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

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

        public PlanetRenderData(PlanetRenderData original, float scale)
        {
            PlanetName = original.PlanetName;
            SpriteName = original.SpriteName;
            Color = original.Color;
            Symbol = original.Symbol;
            Radius = (int)MathF.Floor(original.Radius * scale);
            Angle = original.Angle;

        }
    }
}
