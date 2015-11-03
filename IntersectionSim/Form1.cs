using IntersectionSim.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntersectionSim
{
    public partial class Form1 : Form
    {
        Intersection intersection;
        int currentVisualTime;
        Timer Updater = new Timer();
        bool initialDraw = true;

        public Form1()
        {
            intersection = new Intersection();
            InitializeComponent();
            Updater.Interval = 100;
            Updater.Tick += new EventHandler(UpdaterEventHandler);
            currentVisualTime = 0;
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            //Lanes

            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            foreach (var item in intersection.IntersectionGraph.Edges)
            {
                e.Graphics.DrawLine(pen, item.Source.X * 2, item.Source.Y * 2, item.Target.X * 2, item.Target.Y * 2);
            }
                
            if(!initialDraw)
            {
                //Cars

                foreach (var item in intersection.Cars)
                {

                    if(item.LocationHistory.ContainsKey(currentVisualTime))
                    {
                        e.Graphics.FillEllipse(item.color,
                        (item.LocationHistory[currentVisualTime].X - 2.5f)*2, (item.LocationHistory[currentVisualTime].Y - 2.5f)*2, 10, 10);
                    }
                }
            }
            initialDraw = false;
        }

        private void UpdaterEventHandler(Object myObject, EventArgs myEventArgs)
        {
            currentVisualTime += 1;
            timeLabel.Text = ((decimal)currentVisualTime / 10) + " s";
            groupBox1.Invalidate();
            if(currentVisualTime == intersection.FinishTime)
            {
                Updater.Stop();
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if(!Updater.Enabled)
            {
                Updater.Start();

            }

        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            intersection.CalculateSimulation();
            StartButton.Enabled = true;
            PauseButton.Enabled = true;
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            if(Updater.Enabled)
            {
                Updater.Stop();
                StartButton.Text = "Resume Animation";
            }
        }
    }
}
