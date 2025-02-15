using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace Sprites
{
    public class BackgroundSprite : DrawableGameComponent
    {
        public Texture2D Image;
        public Vector2 Position;
        public Rectangle BoundingRect;
        public bool Visible = true;
       

        public BackgroundSprite(Game g,Texture2D spriteImage,
                            Vector2 startPosition) : base(g)
        {
            g.Components.Add(this);
            Image = spriteImage;
            Position = startPosition;
            BoundingRect = new Rectangle((int)startPosition.X, (int)startPosition.Y, Image.Width, Image.Height);

        }

        public override void Draw(GameTime gametime)
        {
            SpriteBatch spriteBatch = Game.Services.GetService<SpriteBatch>();
            spriteBatch.Begin();
            if (Visible)
                spriteBatch.Draw(Image, Position, Color.White);
            spriteBatch.End();

        }


    }
}
