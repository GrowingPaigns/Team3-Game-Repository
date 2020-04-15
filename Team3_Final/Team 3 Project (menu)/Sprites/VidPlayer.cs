using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_3_Project__menu_.Animation;
using Team_3_Project__menu_.Models;

namespace Team_3_Project__menu_.Sprites
{
    class VidPlayer : AnimatedSprite
    {

        //This class defines what exactly our sprite animation(s) will be

        //Updates position of spritesheet based on fps
        public VidPlayer(Vector2 position) : base(position)
        {
            //how many frames play per sec
            FramesPerSecond = 3;
        }

        //Loads actual sheet texture
        public void LoadContent(ContentManager content)
        {
            sTexture = content.Load<Texture2D>("planets");
            //Half of max frames in animation (cant figure out how to get it to run through all 20 frames, 
            //making it 20 draws weird animations, and 10 is the only one which looks really stable)
            AddAnimation(10);
        }

    }
}
