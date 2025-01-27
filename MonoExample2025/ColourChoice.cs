using Engine.Engines;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Sprites;
using System.Numerics;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace MonoExample2025
{
    public class ColourChoice
    {
        public SimpleSprite sprite;
        private Texture2D texture;
        public Vector2 position;
        public Color color;
        private bool changed;

        public ColourChoice(Texture2D texture, Vector2 position, Color color)
        {
            this.texture = texture;
            this.position = position;
            this.color = color;
            changed = false;
            sprite = new SimpleSprite(texture, position);
        }

        public void draw(SpriteBatch sp)
        {
            if (sprite.BoundingRect.Contains(InputEngine.MousePosition.ToPoint()))
            {
                sp.Draw(texture, position, Color.White);
                if (InputEngine.IsMouseLeftClick())
                {
                    if (!changed)
                    {
                        changed = true;
                        color.A = 127;
                    }
                    else
                    {
                        changed = false;
                        color.A = 255;
                    }
                }
            }
            else 
                sp.Draw(texture, position, color);
        }
    }
}
