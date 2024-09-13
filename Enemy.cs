using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
//using System.Numerics;
using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class Enemy
    {
        public Vector2 pos;
        public Vector2 startPos;
        public int windowHeight;
        public Texture2D tex;
        public Vector2 velocity;
        public Rectangle hitbox;

        public Enemy (Vector2 pos, int windowHeight, Texture2D tex, Vector2 velocity)     //konstruktorn
        {
            this.pos = pos;
            this.startPos = pos;
            this.windowHeight = windowHeight;
            this.tex = tex;
            this.velocity = velocity;

            hitbox = new Rectangle ((int)pos.X, (int)pos.Y, tex.Width, tex.Height);

        }

        public void Update()
        {
            pos = pos + velocity;

            hitbox.X = (int)pos.X;
            hitbox.Y = (int)pos.Y;
        }

        public void ResetPosition()
        {
            pos = startPos;
            hitbox.X = (int)pos.X;
            hitbox .Y = (int)pos.Y;
        }

        public void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, pos, Color.Black);
        }
        
    }
}
