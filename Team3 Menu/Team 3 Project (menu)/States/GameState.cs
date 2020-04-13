using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_3_Project__menu_.Models;


namespace Team_3_Project__menu_.States
{
    public class GameState : State
    {
        //This is the class where all of our new game content will be loaded in (just stick with this one class if possible sinces we're just looking at 1 level,
        //multiple classes will need to be used once multiple enemies/levels/functions are created to ensure we dont have mile long classes)




        //Honestly dont think I've ever really put anything in this class, believe it just initializes game and content for use like: Game1.ScreenWidth || game.ScreenWidth,
        //as well as our content for loding in textures from ContentManagerPipeline
        public GameState(Game1 game, ContentManager content)
          : base(game, content)
        {
        }


        //All sprites/ bullets/ everything will be loaded in here
        //Lists such as this:
        //private List<Player> _players;
        //help with cleanliness in our load content and other methods, such as:
        /// <summary>
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

            


        }


        


        //All Sprites drawn inside here
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //Draws all Sprites in Sprite list, layering them in the order that they are drawn,
            //this is just leftover code from another proj of mine, a plain ol spriteBatch.Begin() works just as well for our purposes (I believe)
            spriteBatch.Begin(SpriteSortMode.FrontToBack);



            spriteBatch.End();


        }



        //Used for functions such as ones which send top scores to HighscoreState after all players/ (whatever your parameter is) / has died/ has won/ etc.
        public override void PostUpdate(GameTime gameTime)
        {

        }



        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                _game.ChangeState(new MenuState(_game, _content));





        }
    }
}
