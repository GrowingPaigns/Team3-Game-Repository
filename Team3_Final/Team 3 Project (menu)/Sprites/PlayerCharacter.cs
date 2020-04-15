using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_3_Project__menu_.Animation;
using Team_3_Project__menu_.Models;

namespace Team_3_Project__menu_.Sprites
{
    public class PlayerCharacter : ICloneable
    {
        #region Fields

        private KeyboardState _currentKey;
        private KeyboardState _previousKey;
        private float _shootTimer = 0;

        //Sam - Both used in layer / rotation / origin / other functions
        protected Dictionary<string, Animation.Animation> _animations;
        protected AnimationManager _animationManager;

        //Sam - Player defaults
        protected Vector2 _position;
        protected Texture2D _texture;
        protected float _layer { get; set; }
        protected Vector2 _origin { get; set; }
        protected float _rotation { get; set; }
        protected float _scale { get; set; }

        //Sam - Other Player vars
        public Color Color { get; set; }
        public bool IsRemoved { get; set; }
        public Input Input;
        public Vector2 Velocity;
        public float Speed = 1f;


        #endregion

        #region Properties




        //Sam - allows player to set how far forward the sprite is drawn (except when using multiple menus, those must be drawn in preferred order in gamestate
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

        //Sam - Sets where the texture is loaded to on screen
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

        //Sam - collects the player's outer 'hitbox' / edge
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

        //Sam - Allows rotation of any sprite
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





        //Sam - Sets 'animation' position, for movement
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






        public PlayerCharacter(Texture2D texture) 
        {
            _texture = texture;


            Origin = new Vector2(_texture.Width / 2, _texture.Height / 2);

            Color = Color.White;

            TextureData = new Color[_texture.Width * _texture.Height];
            _texture.GetData(TextureData);


            

        }


        

        public PlayerCharacter(Dictionary<string, Animation.Animation> animations)
        {
            _texture = null;


            Color = Color.White;

            TextureData = null;

            _animations = animations;

            var animation = _animations.FirstOrDefault().Value;

            _animationManager = new AnimationManager(animation);

            Origin = new Vector2(animation.FrameWidth / 2, animation.FrameHeight / 2);
        }



        

        public  void Draw(SpriteBatch spriteBatch)
        {
            if (_texture != null)
                spriteBatch.Draw(_texture, Position, Color.White);
            else if (_animationManager != null)
                _animationManager.Draw(spriteBatch);
            else throw new Exception("This ain't right..!");

            
        }




        //Sam - PlayerCharacter classes

        public virtual void Move(GameTime gameTime)
        {
            _previousKey = _currentKey;
            _currentKey = Keyboard.GetState();

            _shootTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            var velocity = Vector2.Zero;
            _rotation = 0;

            _shootTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;


            if (Keyboard.GetState().IsKeyDown(Input.Up))
                Velocity.Y = -Speed;
            else if (Keyboard.GetState().IsKeyDown(Input.Down))
                Velocity.Y = Speed;
            else if (Keyboard.GetState().IsKeyDown(Input.Left))
                Velocity.X = -Speed;
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
                Velocity.X = Speed;

            //Sam - where shoot definitions will go
            if (_currentKey.IsKeyDown(Input.Shoot) && _shootTimer > 1.25f)
            {
                /*
                //for some reason this makes player2's speed increase when pressing shoot
                //Speed = 8f; 
                Shoot(Speed);
                _shootTimer = 0f;
                */
            }



            //TL
            if (Keyboard.GetState().IsKeyDown(Input.Up) && Keyboard.GetState().IsKeyDown(Input.Left))
            {

                Velocity.Y = -Speed;
                Velocity.X = -Speed;
            }
            //TR
            else if (Keyboard.GetState().IsKeyDown(Input.Up) && Keyboard.GetState().IsKeyDown(Input.Right))
            {

                Velocity.Y = -Speed;
                Velocity.X = Speed;
            }
            //BL
            else if (Keyboard.GetState().IsKeyDown(Input.Down) && Keyboard.GetState().IsKeyDown(Input.Left))
            {

                Velocity.Y = Speed;
                Velocity.X = -Speed;
            }
            //BR
            else if (Keyboard.GetState().IsKeyDown(Input.Down) && Keyboard.GetState().IsKeyDown(Input.Right))
            {

                Velocity.Y = Speed;
                Velocity.X = Speed;
            }

        }

        protected virtual void SetAnimations()
        {
            if (Velocity.X > 0)
                _animationManager.Play(_animations["WalkRight"]);
            else if (Velocity.X < 0)
                _animationManager.Play(_animations["WalkLeft"]);
            else if (Velocity.Y > 0)
                _animationManager.Play(_animations["WalkDown"]);
            else if (Velocity.Y < 0)
                _animationManager.Play(_animations["WalkUp"]);
            else _animationManager.Play(_animations["Idle"]);


        }


        //Sam - Updates all movement, animations
        public virtual void Update(GameTime gameTime, List<PlayerCharacter> _sprites)
        {

            Move(gameTime);

            SetAnimations();

            _animationManager.Update(gameTime);

            Position += Velocity;
            Velocity = Vector2.Zero;

            

           

        }
        


        

        public object Clone()
        {
            var sprite = this.MemberwiseClone() as PlayerCharacter;

            if (_animations != null)
            {
                sprite._animations = this._animations.ToDictionary(c => c.Key, v => v.Value.Clone() as Animation.Animation);
                sprite._animationManager = sprite._animationManager.Clone() as AnimationManager;
            }

            return sprite;
        }












    }

}
