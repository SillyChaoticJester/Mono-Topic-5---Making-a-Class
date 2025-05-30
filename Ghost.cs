﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_Topic_5___Making_a_Class
{
    public class Ghost
    {
        private List<Texture2D> _textures;
        private Vector2 _speed;
        private Rectangle _location;
        private int _textureIndex;
        private SpriteEffects _direction;
        private float _animationSpeed;
        private float _seconds;
        private float _opacity;

        public Ghost(List<Texture2D> textures, Rectangle location)
        {
            _textures = textures;
            _location = location;
            _textureIndex = 0;
            _speed = Vector2.Zero;
            _direction = SpriteEffects.None;
            _animationSpeed = 0.2f;
            _seconds = 0;
            _opacity = 1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_textures[_textureIndex], _location, null, Color.White * _opacity, 0f, Vector2.Zero, _direction, 1);
        }

        public void Update(GameTime gameTime, MouseState mouseState)
        {
            _speed = Vector2.Zero;
            if (mouseState.X < _location.X)
            {
                _direction = SpriteEffects.FlipHorizontally;
                _speed.X = -1;
            }
            else if (mouseState.X > _location.X)
            {
                _direction = SpriteEffects.None;
                _speed.X = 1;
            }
            if (mouseState.Y < _location.Y)
            {
                _speed.Y = -1;
            }
            else if (mouseState.Y > _location.Y)
            {
                _speed.Y = 1;
            }
            if (mouseState.LeftButton == ButtonState.Released)
            {
                _speed = Vector2.Zero;
                _textureIndex = 0;
                _seconds = 0f;
                _opacity = 0.3f;
            }
            else if (_speed != Vector2.Zero)
            {
                _seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (_seconds > _animationSpeed)
                {
                    _seconds = 0;
                    _opacity = 1;
                    _textureIndex++;
                    if (_textureIndex >= _textures.Count)
                    {
                        _textureIndex = 1;
                    }
                }
            }
            _location.Offset(_speed);
        }

        public Rectangle Rect
        {
            get { return _location; }
        }

        public bool Contains(Point point)
        {
            return _location.Contains(point);
        }

        public bool Intersects(Rectangle player)
        {
            return _location.Intersects(player);
        }

    }

}
