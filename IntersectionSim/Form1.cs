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
            Updater.Interval = 100;
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
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0));
            for (int i = 0; i < 8; i++)
            {
                //Inner
                e.Graphics.DrawEllipse(blackPen, CircleCoords[i].Item1 - 20.2f, CircleCoords[i].Item2 - 20.2f, 40.4f, 40.4f);

                if (_roundabout?.Circle[i] != null)
                {
                    e.Graphics.FillEllipse(_roundabout.Circle[i].Color,CircleCoords[i].Item1 - 20,CircleCoords[i].Item2 - 20,40.0f,40.0f);
                }

                //Outer
                e.Graphics.DrawEllipse(blackPen, OuterCircleCoords[i].Item1 - 20, OuterCircleCoords[i].Item2 - 20, 40.0f, 40.0f);

            }
            for (int i = 0; i < 4; i++)
            {
                var firstCar = _roundabout?.EntryLanes[i].PeekAtQueue();
                if (firstCar != null)
                {
                    e.Graphics.FillEllipse(firstCar.Color,OuterCircleCoords[i*2].Item1 - 20,CircleCoords[i*2].Item2 - 20,40.0f,40.0f);
                }
            }

            for (int i = 0; i < 4; i++)
            {
                if (_roundabout?.FinishedCars != null && _roundabout.FinishedCars[i].Any())
                {
                    var finishedCar = from a in _roundabout.FinishedCars[i] where a.ExitTime == Roundabout.CurrTime select a;
                    if (finishedCar.Any())
                    {
                        e.Graphics.FillEllipse(finishedCar.ToArray()[0].Color, OuterCircleCoords[i*2 + 1].Item1 - 20,
                            CircleCoords[i*2 + 1].Item2 - 20, 40.0f, 40.0f);
                    }
                }
            }
        }

        private void UpdaterEventHandler(object myObject, EventArgs myEventArgs)
        {
            _roundabout.IterateSimaultion();
            groupBox1.Invalidate();

            CurrTimeLabel.Text = $"Time : {Roundabout.CurrTime} sec";
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Updater.Interval = (int) (1000.0/(double) SpeedUpSelector.Value);
            Roundabout.SimulationDuration = (int) SimulationDurationSelector.Value;
            var patterns = new List<TrafficPattern>()
            {
                new TrafficPattern(EntryPosition.North),
                new TrafficPattern(EntryPosition.West),
                new TrafficPattern(EntryPosition.South),
                new TrafficPattern(EntryPosition.East),
            };
            _roundabout = new ConventionalRoundabout(patterns);
            ResumeButton.Enabled = false;
            PauseButton.Enabled = true;
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
