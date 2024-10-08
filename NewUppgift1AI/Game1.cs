﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NewUppgift1AI
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        FiniteStateMachine stateMachine;
        ObjectManager objectManager;

        //Flock flock;

        const int windowX = 2500, windowY = 1500;
        public static int WindowX => windowX;
        public static int WindowY => windowY;

        public static int cellWidth = WindowX / 15;
        public static int cellHeight = WindowY / 10;

        Rectangle screenRect;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            screenRect = new Rectangle(0, 0, WindowX, WindowY);

            graphics.PreferredBackBufferWidth = screenRect.Width;
            graphics.PreferredBackBufferHeight = screenRect.Height;
            graphics.ApplyChanges();

            TextureManager.LoadTex(Content);
            stateMachine = new FiniteStateMachine();
            objectManager = new ObjectManager(stateMachine);

            //flock = new Flock();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            objectManager.Update(gameTime);
            InputManager.Update();

            //flock.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            objectManager.Draw(spriteBatch);
            //flock.Draw(spriteBatch);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}