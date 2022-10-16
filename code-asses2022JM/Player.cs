using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace code_asses2022JM
{
    class Player
    {
        // declare fields to use in the class

        public int x, y, width, height;//variables for the rectangle
        public Image player;//variable for the planet's image

        public Rectangle playerRec;//variable for a rectangle to place our image in

        //Create a constructor (initialises the values of the fields)
        public Player()
        {
            x = 10;
            y = 350;
            width = 40;
            height = 40;
            player = Properties.Resources.rocket;
            playerRec = new Rectangle(x, y, width, height);
        }
        public void DrawPlayer(Graphics g)
        {

            g.DrawImage(player, playerRec);
        }

        public void MovePlayer(int mouseX)
        {
            playerRec.X = mouseX - (playerRec.Width / 2);
        }

        //public void MovePlayer(string move)
        //{
        //    playerRec.Location = new Point(x, y);

        //    if (move == "right")
        //    {
        //        if (playerRec.Location.X > 450) // is spaceship within 50 of right side
        //        {

        //            x = 450;
        //            playerRec.Location = new Point(x, y);
        //        }
        //        else
        //        {
        //            x += 5;
        //            playerRec.Location = new Point(x, y);
        //        }

        //    }


        //    if (move == "left")
        //    {
        //        if (playerRec.Location.X < 10) // is spaceship within 10 of left side
        //        {

        //            x = 10;
        //            playerRec.Location = new Point(x, y);
        //        }
        //        else
        //        {
        //            x -= 5;
        //            playerRec.Location = new Point(x, y);
        //        }

        //    }

    }


    
}
