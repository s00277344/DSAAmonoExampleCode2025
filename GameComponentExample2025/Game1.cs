using Cameras;
using Engine.Engines;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprites;


namespace GameComponentExample2025
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D _background;
        private Camera cam;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
           
            _background = Content.Load<Texture2D>(@"backgroundImage");
            new Sprite(this, _background, Vector2.Zero, 1);
            new InputEngine(this);
            cam = new Camera(Vector2.Zero, _background.Bounds.Size.ToVector2());
            this.Services.AddService(cam);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            this.Services.AddService(spriteBatch);

            SoundEffect[] _PlayerSounds = new SoundEffect[5];
            for (int i = 0; i < _PlayerSounds.Length; i++)
                _PlayerSounds[i] =
                    Content.Load<SoundEffect>(@"Audio/"
                        + i.ToString());


            new Player(this, new Texture2D[] {Content.Load<Texture2D>(@"Images/left"),
                                                Content.Load<Texture2D>(@"Images/right"),
                                                Content.Load<Texture2D>(@"Images/up"),
                                                Content.Load<Texture2D>(@"Images/down"),
                                                Content.Load<Texture2D>(@"Images/stand")},
                _PlayerSounds,
                    new Vector2(200, 200), 6, 0, 5.0f);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
