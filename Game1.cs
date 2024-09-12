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
        public Vector2 pos;
        public Vector2 velocity;
        public int windowHeight;
        public Enemy enemy;
        public List<Enemy> enemyList;

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

            enemyTex = Content.Load<Texture2D>("space__0002_B1"); //Enemy Texturen
            windowHeight = Window.ClientBounds.Height;
            velocity = new Vector2(0, 0);    // Enemy movement
            enemyList = new List<Enemy>();  //Enemy listan
            for (int i = 0; i < 20; i++) 
            {
                enemy = CreateEnemy(i);
                enemyList.Add(enemy);
            }

            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 800;
            graphics.ApplyChanges();                        //Skärmstorlek

            // TODO: use this.Content to load your game content here
        }

        public Enemy CreateEnemy (int i)
        {
           Vector2 pos = new Vector2(i*32, 10);                                //var nya enemies skapas i samband med den förra
            Enemy e = new Enemy(pos, windowHeight, enemyTex, velocity);
            return e;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            foreach (Enemy enemy in enemyList)
            {
                enemy.Update();
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
