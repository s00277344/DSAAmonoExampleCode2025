using Engine.Engines;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Sprites;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;
using Tracker.WebAPIClient;
using SharpDX.MediaFoundation;
using System;

namespace MonoExample2025
{
    public class Game1 : Game
    {
        enum STATE
        {
            STARTING,
            PLAYING,
            WON,
            LOST,
            ASKING
        }

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ColourChoice playerColor;
        private ColourChoice computerColor;
        private Texture2D whitebg;
        // Create an array of simplesprites
        ColourChoice[] colorCollection = new ColourChoice[3];
        private Vector2 middleDown;
        private Vector2 middleUp;
        private SpriteFont font;
        private Popup_Choice popup;
        private STATE currentState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            ActivityAPIClient.Track(StudentID: "S00277344", StudentName: "Yoann SILVAIN", activityName: "DSAA Week 1 Lab 2 Sheet 3 2025", Task: "Week 1 Lab 2 Colour array selection working");

            // TODO: Add your initialization logic here
            new InputEngine(this);
            Vector2 currentMouse = InputEngine.MousePosition;
            // Changing the width and height of the _graphics device
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 780;
            _graphics.ApplyChanges();
            currentState = STATE.STARTING;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            whitebg = Content.Load<Texture2D>("whitebg");
            font = Content.Load<SpriteFont>("font");
            Texture2D bg = Content.Load<Texture2D>("backgroundImage");

            // TODO: use this.Content to load your game content here
            SetupPlayerChoices();
            middleUp.Y -= whitebg.Height + 5;
            middleUp.X -= bg.Width / 2;
            popup = new Popup_Choice("choice", Color.Pink, font, whitebg, bg, middleUp);
            middleUp.Y += whitebg.Height + 5;
            middleUp.X += bg.Width / 2;
        }

        private void SetupPlayerChoices()
        {
            Vector2 startPositionColor = GraphicsDevice.Viewport.Bounds.Center.ToVector2();
            middleDown = startPositionColor;
            middleDown.X -= whitebg.Width / 2;
            middleUp = middleDown;
            middleDown.Y += whitebg.Height;
            middleUp.Y -= whitebg.Height;
            startPositionColor.X = startPositionColor.X - colorCollection.Length * whitebg.Width / 2;
            for (int i = 0; i < colorCollection.Length; i++)
            {
                colorCollection[i] = new ColourChoice(whitebg, startPositionColor, Color.Blue);
                startPositionColor.X += whitebg.Width;
            }
            colorCollection[0].color = Color.Red;
            colorCollection[1].color = Color.Green;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (InputEngine.IsMouseLeftClick())
            {
                currentState = STATE.PLAYING;
                foreach (var item in colorCollection)
                {
                    if(item.sprite.BoundingRect.Contains(InputEngine.MousePosition.ToPoint()))
                    {
                        playerColor = new ColourChoice(whitebg, middleDown, item.color);
                        playerColor.color.A = 255;
                    }
                }

                Random rd = new Random();
                int choice = rd.Next(0, 3);
                computerColor = new ColourChoice(whitebg, middleUp, colorCollection[choice].color);
                computerColor.color.A = 255;
            }

            if(currentState == STATE.WON || currentState == STATE.LOST)
            {
                popup = new Popup_Choice("Do you want to play again?")
            }

            // TODO: Add your update logic here
            popup.Clicked();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            foreach(var item in colorCollection)
                item.draw(_spriteBatch);
            if(playerColor != null)
                playerColor.draw(_spriteBatch);
            if(computerColor != null)
                computerColor.draw(_spriteBatch);
            if(playerColor != null && computerColor != null)
            {
                if(computerColor.color == playerColor.color)
                {
                    _spriteBatch.DrawString(font, "Computer Wins", GraphicsDevice.Viewport.Bounds.Center.ToVector2() - font.MeasureString("Computer Wins") / 2 - new Vector2(0, 10), Color.White);
                    currentState = STATE.LOST;
                }
                else
                {
                    _spriteBatch.DrawString(font, "Player Wins", GraphicsDevice.Viewport.Bounds.Center.ToVector2() - font.MeasureString("Player Wins") / 2 - new Vector2(0, 10), Color.White);
                    currentState = STATE.WON;
                }
            }
            popup.drawPopup(_spriteBatch);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
