using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Mono_Topic_5___Making_a_Class
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        List<Texture2D> ghostTextures;
        Texture2D titleTexture;
        Texture2D hauntedBackgroundTexture;
        Texture2D endTexture;
        Texture2D marioTexture;
        Rectangle marioRect;

        MouseState mouseState;
        Random generator;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            ghostTextures = new List<Texture2D>();
            generator = new Random();
            marioRect = new Rectangle(0, 0, 30, 30);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            titleTexture = Content.Load<Texture2D>("Images/haunted-title");
            hauntedBackgroundTexture = Content.Load<Texture2D>("Images/haunted-background");
            endTexture = Content.Load<Texture2D>("Images/haunted-end-screen");
            marioTexture = Content.Load<Texture2D>("Images/mario");
            ghostTextures.Add(Content.Load<Texture2D>("Images/boo-stopped"));

            for (int i = 1; i <= 8; i++)
            {
                ghostTextures.Add(Content.Load<Texture2D>("Images/boo-move-" + i));
            }

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            mouseState = Mouse.GetState();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
