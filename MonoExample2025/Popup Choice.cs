using Engine.Engines;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.DirectWrite;
using Sprites;
using System;
using System.Collections.Generic;

namespace MonoExample2025
{
    public class Popup_Choice : SimpleSprite
    {
        private string caption;
        private Color bg;
        private Button[] buttons;
        private SpriteFont font;

        public Popup_Choice(string caption, Color background, SpriteFont font, Texture2D buttonImage, Texture2D spriteImage, Vector2 startPosition) : base(spriteImage, startPosition)
        {
            this.caption = caption;
            this.bg = background;
            this.font = font;
            this.buttons = new Button[2];
            buttons[0] = new Button("yes", background, font, buttonImage, startPosition);
            buttons[1] = new Button("no", background, font, buttonImage, startPosition);
        }

        public void drawPopup(SpriteBatch spriteBatch)
        {
            draw(spriteBatch);
            Vector2 textPosition = BoundingRect.Center.ToVector2();
            textPosition.Y -= Image.Height / 4;
            textPosition -= font.MeasureString(caption)/2 - new Vector2(0, 10);
            spriteBatch.DrawString(font, caption, textPosition, Color.White);
            Vector2 center = BoundingRect.Center.ToVector2();
            center.X -= buttons.Length * buttons[0].Image.Width / 2 + 5;
            foreach (Button button in buttons)
            {
                button.Move(center - button.Position);
                button.drawButton(spriteBatch);
                center.X += button.Image.Width + 10;
            }
        }

        public string Clicked()
        {
            if(InputEngine.IsMouseLeftClick())
            {
                foreach (Button button in buttons)
                {
                    if (button.BoundingRect.Contains(InputEngine.MousePosition)) 
                    {
                        return button.Clicked();
                    }
                }
            }
            return null;
        }
    }
}
