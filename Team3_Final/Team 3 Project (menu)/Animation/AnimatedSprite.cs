using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_3_Project__menu_.Animation
{
    abstract class AnimatedSprite
    {
        //Sam - Necessities in sprite sheet animations
        protected Texture2D sTexture;
        private Vector2 sPosition;
        private Rectangle[] sRectangles;
        private int frameIndex;

        //Sam - used for cycling image
        private double timeElapsed;
        private double timeToUpdate;

        //Sam - Collects how many frames to play (of Animation) per sec
        public int FramesPerSecond
        {
            set { timeToUpdate = (1f / value); }
        }


        //Sam - Assigns Animation's position
        public AnimatedSprite(Vector2 position)
        {
            sPosition = position;
        }

        //Sam - Where we load our animation
        public void AddAnimation(int frames)
        {
            //Sam - Width of spritesheet, divided by how many frames are in a single row
            int width = sTexture.Width / frames;

            //Sam - the rectangle of sprite sheet
            sRectangles = new Rectangle[frames];

            //Sam - Just runs through the animations
            for (int i = 0; i < frames; i++)
            {
                sRectangles[i] = new Rectangle(i * width, 0, width, sTexture.Height);
            }
        }

        //Sam - Updates our animations
        public void Update(GameTime gameTime)
        {

            //Sam - time since last update
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;

            if (timeElapsed > timeToUpdate)
            {
                timeElapsed -= timeToUpdate;

                //Sam - sheet length = 6,  biggest index = 5
                if (frameIndex < sRectangles.Length - 1)
                {
                    frameIndex++;
                }
                else
                {
                    frameIndex = 0;
                }
            }

        }

        //Sam - Initializes draw
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sTexture, sPosition, sRectangles[frameIndex], Color.White);
        }




    }
}
