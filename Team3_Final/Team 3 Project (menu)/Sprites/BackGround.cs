using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Team_3_Project__menu_.Animation;
using Team_3_Project__menu_.Models;

namespace Team_3_Project__menu_.Sprites
{
    public class BackGround : Component, ICloneable
    {

        //Sam - All information is currently exactly the same as PlayerCharacter.cs


        #region Fields
        //Sam - Both used in layer / rotation / origin / other functions
        protected Dictionary<string, Animation.Animation> _animations;

        protected AnimationManager _animationManager;
        protected Vector2 _position;
        protected Texture2D _texture;
        protected float _layer { get; set; }
        protected Vector2 _origin { get; set; }
        protected float _rotation { get; set; }
        protected float _scale { get; set; }


        public Color Color { get; set; }
        public bool IsRemoved { get; set; }
        public Input Input;
        public Vector2 Velocity;
        public float Speed = 2f;

        #endregion

        #region Properties

        public float Layer
        {
            get { return _layer; }
            set
            {
                _layer = value;

                if (_animationManager != null)
                    _animationManager.Layer = _layer;
            }
        }

        public Vector2 Origin
        {
            get { return _origin; }
            set
            {
                _origin = value;

                if (_animationManager != null)
                    _animationManager.Origin = _origin;
            }
        }

        public Rectangle Rectangle
        {
            get
            {



                if (_texture != null)
                {
                    return new Rectangle((int)Position.X - (int)Origin.X, (int)Position.Y - (int)Origin.Y, _texture.Width, _texture.Height);
                }

                if (_animationManager != null)
                {
                    var animation = _animations.FirstOrDefault().Value;

                    return new Rectangle((int)Position.X - (int)Origin.X, (int)Position.Y - (int)Origin.Y, animation.FrameWidth, animation.FrameHeight);
                }


                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);

                throw new Exception("Unknown sprite");
            }

        }

        public float Rotation
        {
            get { return _rotation; }
            set
            {
                _rotation = value;

                if (_animationManager != null)
                    _animationManager.Rotation = value;
            }
        }

        public readonly Color[] TextureData;

        public Matrix Transform
        {
            get
            {
                return Matrix.CreateTranslation(new Vector3(-Origin, 0)) *
                  Matrix.CreateRotationZ(_rotation) *
                  Matrix.CreateTranslation(new Vector3(Position, 0));
            }
        }


        /// <summary>
        /// The area of the sprite that could "potentially" be collided with
        /// </summary>
        public Rectangle CollisionArea
        {
            get
            {
                return new Rectangle(Rectangle.X, Rectangle.Y, MathHelper.Max(Rectangle.Width, Rectangle.Height), MathHelper.Max(Rectangle.Width, Rectangle.Height));
            }
        }


        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;

                if (_animationManager != null)
                    _animationManager.Position = _position;
            }
        }



        #endregion






        public BackGround(Texture2D texture)
        {
            _texture = texture;


            Origin = new Vector2(_texture.Width / 2, _texture.Height / 2);

            Color = Color.White;

            TextureData = new Color[_texture.Width * _texture.Height];
            _texture.GetData(TextureData);
        }

        public BackGround(Dictionary<string, Animation.Animation> animations)
        {
            _texture = null;


            Color = Color.White;

            TextureData = null;

            _animations = animations;

            var animation = _animations.FirstOrDefault().Value;

            _animationManager = new AnimationManager(animation);

            Origin = new Vector2(animation.FrameWidth / 2, animation.FrameHeight / 2);
        }



        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (_texture != null)
                spriteBatch.Draw(_texture, Position, null, Color, _rotation, Origin, 1f, SpriteEffects.None, Layer);
            else if (_animationManager != null)
                _animationManager.Draw(spriteBatch);


            // spriteBatch.Draw(_texture, Position, Color.White);
            //spriteBatch.Draw(_texture, Position, Color.White);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_texture != null)
                spriteBatch.Draw(_texture, Position, Color.White);
            else if (_animationManager != null)
                _animationManager.Draw(spriteBatch);
            else throw new Exception("This ain't right..!");
        }




        //PlayerCharacter classes

        public virtual void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Input.Up))
                Velocity.Y = Speed;
            else if (Keyboard.GetState().IsKeyDown(Input.Down))
                Velocity.Y = -Speed;
            else if (Keyboard.GetState().IsKeyDown(Input.Left))
                Velocity.X = Speed;
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
                Velocity.X = -Speed;


            if (Keyboard.GetState().IsKeyDown(Input.Up) && Keyboard.GetState().IsKeyDown(Input.Left))
            {

                Velocity.Y = Speed;
                Velocity.X = Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Up) && Keyboard.GetState().IsKeyDown(Input.Right))
            {

                Velocity.Y = Speed;
                Velocity.X = -Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Down) && Keyboard.GetState().IsKeyDown(Input.Left))
            {

                Velocity.Y = -Speed;
                Velocity.X = Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Down) && Keyboard.GetState().IsKeyDown(Input.Right))
            {

                Velocity.Y = -Speed;
                Velocity.X = -Speed;
            }

        }

        



        public virtual void Update(GameTime gameTime, List<BackGround> _sprites)
        {

            Move();
            
            

            Position += Velocity;
            Velocity = Vector2.Zero;
        }

        public override void Update(GameTime gameTime)
        {
        }




        //public virtual void OnCollide(Sprite sprite)
        //{

        //}

        public object Clone()
        {
            var sprite = this.MemberwiseClone() as BackGround;

            

            return sprite;
        }

    }
}

