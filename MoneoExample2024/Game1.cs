using Engine.Engines;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Sprites;

namespace MonoExample2025
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Song openingMusicTrack;
        private SoundEffect clickEffect;
        private SoundEffectInstance clickPlayer;
        private SpriteFont font;
        private SimpleSprite bodySprite;
        // Create an array of simplesprites
        SimpleSprite[] spritesCollection = new SimpleSprite[5];

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            new InputEngine(this);
            Vector2 currentMouse = InputEngine.MousePosition;
            // Changing the width and height of the _graphics device
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 780;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D bodytx = Content.Load<Texture2D>("body");
            openingMusicTrack = Content.Load<Song>("Opening Music Track");
            //MediaPlayer.Play(openingMusicTrack);
            clickEffect = Content.Load<SoundEffect>("Collected");
             clickPlayer = clickEffect.CreateInstance();
            font = Content.Load<SpriteFont>("font");
            //clickEffect.Play();
            //bodySprite = new SimpleSprite(bodytx, new Vector2(100, 100));
            
            // Work out the start position of the collection relative to the center of
            // the screen and taking into account the size of the collection and the size of
            // the images in the collection objects
            Vector2 startPosition = GraphicsDevice.Viewport.Bounds.Center.ToVector2();
            startPosition.X = startPosition.X - spritesCollection.Length * bodytx.Width/2;
            // position the collection of objects
            for (int i = 0; i < spritesCollection.Length; i++)
            {
                spritesCollection[i] = new SimpleSprite(bodytx, startPosition);
                startPosition.X += bodytx.Width;
            }

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Look at checking mouse clicks for each item in the collection
            
            // Toggle first element tint Needed for Week2 lab 1
            if (InputEngine.IsKeyPressed(Keys.T))
                spritesCollection[0].Tint = !spritesCollection[0].Tint;

            //if(InputEngine.IsKeyHeld(Keys.Right)) 
            //{
            //    bodySprite.Move(new Vector2(5, 0));
            //}
            //if (InputEngine.IsKeyHeld(Keys.Left))
            //{
            //    bodySprite.Move(new Vector2(-5, 0));
            //}

                //if(InputEngine.IsMouseLeftClick() 
                //    && bodySprite.BoundingRect.Contains(InputEngine.MousePosition.ToPoint() ))
                //    if(clickPlayer.State != SoundState.Playing)
                //    {
                //        clickPlayer.Play();
                //    }

                // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.DrawString(font, "Mongame Example 2024", GraphicsDevice.Viewport.Bounds.Center.ToVector2() - font.MeasureString("Mongame Example 2024")/2 - new Vector2(0,10), Color.White);
            //bodySprite.draw(_spriteBatch);
            // Draw the collection of objects
            foreach (var item in spritesCollection)
                item.draw(_spriteBatch);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
