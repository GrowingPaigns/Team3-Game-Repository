using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_3_Project__menu_.Controls
{
    public class Button : Component
    {
        #region Fields
        
        //Used to gray out Button(s)
        private MouseState _currentMouse;
        private bool _isHovering;
        private MouseState _previousMouse;

        private SpriteFont _font;
        
        private Texture2D _texture;

        #endregion

        #region Properties
        //Sam - Checks Mouse Status
        public EventHandler Click;
        public bool Clicked { get; private set; }

        //Sam - Sets how far forward or back you want Button sprite sitting
        public float Layer { get; set; }

        //Sam - Basically the Buttons 'pivot point' when rotating (I think)
        public Vector2 Origin
        {
            get
            {
                return new Vector2(_texture.Width / 2, _texture.Height / 2);
            }
        }

        //Sam - Used for drawing Button(?)
        public Color PenColour { get; set; }
        public Vector2 Position { get; set; }

        //Sam - Gets Button Texture
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X - ((int)Origin.X), (int)Position.Y - (int)Origin.Y, _texture.Width, _texture.Height);
            }
        }

        //Sam - for text on Buttons (currently disabled as I made custom text directly on each Button Sprite
        public string Text;

        #endregion

        #region Methods
        //Sam - Button Class, initializes vars
        public Button(Texture2D texture, SpriteFont font)
        {
            _texture = texture;

            _font = font;

            PenColour = Color.Black;
        }

        //Sam - Draws different pieces of Button
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var color = Color.White;

            //Sam - Changes color to (specefied color)
            if (_isHovering)
                color = Color.Gray;

            //Sam - Specifically what is called in drawing the Button
            spriteBatch.Draw(_texture, Position, null, color, 0f, Origin, 1f, SpriteEffects.None, Layer);

            if (!string.IsNullOrEmpty(Text))
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);

                //Sam - Draws with text, if included in class definition(MainMenu.cs)(I think)
                spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColour, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, Layer + 0.01f);
            }
        }

        //Sam - Updates all Button functions such as click state(state of game/ menu) and IsHovering
        public override void Update(GameTime gameTime)
        {
            //Sam - (not sure why we assign previousMouse to current here (but its needed!))
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            //Sam - Mouse 'Hitbox'
            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            //Sam - Defaults IsHovering to false
            _isHovering = false;

            //Sam - What happens if mouse intersects button rectangle
            if (mouseRectangle.Intersects(Rectangle))
            {
                _isHovering = true;

                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }

        #endregion
    }
}
