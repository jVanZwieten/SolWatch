using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;

namespace SolWatch
{
    public class Game1 : Game
    {
        readonly Point celestialBodySymbolSize = new(50, 50);

        Texture2D solTexture;
        Texture2D orbitTexture;
        Texture2D ariesTexture;
        Texture2D arrowTexture;

        Point screenCenter;
        int maxOrbitRadiusInPixels;
        float kmToPixelsFactor;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 1024;
            graphics.PreferredBackBufferWidth = 1280;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            screenCenter = new Point(
                graphics.PreferredBackBufferWidth / 2,
                graphics.PreferredBackBufferHeight / 2);

            maxOrbitRadiusInPixels = (graphics.PreferredBackBufferHeight / 2) - 50;

            kmToPixelsFactor = maxOrbitRadiusInPixels / SolarSystemData.Planets.FirstOrDefault(p => p.Name == "Neptune").SemiMajorAxis;

            foreach (var renderData in SolarSystemData.RenderDatas)
            {
                var planet = SolarSystemData.Planets.FirstOrDefault(p => p.Name == renderData.PlanetName);
                // todo: calc radius & angle using Utility functions
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            solTexture = Content.Load<Texture2D>("sol-symbol");
            orbitTexture = Content.Load<Texture2D>("dotted-circle");
            arrowTexture = Content.Load<Texture2D>("white-arrow");
            ariesTexture = Content.Load<Texture2D>("aries-symbol");

            PopulatePlanetSprites();
        }

        void PopulatePlanetSprites()
        {
            foreach (var renderData in SolarSystemData.RenderDatas)
                renderData.Symbol = Content.Load<Texture2D>(renderData.SpriteName);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            // Draw Sol
            spriteBatch.Draw(
                texture: solTexture,
                destinationRectangle: new Rectangle(
                    location: screenCenter,
                    size: celestialBodySymbolSize),
                sourceRectangle: null,
                color: Color.Gold,
                rotation: 0f,
                origin: solTexture.Center(),
                effects: SpriteEffects.None,
                layerDepth: 0f);

            // Draw "North" arrow
            spriteBatch.Draw(
                texture: arrowTexture,
                destinationRectangle: new Rectangle(
                    location: screenCenter - new Point(maxOrbitRadiusInPixels, maxOrbitRadiusInPixels),
                    size: celestialBodySymbolSize + new Point(30, 30)),
                sourceRectangle: null,
                color: Color.White,
                rotation: 0f,
                origin: arrowTexture.Center(),
                effects: SpriteEffects.None,
                layerDepth: 0f);

            // Draw Aries
            spriteBatch.Draw(
                texture: ariesTexture,
                destinationRectangle: new Rectangle(
                    location: screenCenter - new Point(maxOrbitRadiusInPixels, maxOrbitRadiusInPixels + 60),
                    size: celestialBodySymbolSize),
                sourceRectangle: null,
                color: Color.White,
                rotation: 0f,
                origin: ariesTexture.Center(),
                effects: SpriteEffects.None,
                layerDepth: 0f);

            foreach (var renderData in SolarSystemData.RenderDatas)
                DrawPlanetOrbit(renderData.Symbol, renderData.Radius, renderData.Angle, renderData.Color);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        void DrawPlanetOrbit(Texture2D planetSprite, int orbitRadius, float angle, Color color)
        {
            spriteBatch.Draw(
                texture: orbitTexture,
                destinationRectangle: new Rectangle(
                    location: screenCenter,
                    size: new(orbitRadius * 2, orbitRadius * 2)),
                sourceRectangle: null,
                color: color,
                rotation: 0f,
                origin: orbitTexture.Center(),
                effects: SpriteEffects.None,
                layerDepth: 0f);

            spriteBatch.Draw(
                texture: planetSprite,
                destinationRectangle: new Rectangle(
                    location: screenCenter + new Point(0, -orbitRadius), // todo: calculate cartesian position of planet sprite
                    size: celestialBodySymbolSize),
                sourceRectangle: null,
                color: color,
                rotation: 0f,
                origin: planetSprite.Center(),
                effects: SpriteEffects.None,
                layerDepth: 0f);
        }
    }
}
