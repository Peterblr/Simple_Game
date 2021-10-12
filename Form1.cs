using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Game
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 15;
        int gravity = 10;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void bird_Click(object sender, EventArgs e)
        {
            
        }

        private void gameKeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }
        }

        private void gameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score; 

            if (pipeBottom.Left < -1)
            {
                pipeBottom.Left = 600;
                score++;
            }

            if (pipeTop.Left < -120)
            {
                pipeTop.Left = 750;
                score++;
            }

            if (bird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                bird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                bird.Bounds.IntersectsWith(ground.Bounds) ||
                bird.Top < -25
                )
            {
                endGame();
            }

            if (score > 5)
            {
                pipeSpeed = 22;
            }            
        }

        private void endGame()
        {
            timer1.Stop();
            scoreText.Text += "   GAME OVER!!!";
        }
    }
}
