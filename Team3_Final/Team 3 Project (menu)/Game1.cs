using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Team_3_Project__menu_.States;
using Team_3_Project__menu_.Models;
using System;
using System.Collections.Generic;
using Team_3_Project__menu_.Sprites;
using Microsoft.Xna.Framework.Media;
using System.Linq;

namespace Team_3_Project__menu_
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        //Sam - (Pretty much everything will need these)
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public GraphicsDevice device;
        //Sam - Most actual game stuff will be defined within GameState
        Color color;



        //Sam - Menu Vars
        private State _currentState;
        private State _nextState;

        //Sam - Screen size vars
        public static int ScreenWidth = 1280;
        public static int ScreenHeight = 960;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //Sam - akes graphics high def, dont think this is currently needed, old code from sheet experimentation
            graphics.GraphicsProfile = GraphicsProfile.HiDef;
        }




        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {


            //Sam - Initializes + applies screen height
            graphics.PreferredBackBufferWidth = ScreenWidth;
            graphics.PreferredBackBufferHeight = ScreenHeight;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();


            
            color = new Color(255, 255, 255);

            IsMouseVisible = true;
            

            base.Initialize();
        }



        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //Sam - Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            

            _currentState = new MenuState(this, Content);
            _currentState.LoadContent();
            _nextState = null;

            //vid = Content.Load<Video>("");
            
        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }




        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            

            if (_nextState != null)
            {
                _currentState = _nextState;
                _currentState.LoadContent();

                _nextState = null;
            }

            _currentState.Update(gameTime);
            _currentState.PostUpdate(gameTime);

         
            base.Update(gameTime);
        }





        public void ChangeState(State state)
        {
            _nextState = state;
        }




        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //Sam - Plain BG, little nicer than cornflowerblue
            GraphicsDevice.Clear(new Color(51, 153, 218));

            _currentState.Draw(gameTime, spriteBatch);

            

            base.Draw(gameTime);
        }



        
    }
}
