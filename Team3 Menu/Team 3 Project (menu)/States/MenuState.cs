
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Team_3_Project__menu_.Controls;
using Team_3_Project__menu_.Models;
using Team_3_Project__menu_.Sprites;

namespace Team_3_Project__menu_.States
{
    public class MenuState : State
    {
        private List<Component> _components;
        Player player;
        private Song bgSong;


        public MenuState(Game1 game, ContentManager content)
          : base(game, content)
        {
           
        }



        public override void LoadContent()
        {
            //var just makes a variable (hence the name) which holds a piece of content be that a texture, song, or theres even ways to use an Animation method if you have the sprite editor Aseprite
            var newGame = _content.Load<Texture2D>("Buttons/New Game");
            var options = _content.Load<Texture2D>("Buttons/Options");
            var highScores = _content.Load<Texture2D>("Buttons/HighScores");
            var quitGame = _content.Load<Texture2D>("Buttons/Quit Game");

            var topBorder = _content.Load<Texture2D>("TopBorder");
            var title = _content.Load<Texture2D>("JupiterTitle");

            var buttonFont = _content.Load<SpriteFont>("Buttons/Font");

            
            //Loads Menu Song (need to make it not start over everytime MenuState is triggered, and need to make it loop indefinitely (otherwise functional))
            bgSong = _content.Load<Song>("29MinsToJupiter");
            MediaPlayer.Play(bgSong);
            {
                //maybe where i'll be setting up the loop method(?)
            };


            //loads in sprite sheet (for some reason my spritesheet origin is at its very top left corner, which will mean this is loaded at (0,0) rather than center screen
            player = new Player(new Vector2(0, 0));
            //loads in the texture from Player.cs
            player.LoadContent(_content);


            _components = new List<Component>()
            {


                //Currently these sprites are defined as Buttons because i wanted to get the menu to yall, I will change this at a later point once I create a gen. Sprite class
                //Loads Button texture and font as well as position and what happens if you click the Button
                new Button(topBorder, buttonFont)
                {
                    Text = "",
                    Position = new Vector2((Game1.ScreenWidth / 2), 0),
                    //Click = new EventHandler(Button_NewGame_Clicked),
                    Layer = 0.5f
                },

                new Button(title, buttonFont)
                {
                    Text = "",
                    Position = new Vector2((Game1.ScreenWidth / 2), 120),
                    //Click = new EventHandler(Button_NewGame_Clicked),
                    Layer = 0.5f
                },




                //Actual buttons Which send to different States (options currently not functional, 
                //using an unimplemented method, will change at a later point incorporating sounds and music volume changer)
                new Button(newGame, buttonFont)
                {
                    Text = "",
                    Position = new Vector2((Game1.ScreenWidth / 2), 350),
                    Click = new EventHandler(Button_NewGame_Clicked),
                    Layer = 0.5f
                },
                new Button(options, buttonFont)
                {
                    Text = "",
                    Position = new Vector2((Game1.ScreenWidth / 2), 430),
                    Click = new EventHandler(Button_LoadGame_Clicked),
                    Layer = 0.5f
                },
                new Button(highScores, buttonFont)
                {
                    Text = "",
                    Position = new Vector2(640, 510),
                    Click = new EventHandler(Button_Highscores_Clicked),
                    Layer = 0.5f
                },
                new Button(quitGame, buttonFont)
                {
                    Text = "",
                    Position = new Vector2(Game1.ScreenWidth / 2, (Game1.ScreenHeight / 2) + 110),
                    Click = new EventHandler(Button_Quit_Clicked),
                    Layer = 0.5f
                },
            };

            
        }



        //Details the event of changing state
        private void Button_NewGame_Clicked(object sender, EventArgs args)
        {
            _game.ChangeState(new GameState(_game, _content));
        }

        private void Button_LoadGame_Clicked(object sender, EventArgs args)
        {
            Console.WriteLine("Load Game");
        }

        private void Button_Highscores_Clicked(object sender, EventArgs args)
        {
            _game.ChangeState(new HighscoresState(_game, _content));
        }

        private void Button_Quit_Clicked(object sender, EventArgs args)
        {
            _game.Exit();
        }




        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack);


            player.Draw(spriteBatch);

            //Example of Drawing a list such as (somewhat) described in GameState
            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            spriteBatch.Begin();

            spriteBatch.End();

        }

        //Same List example which helps clean up everything (high lvl code which I dont even fully understand, dont feel like you have to use lists)
        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);

            player.Update(gameTime);

        }


        public override void PostUpdate(GameTime gameTime)
        {
            // remove sprites if they're not needed
        }





    }
}
