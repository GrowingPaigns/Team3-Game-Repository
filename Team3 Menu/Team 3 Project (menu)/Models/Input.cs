using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_3_Project__menu_.Models
{
    public class Input
    {
        //An input class used primarily for player movement if there will be multiple players on screen at once
        /// <summary>
        /// Example of a player class which inherits input, being loaded in gamestate under LoadContent
        /// Currently not being used (thought I was gonna use it to try and figure out BG (BackGround) sprites, by understanding moving player sprites)
        /// 
        ///    if (PlayerCount >= 1)
        ///    {
        ///        _sprites.Add(new Player(playerTexture)
        ///        {
        ///    Position = new Vector2(100, 360),
        ///            Layer = 0.3f,
        ///            Bullet = bulletPrefab,
        ///            Input = new Models.Input()
        ///            {
        ///                Up = Keys.W,
        ///                Down = Keys.S,
        ///                Left = Keys.A,
        ///                Right = Keys.D,
        ///                Shoot = Keys.Space,
        ///            },
        ///            Health = 10,
        ///            Score = new Models.Score(_font)
        ///            {
        ///                PlayerName = "Player 1",
        ///                Value = 0,
        ///            },
        ///        });
        ///               
        ///    }
        /// </summary>

    public Keys Down { get; set; }

        public Keys Left { get; set; }

        public Keys Right { get; set; }

        public Keys Up { get; set; }
    }
}
