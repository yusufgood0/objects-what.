using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace objects__what_
{
    public static class Functions
    {
        public static Rectangle Vector2toRectangle(Vector2 Position, int _width, int _height)
        {
            return new((int)(Position.X - _width / 2), (int)(Position.Y - _height / 2), _width, _height);
        }
        public static Vector2 RectangleToVector2(Rectangle _rectangle)
        {
            return new Vector2(_rectangle.X + _rectangle.Width / 2, _rectangle.Y + _rectangle.Height / 2);

        }
    }
    class PlayerClass
    {
        static Random random = new Random();
        Vector2 _position = new(random.Next(20, 200), random.Next(20, 200));
        Texture2D _texture;
        public PlayerClass(Texture2D texture)
        {
            _texture = texture;
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(_texture, 
                Functions.Vector2toRectangle(_position, 20, 20), 
                null,
                Color.Wheat
                );
        }

        public void Move(Vector2 change)
        {
            _position += change;
        }
    }
    public class Game1 : Game
    {
        private static GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<PlayerClass> _playerClassList = new();
        private static GraphicsDevice _graphicsDevice;
        private static Texture2D blankTexture;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // fill the texture with a specific color.;
            blankTexture = Content.Load<Texture2D>("circle");

            // creates 20 playerclass objects
            for (int i = 0; i < 20; i++)
            {
                _playerClassList.Add(new PlayerClass(blankTexture));
            }
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (PlayerClass i in _playerClassList)
            {
                i.Move(new Vector2(1, 1));
            }
                // TODO: Add your update logic here

                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            foreach (PlayerClass i in _playerClassList)
            {
                i.Draw(_spriteBatch);
            }
            // TODO: Add your drawing code here
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
