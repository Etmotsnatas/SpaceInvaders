using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
//using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class Enemy
    {
        public Vector2 pos;
        public int windowHeight;
        public Texture2D tex;
        public Vector2 velocity;

        public Enemy (Vector2 pos, int windowHeight, Texture2D tex, Vector2 velocity)     //konstruktorn
        {
            this.pos = pos;
            this.windowHeight = windowHeight;
            this.tex = tex;
            this.velocity = velocity;
        }

        public void Update()
        {
            if (pos.Y > windowHeight - tex.Height)         //när enemies når player ska detta hända
            {
                
            }
        }

        public void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, pos, Color.White);
        }

    }
}
