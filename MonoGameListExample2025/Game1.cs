using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprites;
using System;
using System.Collections.Generic;

namespace MonoGameListExample2025
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<SimpleSprite> sprites = new List<SimpleSprite>();

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
            IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            // Populate the sprites list with a random number of Simple 
            // sprites at random positions witin the viewport

            Random r = new Random();
            int count = r.Next(15, 30);
            Texture2D tx = Content.Load<Texture2D>("chaser");

            for (int i = 0; i < count; i++)
            {
                // Calculate position
                Vector2 position = new Vector2(
                    r.Next(0, GraphicsDevice.Viewport.Width-32),
                    r.Next(0, GraphicsDevice.Viewport.Height-32)
                    );
                sprites.Add(new SimpleSprite(
                        spriteImage: tx,
                        startPosition: position)
                    );
            }
            
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


            MouseState mstate = Mouse.GetState();
            // If the Viewport contains the Mouse position
            if (GraphicsDevice.Viewport.Bounds.Contains(
                mstate.Position))
                {
                    foreach (SimpleSprite s in sprites)
                    {
                        s.Update();
                    }
                }

            SimpleSprite found = null;
            foreach (SimpleSprite s in sprites)
            {
                if (!s.visible)
                {
                    found = s; // take a copy of the invisible one
                    break; // finishing looking
                }
            }
            if (found != null) sprites.Remove(found);
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
            spriteBatch.Begin();
            foreach (SimpleSprite s in sprites)
            {
                s.draw(spriteBatch);
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
