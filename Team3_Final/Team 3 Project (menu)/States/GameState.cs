
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using Team_3_Project__menu_.Models;
using Team_3_Project__menu_.Sprites;

namespace Team_3_Project__menu_.States
{
    public class GameState : State
    {

        //Sam - BackGround backGround;
        KeyboardState keyBoardState = Keyboard.GetState();
        private List<PlayerCharacter> playerCharacter;
        private List<BackGround> backGround;
        

        //Sam - This is the class where all of our new game content will be loaded in (just stick with this one class if possible sinces we're just looking at 1 level,
        //Sam - multiple classes will need to be used once multiple enemies/levels/functions are created to ensure we dont have mile long classes)

        private Song bgSong;



        //Sam - Honestly dont think I've ever really put anything in this class, believe it just initializes game and content for use like: Game1.ScreenWidth || game.ScreenWidth,
        //Sam - as well as our content for loding in textures from ContentManagerPipeline
        public GameState(Game1 game, ContentManager content)
          : base(game, content)
        {
        }






        //Sam - All sprites/ bullets/ everything will be loaded in here
        //Sam - Lists such as this:
        //Sam - private List<Player> _players;
        //Sam - help with cleanliness in our load content and other methods, such as:
        ///Sam - 
        ///    if (_players.All(c => c.IsDead))
        ///    {
        ///        foreach (var player in _players)
        ///            _scoreManager.Add(player.Score);
        ///
        ///        ScoreManager.Save(_scoreManager);
        ///
        ///        _game.ChangeState(new HighscoresState(_game, _content));
        ///    }
        /// </summary>
        /// Which is a method (when combined with a class of course) that tracks a player's score, also can be used in ways such as:
        /// load all players in _players, which is one way the method in Input.cs can be loaded in a gamestate class
        public override void LoadContent()
        {

            

            bgSong = _content.Load<Song>("BattleTheme");
            MediaPlayer.Play(bgSong);
            {
                MediaPlayer.IsRepeating = true;
            };
            //Sam - var just makes a variable (hence the name) which holds a piece of content be that a texture, song, or theres even ways to use an Animation method if you have the sprite editor Aseprite



            /*
            Texture2D stars1 = _content.Load<Texture2D>("stars1");
            layers = new List<BackgroundScrollingLayer> {
                { new BackgroundScrollingLayer(_content.Load<Texture2D>("space"), new Rectangle(0, 0, 2048, 1536),30) },
                { new BackgroundScrollingLayer(stars1, new Rectangle(0, 0, 2560, 2560),10) },
                { new BackgroundScrollingLayer(stars1, new Rectangle(0, 0, 2560, 2560),5) },
                { new BackgroundScrollingLayer(_content.Load<Texture2D>("stars2"), new Rectangle(0, 0, 2560, 2560),15) },
            };
            */

            playerCharacter = new List<PlayerCharacter>()
            {

                

            new PlayerCharacter(new Dictionary<string, Animation.Animation>()
                {
                  { "WalkUp", new Animation.Animation(_content.Load<Texture2D>("Player/PlayerLeft"), 6) },
                  { "WalkDown", new Animation.Animation(_content.Load<Texture2D>("Player/PlayerRight"), 6) },
                  { "WalkLeft", new Animation.Animation(_content.Load<Texture2D>("Player/PlayerLeft"), 6) },
                  { "WalkRight", new Animation.Animation(_content.Load<Texture2D>("Player/PlayerRight"), 6) },
                  { "Idle", new Animation.Animation(_content.Load<Texture2D>("Player/PlayerIdle"), 6) },
                })
                {
                  Position = new Vector2(Game1.ScreenWidth/2, Game1.ScreenHeight/2),
                 
                  Layer = 0.8f,
                  Input = new Input()
                  {
                    Up = Keys.W,
                    Down = Keys.S,
                    Left = Keys.A,
                    Right = Keys.D,
                  },
                },


                

            };


            backGround = new List<BackGround>()
            {


                new BackGround(_content.Load<Texture2D>("space"))
                {

                  Position = new Vector2(0, - 100),

                  Layer = 0.0f,

                  Input = new Input()
                  {
                    Up = Keys.Up,
                    Down = Keys.Down,
                    Left = Keys.Left,
                    Right = Keys.Right,
                  },

                },


                new BackGround(_content.Load<Texture2D>("stars1"))
                {

                  Position = new Vector2(0, - 100),

                  Layer = 0.0f,
                  Speed = .2f,
                  Input = new Input()
                  {
                    Up = Keys.W,
                    Down = Keys.S,
                    Left = Keys.A,
                    Right = Keys.D,
                  },

                },

                 new BackGround(_content.Load<Texture2D>("stars2"))
                {

                  Position = new Vector2(0, - 100),

                  Layer = 0.0f,
                  Speed = .5f,
                  Input = new Input()
                  {
                    Up = Keys.W,
                    Down = Keys.S,
                    Left = Keys.A,
                    Right = Keys.D,
                  },

                },


                new BackGround(_content.Load<Texture2D>("29minsMap"))
                {
                  
                  Position = new Vector2(-200,0),
                  
                  Layer = 0.1f,
                  Input = new Input()
                  {
                    Up = Keys.W,
                    Down = Keys.S,
                    Left = Keys.A,
                    Right = Keys.D,
                  },
                },



            };





        }




        public void Update(GameTime gameTime, Viewport viewport)
        {
            
            
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                _game.ChangeState(new MenuState(_game, _content));

            //Sam - backGround.Update(gameTime);


            foreach (var sprite in backGround)
                sprite.Update(gameTime, backGround);

            foreach (var sprite in playerCharacter)
                sprite.Update(gameTime, playerCharacter);
        }




        //Sam - All Sprites drawn inside here
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //Sam - Draws all Sprites in Sprite list, layering them in the order that they are drawn,
            
            spriteBatch.Begin();
            //backGround.Draw(gameTime, spriteBatch);

            foreach (var sprite in backGround)
                sprite.Draw(spriteBatch);

            foreach (var sprite in playerCharacter)
                sprite.Draw(spriteBatch);
            
           

            spriteBatch.End();


            



        }




        //Sam - Used for functions such as ones which send top scores to HighscoreState after all players/ (whatever your parameter is) / has died/ has won/ etc.
        public override void PostUpdate(GameTime gameTime)
        {
          
        }

       






    }
}
