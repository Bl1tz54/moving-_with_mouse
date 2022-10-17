using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace code_asses2022JM
{
    class Enemy
    {

        // declare fields to use in the class
        public int x, y, width, height;//variables for the rectangle
        public Image alienImage;//variable for the planet's image

        public Rectangle alienRec;//variable for a rectangle to place our image in
        public int score;
        //Create a constructor (initialises the values of the fields)
        public Enemy(int spacing)
        {
            x = spacing;
            y = 10;
            width = 25;
            height = 25;
            //planetImage contains the plane1.png image
            alienImage = Properties.Resources.alien;
            alienRec = new Rectangle(x, y, width, height);
        }



        // Methods for the Planet class
        public void DrawEnemy(Graphics g)
        {
            alienRec = new Rectangle(x, y, width, height);
            g.DrawImage(alienImage, alienRec);
        }


        public void MoveEnemy(int rndmspeed)
        {
            y += 5;

            alienRec = new Rectangle(x, y, width, height);
            alienRec.Location = new Point(x, y);
        }
        //public void draw(Graphics g)
        //{
        //    alienRec = new Rectangle(x, y, width, height);

        //    g.DrawImage(alienImage, alienRec);
        //}


        //public void MoveEnemy()
        //{
        //    alienRec.Location = new Point(x, y);
        //}

        //public void moveEnemy(Graphics g)
        //{
        //    y += 5;
        //    alienRec.Location = new Point(x, y);

        //}

    }
}
