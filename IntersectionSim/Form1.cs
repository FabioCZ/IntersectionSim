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

        Timer Updater = new Timer();
        bool initialDraw = true;
        private bool hasStarted = false;
        private Roundabout _roundabout;
        private List<Tuple<float, float>> CircleCoords;
        private List<Tuple<float, float>> OuterCircleCoords;
        public Form1()
        {

            InitializeComponent();
            Updater.Interval = (int)(1000.0 / (double)SpeedUpSelector.Value);
            Updater.Tick += new EventHandler(UpdaterEventHandler);
            CircleCoords = new List<Tuple<float, float>>()
            {
                Tuple.Create(225.0f, 150.0f),
                Tuple.Create(150.0f, 225.0f),
                Tuple.Create(150.0f, 275.0f),
                Tuple.Create(225.0f, 350.0f),
                Tuple.Create(275.0f, 350.0f),
                Tuple.Create(350.0f, 275.0f),
                Tuple.Create(350.0f, 225.0f),
                Tuple.Create(275.0f, 150.0f)
            };

            OuterCircleCoords = new List<Tuple<float, float>>()
            {
                Tuple.Create(225.0f, 100.0f),
                Tuple.Create(100.0f, 225.0f),
                Tuple.Create(100.0f, 275.0f),
                Tuple.Create(225.0f, 400.0f),
                Tuple.Create(275.0f, 400.0f),
                Tuple.Create(400.0f, 275.0f),
                Tuple.Create(400.0f, 225.0f),
                Tuple.Create(275.0f, 100.0f)
            };

            //Ho
            SpeedUpSelector.ValueChanged += (sender, args) =>
            {
                Updater.Interval = (int) (1000.0/(double) SpeedUpSelector.Value);
            };
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black);
            Brush blackBrush = new SolidBrush(Color.Black);
            Font font = new Font("Arial",8);
            for (int i = 0; i < 8; i++)
            {
                //Inner
                e.Graphics.DrawEllipse(blackPen, CircleCoords[i].Item1 - 20.2f, CircleCoords[i].Item2 - 20.2f, 40.4f, 40.4f);

                if (_roundabout?.Circle[i] != null)
                {
                    e.Graphics.FillEllipse(_roundabout.Circle[i].Color,CircleCoords[i].Item1 - 20,CircleCoords[i].Item2 - 20,40.0f,40.0f);
#if DEBUG
                    e.Graphics.DrawString(_roundabout.Circle[i].Id,font,blackBrush, CircleCoords[i].Item1 - 10, CircleCoords[i].Item2 - 20);
#endif
                    string from = _roundabout.Circle[i].From.ToString().Substring(0,1);
                    string to = _roundabout.Circle[i].To.ToString().Substring(0, 1);
                    string fromTo = from + "->" + to;
                    e.Graphics.DrawString(fromTo, font, blackBrush, CircleCoords[i].Item1 - 13, CircleCoords[i].Item2 );

                }
            }
            for (int i = 0; i < 8; i++)
            {
                //Outer
                e.Graphics.DrawEllipse(blackPen, OuterCircleCoords[i].Item1 - 20, OuterCircleCoords[i].Item2 - 20, 40.0f, 40.0f);

                if (_roundabout?.OuterCircle[i] != null)
                {
                    e.Graphics.FillEllipse(_roundabout.OuterCircle[i].Color, OuterCircleCoords[i].Item1 - 20,
                        OuterCircleCoords[i].Item2 - 20, 40.0f, 40.0f);
#if DEBUG
                    e.Graphics.DrawString(_roundabout.OuterCircle[i].Id, font, blackBrush, OuterCircleCoords[i].Item1 - 10,
                        OuterCircleCoords[i].Item2 - 20);
#endif
                    string from = _roundabout.OuterCircle[i].From.ToString().Substring(0, 1);
                    string to = _roundabout.OuterCircle[i].To.ToString().Substring(0, 1);
                    string fromTo = from + "->" + to;
                    e.Graphics.DrawString(fromTo, font, blackBrush, OuterCircleCoords[i].Item1 - 13, OuterCircleCoords[i].Item2);
                }
            }
            if (_roundabout != null)
            {
                e.Graphics.DrawString(_roundabout.EntryLanes[0].QueuedCarsMin1, font, blackBrush, OuterCircleCoords[0].Item1, OuterCircleCoords[0].Item2 - 40);
                e.Graphics.DrawString(_roundabout.EntryLanes[1].QueuedCarsMin1, font, blackBrush, OuterCircleCoords[2].Item1 - 40, OuterCircleCoords[2].Item2);
                e.Graphics.DrawString(_roundabout.EntryLanes[2].QueuedCarsMin1, font, blackBrush, OuterCircleCoords[4].Item1, OuterCircleCoords[4].Item2 + 40);
                e.Graphics.DrawString(_roundabout.EntryLanes[3].QueuedCarsMin1, font, blackBrush, OuterCircleCoords[6].Item1 + 40, OuterCircleCoords[6].Item2);

            }


        }

        private void UpdaterEventHandler(object myObject, EventArgs myEventArgs)
        {
            _roundabout.IterateSimaultion();
            groupBox1.Refresh();

            CurrTimeLabel.Text = $"Time : {Roundabout.MainCurrTime} sec";
            CheckSimulationFinished();
        }

        public void CheckSimulationFinished()
        {
            if (_roundabout.SimulationFinished)
            {
                Updater.Stop();
                MessageBox.Show("Simulation finished");
                ManualIterButton.Enabled = false;
                PauseButton.Enabled = false;
                ResumeButton.Enabled = false;
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Roundabout.SimulationDuration = (int) SimulationDurationSelector.Value;
            List<TrafficPattern> patterns = new List<TrafficPattern>();

            //Custom car flows
            //NORTH
            if (CheckBoxNorth.Checked)
                patterns.Add(new TrafficPattern(EntryPosition.North, CarPerMinN.IntVal(), ToNFromN.IntVal(),
                    ToEFromN.IntVal(), ToSFromN.IntVal(), ToWFromN.IntVal()));
            else
                patterns.Add(new TrafficPattern(EntryPosition.North));
            //WEST 
            if (CheckBoxWest.Checked)    
                patterns.Add(new TrafficPattern(EntryPosition.West, CarPerMinW.IntVal(), ToNFromW.IntVal(),
                    ToEFromW.IntVal(), ToSFromW.IntVal(), ToWFromW.IntVal()));
            else
                patterns.Add(new TrafficPattern(EntryPosition.West));
            //SOUTH
            if (CheckBoxSouth.Checked)  
                patterns.Add(new TrafficPattern(EntryPosition.South, CarPerMinS.IntVal(), ToNFromS.IntVal(),
                    ToEFromS.IntVal(), ToSFromS.IntVal(), ToWFromS.IntVal()));
            else
                patterns.Add(new TrafficPattern(EntryPosition.South));
            //SOUTH
            if (CheckBoxEast.Checked)
                patterns.Add(new TrafficPattern(EntryPosition.East, CarPerMinE.IntVal(), ToNFromE.IntVal(),
                    ToEFromE.IntVal(), ToSFromE.IntVal(), ToWFromE.IntVal()));
            else
                patterns.Add(new TrafficPattern(EntryPosition.East));
            //Custom car flows end

            LaneGroup1.Enabled = false;
            LaneGroup2.Enabled = false;
            LaneGroup3.Enabled = false;
            LaneGroup4.Enabled = false;

            Roundabout.SimulationDuration = SimulationDurationSelector.IntVal();
            SimulationDurationSelector.Enabled = false;
            _roundabout = new ConventionalRoundabout(patterns);
            ResumeButton.Enabled = true;
            PauseButton.Enabled = false;
            ManualIterButton.Enabled = true;
        }


        private void PauseButton_Click(object sender, EventArgs e)
        {
            ResumeButton.Enabled = true;
            PauseButton.Enabled = false;
            Updater.Stop();
        }

        private void ResumeButton_Click(object sender, EventArgs e)
        {
            Updater.Interval = (int) (1000.0/(double) SpeedUpSelector.Value);
            ResumeButton.Enabled = false;
            PauseButton.Enabled = true;
            Updater.Start();
        }

        private void ManualIterButton_Click(object sender, EventArgs e)
        {
            UpdaterEventHandler(null, null);
        }
    }
}
