using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace SolWatch
{
    public class Game1 : Game
    {
        Texture2D solTexture;
        Point screenCenter;

        Texture2D orbitTexture;
        int maxOrbitRadiusInPixels;
        Point maxOrbitSizeInPixels;
        float kmToPixelsMultiplier;

        Planet neptune;
        
        Point celestialBodySymbolSize;
        
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

            celestialBodySymbolSize = new Point(50, 50);

            maxOrbitRadiusInPixels = graphics.PreferredBackBufferHeight / 2;
            maxOrbitSizeInPixels = new Point(maxOrbitRadiusInPixels * 2, maxOrbitRadiusInPixels * 2);

            neptune = new Planet(
                name: "Neptune",
                semiMajorAxis: 4.5e9f,
                longitudeOfAscendingNode: SolWatch.Utilities.RadiansFromDegrees(48.331f),
                argumentOfPeriapsis: SolWatch.Utilities.RadiansFromDegrees(273.187f)
                );

            kmToPixelsMultiplier = maxOrbitRadiusInPixels / neptune.SemiMajorAxis;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            solTexture = Content.Load<Texture2D>("sol_symbol");
            orbitTexture = Content.Load<Texture2D>("dotted-circle");

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
                origin: new Vector2(solTexture.Width / 2, solTexture.Height / 2),
                effects: SpriteEffects.None,
                layerDepth: 0f);

            // Draw Neptune's Orbit
            spriteBatch.Draw(
                texture: orbitTexture,
                destinationRectangle: new Rectangle(
                    location: screenCenter,
                    size: maxOrbitSizeInPixels),
                sourceRectangle: null,
                color: Color.SeaGreen,
                rotation: 0f,
                origin: new Vector2(orbitTexture.Width / 2, orbitTexture.Height / 2),
                effects: SpriteEffects.None,
                layerDepth: 0f);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
