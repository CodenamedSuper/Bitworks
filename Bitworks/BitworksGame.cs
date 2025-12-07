using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace BitworksEngine
{
    public class BitworksGame : Game
    {
        internal static BitworksGame s_instance;

        public static BitworksGame Instance => s_instance;

        public static GraphicsDeviceManager Graphics { get; private set; }

        public static new GraphicsDevice GraphicsDevice { get; private set; }

        public static SpriteBatch SpriteBatch { get; private set; }
        public static Texture2D Pixel { get; private set; }

        public static new ContentManager Content { get; private set; }

        public static GameManager GameManager { get; set; } = new GameManager();

        public static Camera Camera { get; set; }

        public static float DeltaTime { get; set; } = 0;

        public static readonly int TILE_SIZE = 16;
        public static readonly int ZOOM = 4;
        public static readonly float GRAVITY = 800;

        public static readonly bool SHOW_COLLIDERS = false;

        public BitworksGame(string gameName)
        {

            s_instance = this;

            Graphics = new GraphicsDeviceManager(this);

            Graphics.PreferredBackBufferWidth = 1280;
            Graphics.PreferredBackBufferHeight = 720;
            Graphics.IsFullScreen = false;

            Graphics.ApplyChanges();

            Window.Title = gameName;
            Content = base.Content;

            Content.RootDirectory = "content";

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Input.Initialize();
            base.Initialize();

            GraphicsDevice = base.GraphicsDevice;

            SpriteBatch = new SpriteBatch(GraphicsDevice);
            Pixel = new Texture2D(GraphicsDevice, 1, 1);
            Pixel.SetData(new[] { Color.White });
        }

        protected override void LoadContent()
        {

            Camera = new Camera();
            Camera.Zoom = ZOOM;


            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            DeltaTime = ((float)gameTime.ElapsedGameTime.TotalSeconds);

            GameManager.Update();

            Camera.Update();

            Input.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointWrap, null, null, null, Camera.Matrix);

            GameManager.Draw();

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
