// Project : Review Lab
// Sept 24 2025
// By Agamdeep Singh
//
// MyLibrary type - class definition - Form1 class
// Print Format : Landscape
// ///////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReviewLab
{
    public partial class Form1 : Form
    {
        private const int maxInterval = 1000;           // max animation interval allowed
        private const int minInterval = 5;              // min animation interval allowed

        private SimState sim;                           // Creating an instance for the simulation class
        private Timer timer;                            // timer instance
        private int intervalSpeed = 50;                 // current interval spped

        public Form1()
        {
            InitializeComponent();

            UI_Numeric_value.Value = intervalSpeed;
            this.MouseWheel += Form1_MouseWheel;                // subscribing mouse wheel event to a function
            UI_label.Text = $"Round 0: No winner yet!";
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if(e.Delta > 0)
            {
                if (intervalSpeed < maxInterval)                // making sure the speed stays within the upper limit
                {
                    intervalSpeed++;
                    timer.Interval = intervalSpeed;
                }
            }
            else
            {
                if (intervalSpeed > minInterval)            // making sure the speed stays within the lower limit
                {
                    intervalSpeed--;
                    timer.Interval = intervalSpeed;
                }
            }
        }

        private void UI_start_btn_Click(object sender, EventArgs e)
        {
            startSimulation((int)UI_Numeric_value.Value);               // starting the simulation with requied hands
        }

        /*=======================================================================================
        * Function : public void startSimulation(int hands)
        * Input : The number of hands generated
        * Purpose : creates an instance of simulation class and sets and starts the timer
        =========================================================================================*/
        public void startSimulation(int hands)
        {
            if (sim != null)
            {
                sim.CloseDrawer();
                timer.Stop();
                sim = null;
            }

            sim = new SimState(hands);
            UI_label.Text = "Rounds: 0";

            timer = new Timer();
            timer.Interval = intervalSpeed;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var (frame, winner) = sim.Tick();               // returning the frames and winner as a tuple

            UI_label.Text = $"Round {frame}: No winner yet!";

            if (winner.HasValue)
            {
                // When a winner is found, the simulation is stopped and the final result is displayed.
                timer.Stop();
                UI_label.Text = $"Round {frame}: {winner.Value} wins!";
            }
        }
    }
}
