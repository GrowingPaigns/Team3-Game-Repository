
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_3_Project__menu_.Animation
{
    public class Animation : ICloneable
    {
        //Sam - The frame that we are on
        public int CurrentFrame { get; set; }
        //Sam - Total Frames
        public int FrameCount { get; private set; }
        //Sam - How tall is your animation
        public int FrameHeight { get { return Texture.Height; } }
        //Sam - How fast do you want the animation
        public float FrameSpeed { get; set; }
        //Sam - How wide is your animation (gets / frramecount to cut off all other sprites but the frame we want to play)
        public int FrameWidth { get { return Texture.Width / FrameCount; } }
        //Sam - Loops animation
        public bool IsLooping { get; set; }
        //Sam - Animation picture
        public Texture2D Texture { get; private set; }

        //Sam - Assigns default values for use
        public Animation(Texture2D texture, int frameCount)
        {
            Texture = texture;

            FrameCount = frameCount;

            IsLooping = true;

            FrameSpeed = 0.15f;
        }

        //Sam - not quite sure what clones are used for
        public object Clone()
        {
            return this.MemberwiseClone();
        }






    }
}
