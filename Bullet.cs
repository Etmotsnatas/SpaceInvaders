using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SpaceInvaders
{
    public class Bullet
    {
        public Vector2 pos;
        public Texture2D tex;
        public Vector2 velocity;
        public Rectangle hitbox;

        public Bullet (Vector2 pos, Texture2D tex, Vector2 velocity)
        {
            this.pos = pos;
            this.tex = tex;
            this.velocity = velocity;

            hitbox = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
        }
        public void Update()
        {
            pos = pos + velocity;

            hitbox.X = (int)pos.X;
            hitbox.Y = (int)pos.Y;
        }
    }
}
