using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Team_3_Project__menu_.Controls;

namespace Team_3_Project__menu_.States
{
    public class HighscoresState : State
    {
        private List<Component> _components;

        private SpriteFont _font;
        
        //This class will be hard to integrate without a solid Score class defining what our score method is.
        //For now lets leave all score methods alone (purely vanity classes which just load their state), and focus on smooth, fun gameplay



        public HighscoresState(Game1 game, ContentManager content)
          : base(game, content)
        {
        }



        public override void LoadContent()
        {
            _font = _content.Load<SpriteFont>("Buttons/Font");
            

            var buttonTexture = _content.Load<Texture2D>("Buttons/MainMenu(button)");
            var buttonFont = _content.Load<SpriteFont>("Buttons/Font");

            _components = new List<Component>()
      {
        new Button(buttonTexture, buttonFont)
        {
          Text = "",
          Position = new Vector2(Game1.ScreenWidth / 2, 800),
          Click = new EventHandler(Button_MainMenu_Clicked),
          Layer = 0.1f
        },
      };
        }



        private void Button_MainMenu_Clicked(object sender, EventArgs args)
        {
            _game.ChangeState(new MenuState(_game, _content));
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Button_MainMenu_Clicked(this, new EventArgs());

            foreach (var component in _components)
                component.Update(gameTime);
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack);

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.FrontToBack);
            

            spriteBatch.End();
        }
    }
}
