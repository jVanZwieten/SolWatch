using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SolWatch
{
    public class Game1 : Game
    {
        Texture2D solTexture;
        Point solPosition;
        Point CelestialBodySymbolSize;
        
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
            solPosition = new Point(
                graphics.PreferredBackBufferWidth / 2,
                graphics.PreferredBackBufferHeight / 2);

            CelestialBodySymbolSize = new Point(50, 50);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            solTexture = Content.Load<Texture2D>("sol_symbol");

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

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(
                texture: solTexture,
                destinationRectangle: new Rectangle(
                    location: solPosition,
                    size: CelestialBodySymbolSize),
                sourceRectangle: null,
                color: Color.Gold,
                rotation: 0f,
                origin: new Vector2(solTexture.Width / 2, solTexture.Height / 2),
                effects: SpriteEffects.None,
                layerDepth: 0f);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
