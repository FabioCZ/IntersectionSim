using IntersectionSim.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntersectionSim
{
    public partial class Form1 : Form
    {
        float a = 208.57f;
        float b = 291.41f;
        Timer Updater = new Timer();
        bool initialDraw = true;
        private bool hasStarted = false;
        private bool firstDraw = true;
        private Roundabout _roundabout;
        private List<Tuple<float, float>> CircleCoords;
        private List<Tuple<float, float>> OuterCircleCoords;
        private GraphicsState VisGraphics;

        private Pen blackPen = new Pen(Color.Black)
        {
            Width = 2.0f
        };

        private Pen whiteArrowPen = new Pen(Color.White)
        {
            EndCap = LineCap.ArrowAnchor,
            Width = 6.0f
        };
        Brush greyBrush = new SolidBrush(Color.Gray);
        Brush whiteBrush = new SolidBrush(Color.White);
        Brush greenBrush = new SolidBrush(Color.Green);
        Brush blackBrush = new SolidBrush(Color.Black);
        Font font = new Font("Arial", 8);

        public Form1()
        {

            InitializeComponent();
            Updater.Interval = (int)(1000.0 / (double)SpeedUpSelector.Value);
            Updater.Tick += new EventHandler(UpdaterEventHandler);
            CircleCoords = new List<Tuple<float, float>>()
            {
                Tuple.Create(a, 150.0f),
                Tuple.Create(150.0f, a),
                Tuple.Create(150.0f, b),
                Tuple.Create(a, 350.0f),
                Tuple.Create(b, 350.0f),
                Tuple.Create(350.0f, b),
                Tuple.Create(350.0f, a),
                Tuple.Create(b, 150.0f)
            };

            OuterCircleCoords = new List<Tuple<float, float>>()
            {
                Tuple.Create(a, 85.0f),
                Tuple.Create(85.0f, a),
                Tuple.Create(85.0f, b),
                Tuple.Create(a, 415.0f),
                Tuple.Create(b, 415.0f),
                Tuple.Create(415.0f, b),
                Tuple.Create(415.0f, a),
                Tuple.Create(b, 85.0f)
            };

            //Ho
            SpeedUpSelector.ValueChanged += (sender, args) =>
            {
                Updater.Interval = (int)(1000.0 / (double)SpeedUpSelector.Value);
            };
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            if(firstDraw)
                StaticGraphics(e);
            else
                e.Graphics.Restore(VisGraphics);

            for (int i = 0; i < 8; i++)
            {
                //Inner
                e.Graphics.DrawEllipse(blackPen, CircleCoords[i].Item1 - 20.2f, CircleCoords[i].Item2 - 20.2f, 40.4f, 40.4f);

                if (_roundabout?.Circle[i] != null)
                {
                    e.Graphics.FillEllipse(_roundabout.Circle[i].Color, CircleCoords[i].Item1 - 20, CircleCoords[i].Item2 - 20, 40.0f, 40.0f);
#if DEBUG
                    e.Graphics.DrawString(_roundabout.Circle[i].Id, font, blackBrush, CircleCoords[i].Item1 - 10, CircleCoords[i].Item2 - 20);
#endif
                    string from = _roundabout.Circle[i].From.ToString().Substring(0, 1);
                    string to = _roundabout.Circle[i].To.ToString().Substring(0, 1);
                    string fromTo = from + "->" + to;
                    e.Graphics.DrawString(fromTo, font, blackBrush, CircleCoords[i].Item1 - 13, CircleCoords[i].Item2);

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
                e.Graphics.DrawString(_roundabout.EntryLanes[0].QueuedCarsMin1, font, whiteBrush, OuterCircleCoords[0].Item1 + 10, OuterCircleCoords[0].Item2 - 35);
                e.Graphics.DrawString(_roundabout.EntryLanes[1].QueuedCarsMin1, font, whiteBrush, OuterCircleCoords[2].Item1 - 40, OuterCircleCoords[2].Item2 + 10);
                e.Graphics.DrawString(_roundabout.EntryLanes[2].QueuedCarsMin1, font, whiteBrush, OuterCircleCoords[4].Item1 + 10, OuterCircleCoords[4].Item2 + 20);
                e.Graphics.DrawString(_roundabout.EntryLanes[3].QueuedCarsMin1, font, whiteBrush, OuterCircleCoords[6].Item1 + 20, OuterCircleCoords[6].Item2 + 10);

            }

        }

        public void StaticGraphics(PaintEventArgs e)
        {
            //incoming roads
            e.Graphics.DrawRectangle(blackPen, 10, 180, 480, 140);
            e.Graphics.FillRectangle(greyBrush, 10, 180, 480, 140);
            e.Graphics.FillRectangle(whiteBrush, 10, 248, 480, 4);
            e.Graphics.DrawRectangle(blackPen, 180, 10, 140, 480);
            e.Graphics.FillRectangle(greyBrush, 180, 10, 140, 480);
            e.Graphics.FillRectangle(whiteBrush, 248, 10, 4, 480);

            //roundabout circle
            //e.Graphics.DrawEllipse(blackPen, 110, 110, 280, 280);
            e.Graphics.DrawArc(blackPen,110,110,280,280,29.5f,31);
            e.Graphics.DrawArc(blackPen,110,110,280,280,29.5f+90,31);
            e.Graphics.DrawArc(blackPen,110,110,280,280,29.5f+180,31);
            e.Graphics.DrawArc(blackPen,110,110,280,280,29f+270,31);
            e.Graphics.FillEllipse(greyBrush, 110, 110, 280, 280);
            e.Graphics.DrawEllipse(blackPen, 200, 200, 100, 100);
            e.Graphics.FillEllipse(greenBrush, 200, 200, 100, 100);

            //waiting white lines
            e.Graphics.FillRectangle(whiteBrush, 180, 110, 72, 4);
            e.Graphics.FillRectangle(whiteBrush, 110, 248, 4, 72);
            e.Graphics.FillRectangle(whiteBrush, 248, 388, 72, 4);
            e.Graphics.FillRectangle(whiteBrush, 388, 180, 4, 72);



            e.Graphics.DrawLine(whiteArrowPen, a, 20, a, 60);
            e.Graphics.DrawLine(whiteArrowPen, 60, a, 20, a);
            e.Graphics.DrawLine(whiteArrowPen, 20, b, 60, b);
            e.Graphics.DrawLine(whiteArrowPen, a, 440, a, 480);
            e.Graphics.DrawLine(whiteArrowPen, b, 480, b, 440);
            e.Graphics.DrawLine(whiteArrowPen, 480, a, 440, a);
            e.Graphics.DrawLine(whiteArrowPen, 440, b, 480, b);
            e.Graphics.DrawLine(whiteArrowPen, b, 60, b, 20);
            VisGraphics = e.Graphics.Save();
        }

        private void UpdaterEventHandler(object myObject, EventArgs myEventArgs)
        {
            _roundabout.IterateSimaultion();
            groupBox1.Invalidate();

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
            Roundabout.SimulationDuration = (int)SimulationDurationSelector.Value;
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

            //Init roundabout object
            if (ConventialRadio.Checked)
            _roundabout = new ConventionalRoundabout(patterns);
            else
                _roundabout = new IntelligentRoundabout(patterns);

            ConventialRadio.Enabled = false;
            IntelligentRadio.Enabled = false;

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
            Updater.Interval = (int)(1000.0 / (double)SpeedUpSelector.Value);
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
