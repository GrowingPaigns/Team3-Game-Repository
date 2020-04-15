using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_3_Project__menu_.States
{
    public abstract class State
    {
        //Sam - Class which initializes all State variable throughout State classes

        protected ContentManager _content;
        protected Game1 _game;


        public abstract void LoadContent();



        public abstract void Update(GameTime gameTime);

        public abstract void PostUpdate(GameTime gameTime);

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public State(Game1 game, ContentManager content)
        {
            _game = game;


            _content = content;
        }


    }
}
