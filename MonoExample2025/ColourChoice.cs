using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Framework.Utilities;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MonoExample2025
{
    public class ColourChoice
    {
        Microsoft.Xna.Framework.Color Choice;
        Microsoft.Xna.Framework.Vector2 ChoicePosition;
        Texture2D ChoiceTexture;

        public ColourChoice(Microsoft.Xna.Framework.Color choice, Texture2D texture, Microsoft.Xna.Framework.Vector2 startPosition)
        {
            Choice = choice;
            ChoiceTexture = texture;
            ChoicePosition = startPosition;
        }

        public void draw(SpriteBatch sp)
        {
            sp.Draw(ChoiceTexture, ChoicePosition, Choice);
        }
    }
}
