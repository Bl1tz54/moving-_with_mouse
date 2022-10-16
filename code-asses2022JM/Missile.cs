using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace code_asses2022JM
{
    class Missile
    {
        public int x, y, width, height;

        public Image missile;//variable for the missile's image

        public Rectangle missileRec;//variable for a rectangle to place our image in

        // in the following constructor we pass in the values of spaceRec which
        // gives us the position of the spaceship which we can then use to place the
        // missile where the spaceship is located
        public Missile(Rectangle spaceRec)
        {
            x = spaceRec.X; // move missile to middle of spaceship
            y = spaceRec.Y;
            width = 20;
            height = 20;
            missile = Properties.Resources.nukes;
            missileRec = new Rectangle(x, y, width, height);
        }

        public void draw(Graphics g)
        {
            y -= 30;//speed of missile
            missileRec = new Rectangle(x, y, width, height);
            g.DrawImage(missile, missileRec);
        }

    }

}
