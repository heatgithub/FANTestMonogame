using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FANTestMonogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // RenderTarget
        RenderTarget2D _renderTarget;
        const int RENDER_TARGET_WIDTH = 1080;
        const int RENDER_TARGET_HEIGHT = 1920;
        float screenScaleFactorX = 0.0f;
        float screenScaleFactorY = 0.0f;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            // Create the RenderTarget
            _renderTarget = new RenderTarget2D(GraphicsDevice, RENDER_TARGET_WIDTH, RENDER_TARGET_HEIGHT, false, GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
            // Calculate screen scale factor for touch.Position (from TouchCollection)
            screenScaleFactorX = RENDER_TARGET_WIDTH / (float) GraphicsDevice.Viewport.Width;
            screenScaleFactorY = RENDER_TARGET_HEIGHT / (float) GraphicsDevice.Viewport.Height;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
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

            // TODO: Add your drawing code here

            GraphicsDevice.SetRenderTarget(_renderTarget);
            _spriteBatch.Begin();

            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.End();
            GraphicsDevice.SetRenderTarget(null);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_renderTarget, _graphics.GraphicsDevice.Viewport.Bounds, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
