using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SpaceInvaders
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        public Texture2D enemyTex;
        public Texture2D bulletTex;
        public Vector2 pos;
        public Vector2 velocity;
        public int windowHeight;
        public Rectangle hitbox;
        public Enemy enemy;
        public Bullet bullet;
        public List<Enemy> enemyList;
        public List<Bullet> bulletList;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 600;
            graphics.ApplyChanges();                        //Skärmstorlek

            enemyTex = Content.Load<Texture2D>("space__0002_B1"); //Enemy Texturen
            windowHeight = Window.ClientBounds.Height;
            velocity = new Vector2(0, 1);    // Enemy movement
            enemyList = new List<Enemy>();  //Enemy listan
            for (int i = 0; i < 45; i++) 
            {
                enemy = CreateEnemy(i);
                enemyList.Add(enemy);
            }



            // TODO: use this.Content to load your game content here
        }

        public Enemy CreateEnemy(int i)
        {
            int enemiesPerRow = 15;
            int row = i / enemiesPerRow;          // Bestämmer om fienden börjar på rad 0, 1 eller 2
            int col = i % enemiesPerRow;         // Bestämmer vilken kolumn

            float x = col * 40;                // Fiendens X-position och mellanrummet till nästa kolumn
            float y = row * 32 + 10;          //Fiendens Y-position och mellanrummet till nästa rad, vertikalt

            Vector2 pos = new Vector2(x, y);     //var nya enemies skapas
            Enemy e = new Enemy(pos, windowHeight, enemyTex, velocity);
            return e;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            bool ememyReachedBottom = false;       // kontrolera om fienderna nått botten

            foreach (Enemy enemy in enemyList)
            {
                enemy.Update();

                if (enemy.pos.Y > windowHeight-enemy.tex.Height)
                {
                    ememyReachedBottom = true;               
                }
            }                                     // kontrollera om fienderna nått botten

            if (ememyReachedBottom)
            {
                foreach (Enemy enemy in enemyList)         // om de har det händer detta
                {
                    enemy.ResetPosition();               // återvänd till startposition
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.HotPink);

            spriteBatch.Begin();

            foreach (Enemy enemy in enemyList)          //rita ut alla enemies i listan
            {
                enemy.Draw(spriteBatch);
            }

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
