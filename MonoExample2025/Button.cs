using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.DirectWrite;
using Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoExample2025
{
    public class Button : SimpleSprite
    {
        private string caption;
        private Color bg;
        private SpriteFont font;
        public Button(string caption, Color background, SpriteFont font, Texture2D spriteImage, Vector2 startPosition) : base(spriteImage, startPosition)
        {
            this.caption = caption;
            this.bg = background;
            this.font = font;
        }

        public void drawButton(SpriteBatch spriteBatch)
        {
            draw(spriteBatch);
            spriteBatch.DrawString(font, caption, BoundingRect.Center.ToVector2() - font.MeasureString(caption), Color.Black);
        }

        public string Clicked()
        {
            return this.caption;
        }
    }
}
