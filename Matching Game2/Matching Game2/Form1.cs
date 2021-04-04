using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matching_Game2
{
    public partial class Form1 : Form
    {


        //Generates random numbers
        Random random = new Random();


        //List of Lettered Icons
        List<String> icons = new List<String>() { "Q", "M", "T", "V", "B", "J", "W", "Z", "Q", "M", "T", "V", "B", "J", "W", "Z" };


        //Keeps track of Labels Clicked
        Label firstClicked = null;
        Label secondClicked = null;


        //Method Assigns icons from list to random Grid

        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];

                    //Hiding Icons from user
                    iconLabel.ForeColor = iconLabel.BackColor;

                    icons.RemoveAt(randomNumber);
                }
            }
        }


        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }

        private void fILEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void label_click(object sender, EventArgs e)
        {

            if (timer1.Enabled == true)
                return;


            Label clickedLabel = sender as Label;

            //Runs if Label Control has successfully been converted into a Label Control
            if (clickedLabel != null)
            {

                //If Icon is visible exit method if not change icon to black 
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }



                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;


                //Check to see if the player won
                checkForWinner();


                //If two icons match reset reference Variables
                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }


                timer1.Start();

            }
        }

        


        private void checkForWinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;


                if (iconLabel != null)
                {
                    //If icon isn't visible : player hasn't found mathcing icons
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }





            MessageBox.Show("Hooray! You've matched all the icons!", "Congrats!");
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            // Stop the timer
            timer1.Stop();

            // Hide both icons
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;


            firstClicked = null;
            secondClicked = null;
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        //Displays About Page Dialogue
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {


            AboutForm dial = new AboutForm();
            dial.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Exits program when Exit button is clicked
            this.Close();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpDialog helper = new HelpDialog();
            helper.ShowDialog();
        }
    }
}
