using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        int PipeSpeed = 8;
        int gravity = 15;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }
        
        /*
        Just a few comments for you Langa, not to critique anything you did too much but just to hopefully make you aware of a few things.
        */
        
        // If you are not going to populate a method with any logic, it is better to delete it to keep your code cleaner.
        private void MyTimerEvent(object sender, EventArgs e)
        {

        }

        // I also wanted to ask whether you understand the concepts of Events and how they are different to normal methods?
        // By default ASP.NET Forms generates delegate and event sigantures for you (normally when creating some clickable UI component) to make your life easier. 
        // Just wanted to make sure you understand why that happens.
        // Events have these special type of Signatures which normally match to (Object sender, SomeCustomTypeGoesHere here).
        
        private void GameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {

                gravity = -15;
            }
        }

        private void GameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {

                gravity = 15;
            }
        }
        private void endGame()
        {

            MyTimer.Stop();
            lblScore.Text += " Game over!!!";
        }
        private void gameTimerEvent(object sender, EventArgs e)
        {
            FlappyBird.Top += gravity; 
            PipeUp.Left -= PipeSpeed; 
            PipeDown.Left -= PipeSpeed;
            lblScore.Text = "Score: " + lblScore;

            if (PipeDown.Left < -150)
            {
                
                PipeDown.Left = 800;
                score++;
            }
            if (PipeUp.Left < -180)
            {
                
                PipeUp.Left = 950;
                score++;
            }

          

            if (FlappyBird.Bounds.IntersectsWith(PipeDown.Bounds) ||
                FlappyBird.Bounds.IntersectsWith(PipeUp.Bounds) ||
                FlappyBird.Bounds.IntersectsWith(Ground.Bounds) || FlappyBird.Top < -25
                )
            {
                
                endGame();
            }
            
            if (score > 5)
            {
                PipeSpeed = 15;
            }
        }

    }   
}
