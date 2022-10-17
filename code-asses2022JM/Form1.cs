using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace code_asses2022JM
{
    public partial class FrmAlien : Form
    { 
        Graphics g; //declare a graphics object called g
        public Random yspeed = new Random();
        public int rndmspeed = 5;//initial speed of aliens

        Player player = new Player();
       // bool left, right;
       // string move;
        int score, lives;
        //declare a list  missiles from the Missile class
        List<Missile> missiles = new List<Missile>();
        List<Enemy> alien = new List<Enemy>();

        public FrmAlien()
        {
            InitializeComponent();

            for (int i = 0; i < 7; i++)
            {
                int displacement = 10 + (i * 70);
                alien.Add(new Enemy(displacement));
            }


        }

        private void PnlGame_Paint(object sender, PaintEventArgs e)
        {
            //get the graphics used to paint on the panel control
            g = e.Graphics;
            player.DrawPlayer(g);


            foreach (Missile m in missiles)
            {
                m.draw(g);
            }


            for (int i = 0; i < 7; i++)
            {
                // generate a random number from 5 to 20 and put it in rndmspeed
               // int rndmspeed = yspeed.Next(5, 20);
               // alien[i].y += rndmspeed;

                //call the Planet class's drawPlanet method to draw the images
                alien[i].DrawEnemy(g);

            }

        }
        

        private void FrmAlien_KeyDown(object sender, KeyEventArgs e)
        {
           // if (e.KeyData == Keys.Left) { left = true; }
            //if (e.KeyData == Keys.Right) { right = true; }
            if (e.KeyData == Keys.Space)
            {
                missiles.Add(new Missile(player.playerRec));
            }
        }

        //private void FrmAlien_KeyUp(object sender, KeyEventArgs e)
      //  {
           // if (e.KeyData == Keys.Left) { left = false; }
           // if (e.KeyData == Keys.Right) { right = false; }

        //}

        //private void TmrPlayer_Tick(object sender, EventArgs e)
        //{
        //    if (right) // if right arrow key pressed
        //    {
        //        move = "right";
        //        player.MovePlayer(move);
        //    }
        //    if (left) // if left arrow key pressed
        //    {
        //        move = "left";
        //        player.MovePlayer(move);
        //    }

        //}

        private void FrmAlien_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Use the left and right arrow keys to move the spaceship. \n Don't get hit by the planets! \n Every planet that gets past scores a point. \n If a planet hits a spaceship a life is lost! \n \n Enter your Name \n Click Start to begin", "Game Instructions");
            TxtName.Focus();
            lives = int.Parse(LblLives.Text);
        }

        private void MnuStart_Click(object sender, EventArgs e)
        {
            score = 0;
            LblScore.Text = score.ToString();
            // pass lives from LblLives Text property to lives variable
            lives = int.Parse(LblLives.Text);

            TmrAlien.Enabled = true;
            TmrPlayer.Enabled = true;
        }

        private void MnuStop_Click(object sender, EventArgs e)
        {
            TmrPlayer.Enabled = false;
            TmrAlien.Enabled = false;
        }

        private void tmrshoot_Tick(object sender, EventArgs e)
        {
            foreach (Enemy p in alien)
            {

                foreach (Missile m in missiles)
                {
                    if (p.alienRec.IntersectsWith(m.missileRec))
                    {
                        p.y = -20;// relocate planet to the top of the form

                        missiles.Remove(m);
                        break;
                    }
                }

            }
            PnlGame.Invalidate();

        }

        private void PnlGame_MouseMove_1(object sender, MouseEventArgs e)
        {
            player.MovePlayer(e.X);
            PnlGame.Invalidate();

        }

        private void TmrAlien_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                alien[i].MoveEnemy(rndmspeed);

                //if a planet reaches the bottom of the Game Area reposition it at the top
                if (alien[i].y >= PnlGame.Height)
                {

                    //reset planet[i] back to top of panel
                    alien[i].y = 30; // set  y value of planetRec
                    lives -= 1;// lose a life
                    LblLives.Text = lives.ToString();// display number of lives
                    CheckLives();
                }

            }
            PnlGame.Invalidate();//makes the paint event fire to redraw the panel
     
        }

        private void CheckLives()
        {
            if (lives == 0)
            {
                TmrAlien.Enabled = false;
                TmrPlayer.Enabled = false;
                MessageBox.Show("Game Over");

            }
        }

    }


}
