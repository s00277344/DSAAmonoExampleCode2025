﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Engines;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TiledSpriteExample
{
    public class TiledPlayer : TiledSprite
    {
        public float RotationSpeed { get; set; }
        public float speed { get; set; } 
        public TiledPlayer(Vector2 tilePosition, 
            List<TileRef> sheetRefs, int frameWidth, 
            int frameHeight, float layerDepth) : base(tilePosition, sheetRefs, frameWidth, frameHeight, layerDepth)
        {
            speed = 5.0f;
            RotationSpeed = 0.02f;
        }
        public override void Update(GameTime gametime)
        {
            if (InputEngine.IsKeyHeld(Keys.X))
                AngleOfRotation += RotationSpeed;
            if (InputEngine.IsKeyHeld(Keys.Z))
                AngleOfRotation -= RotationSpeed;

            if (InputEngine.IsKeyHeld(Keys.Up))
                PixelPosition += new Vector2(
                    (float)Math.Sin(AngleOfRotation),
                    -(float)Math.Cos(AngleOfRotation)) * 5;

            if (InputEngine.IsKeyHeld(Keys.Down))
                PixelPosition -= new Vector2(
                    (float)Math.Sin(AngleOfRotation),
                    -(float)Math.Cos(AngleOfRotation)) * 5;

            base.Update(gametime);
        }

        public override void Draw(SpriteBatch spriteBatch, Texture2D SpriteSheet)
        {
            base.Draw(spriteBatch, SpriteSheet);
        }

    }
}
