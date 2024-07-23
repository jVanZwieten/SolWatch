using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;

namespace SolWatch
{
    public class Game1 : Game
    {
        const int celestialBodySymbolLength = 50;

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
            // TODO: Add your initialization logic here
            screenCenter = new Point(
                graphics.PreferredBackBufferWidth / 2,
                graphics.PreferredBackBufferHeight / 2);

            maxOrbitRadiusInPixels = (graphics.PreferredBackBufferHeight / 2) - 50;

            kmToPixelsFactor = maxOrbitRadiusInPixels / SolarSystemData.Data.FirstOrDefault(d => d.Planet.Name == "Neptune").Planet.SemiMajorAxis;

            foreach (var planetRenderData in SolarSystemData.Data)
                planetRenderData.Anomaly = planetRenderData.Planet.Anomaly(DateTime.Now);

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
            foreach (var planetRenderData in SolarSystemData.Data)
                planetRenderData.Symbol = Content.Load<Texture2D>(planetRenderData.SpriteName);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            var celestialBodySymbolSize = new Point(celestialBodySymbolLength, celestialBodySymbolLength);

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
                    location: new Point(screenCenter.X - maxOrbitRadiusInPixels, screenCenter.Y - maxOrbitRadiusInPixels),
                    size: celestialBodySymbolSize + new Point(30, 30)),
                sourceRectangle: null,
                color: Color.White,
                rotation: 0f,
                origin: new Vector2(arrowTexture.Width / 2, arrowTexture.Height / 2),
                effects: SpriteEffects.None,
                layerDepth: 0f);

            // Draw Aries
            spriteBatch.Draw(
                texture: ariesTexture,
                destinationRectangle: new Rectangle(
                    location: new Point(screenCenter.X - maxOrbitRadiusInPixels, screenCenter.Y - maxOrbitRadiusInPixels + 60),
                    size: celestialBodySymbolSize),
                sourceRectangle: null,
                color: Color.White,
                rotation: 0f,
                origin: new Vector2(ariesTexture.Width / 2, ariesTexture.Height / 2),
                effects: SpriteEffects.None,
                layerDepth: 0f);

            foreach (var planetRenderData in SolarSystemData.Data)
                DrawPlanetOrbit(planetRenderData.Symbol, (int)(planetRenderData.Planet.SemiMajorAxis * kmToPixelsFactor), planetRenderData.Anomaly, planetRenderData.Color);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        void DrawPlanetOrbit(Texture2D planetSprite, int orbitSize, float angle, Color color)
        {
            spriteBatch.Draw(
                texture: orbitTexture,
                destinationRectangle: new Rectangle(
                    location: screenCenter,
                    size: new(orbitSize * 2, orbitSize * 2)),
                sourceRectangle: null,
                color: color,
                rotation: 0f,
                origin: orbitTexture.Center(),
                effects: SpriteEffects.None,
                layerDepth: 0f);

            spriteBatch.Draw(
                texture: planetSprite,
                destinationRectangle: new Rectangle(
                    location: screenCenter + new Point(0, -orbitSize), // todo: calculate cartesian position of planet sprite
                    size: new(celestialBodySymbolLength, celestialBodySymbolLength)),
                sourceRectangle: null,
                color: color,
                rotation: 0f,
                origin: planetSprite.Center(),
                effects: SpriteEffects.None,
                layerDepth: 0f);
        }
    }
}
