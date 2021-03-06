﻿using IntersectionSim.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JR.Utils.GUI.Forms;

namespace IntersectionSim
{
    public partial class Form1 : Form
    {
        float a = 208.57f - 10.0f;
        float b = 291.41f - 10.0f;
        Timer Updater = new Timer();
        bool initialDraw = true;
        private bool hasStarted = false;
        private Roundabout _roundabout;
        private List<Tuple<float, float>> CircleCoords;
        private List<Tuple<float, float>> OuterCircleCoords;

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
                Tuple.Create(a, 140.0f),
                Tuple.Create(140.0f, a),
                Tuple.Create(140.0f, b),
                Tuple.Create(a, 340.0f),
                Tuple.Create(b, 340.0f),
                Tuple.Create(340.0f, b),
                Tuple.Create(340.0f, a),
                Tuple.Create(b, 140.0f)
            };

            OuterCircleCoords = new List<Tuple<float, float>>()
            {
                Tuple.Create(a, 75.0f),
                Tuple.Create(75.0f, a),
                Tuple.Create(75.0f, b),
                Tuple.Create(a, 405.0f),
                Tuple.Create(b, 405.0f),
                Tuple.Create(405.0f, b),
                Tuple.Create(405.0f, a),
                Tuple.Create(b, 75.0f)
            };

            //Ho
            SpeedUpSelector.ValueChanged += (sender, args) =>
            {
                Updater.Interval = (int)(1000.0 / (double)SpeedUpSelector.Value);
            };
        }


        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
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
            e.Graphics.DrawArc(blackPen, 110, 110, 280, 280, 29.5f, 31);
            e.Graphics.DrawArc(blackPen, 110, 110, 280, 280, 29.5f + 90, 31);
            e.Graphics.DrawArc(blackPen, 110, 110, 280, 280, 29.5f + 180, 31);
            e.Graphics.DrawArc(blackPen, 110, 110, 280, 280, 29f + 270, 31);
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
        }

        private void UpdaterEventHandler(object myObject, EventArgs myEventArgs)
        {
            (_roundabout as ConventionalRoundabout)?.IterateSimaultion();

            if (_roundabout is IntelligentRoundabout)
                _roundabout = ((IntelligentRoundabout)_roundabout).GetBestNextOptionMain();
            pictureBox3.Invalidate();

            CurrTimeLabel.Text = $"Time : {Roundabout.MainCurrTime} sec";
            CheckSimulationFinished();
        }

        public void CheckSimulationFinished()
        {
            if (_roundabout.SimulationFinished)
            {
                Updater.Stop();

                MessageBox.Show($"Simulation finished, avg time: {_roundabout.GetAvgWaitTimeForFinished()}, max: {_roundabout.GetMaxWaitTime()}");
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
            {
                _roundabout = new ConventionalRoundabout();
                _roundabout.Init(patterns);
            }
            else
            {
                _roundabout = new IntelligentRoundabout();
                _roundabout.Init(patterns);

            }
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

        private void RunSampleButton_Click(object sender, EventArgs e)
        {

            string resString = $"Results: {Environment.NewLine}";
            var cpmMin = Convert.ToInt32(MinCpmSelector.Value);
            var cpmMax = Convert.ToInt32(MaxCpmSelector.Value);
            IntelligentRoundabout intelligent = null;
            ConventionalRoundabout conventional = null;

            for (int i = 0; i < Convert.ToInt32(NumOfRunsSelector.Value); i++)
            {
                List<TrafficPattern> patterns = new List<TrafficPattern>();
                Roundabout.SimulationDuration = Tools.GetRandomIntInRange(Convert.ToInt32(MinDurationSelector.Value),Convert.ToInt32(MaxDurationSelector.Value));
                var cpmN = Tools.GetRandomIntInRange(cpmMin, cpmMax);
                var cpmW = Tools.GetRandomIntInRange(cpmMin, cpmMax);
                var cpmS = Tools.GetRandomIntInRange(cpmMin, cpmMax);
                var cpmE = Tools.GetRandomIntInRange(cpmMin, cpmMax);

                var dN = Tools.GetRandomDestinations();
                var dW = Tools.GetRandomDestinations();
                var dS = Tools.GetRandomDestinations();
                var dE = Tools.GetRandomDestinations();

                patterns.Add(new TrafficPattern(EntryPosition.North, cpmN, dN.Item1,
                    dN.Item2, dN.Item3, dN.Item4));
                patterns.Add(new TrafficPattern(EntryPosition.West, cpmW, dW.Item1,
                    dW.Item2, dW.Item3, dW.Item4));
                patterns.Add(new TrafficPattern(EntryPosition.South, cpmS, dS.Item1,
                    dS.Item2, dS.Item3, dS.Item4));
                patterns.Add(new TrafficPattern(EntryPosition.East, cpmE, dE.Item1,
                    dE.Item2, dE.Item3, dE.Item4));
                resString += $"ROUNDABOUT {i}, duration: {Roundabout.SimulationDuration} sec: {Environment.NewLine}";
                resString +=
                    $"N EntryLane: cpm: {cpmN} toN: {dN.Item1}, toW: {dN.Item2}, toS: {dN.Item3}, toE: {dN.Item4} {Environment.NewLine}";
                resString +=
                    $"W EntryLane: cpm: {cpmW} toN: {dW.Item1}, toW: {dW.Item2}, toS: {dW.Item3}, toE: {dW.Item4} {Environment.NewLine}";
                resString +=
                    $"S EntryLane: cpm: {cpmS} toN: {dS.Item1}, toW: {dS.Item2}, toS: {dS.Item3}, toE: {dS.Item4} {Environment.NewLine}";
                resString +=
                    $"E EntryLane: cpm: {cpmE} toN: {dE.Item1}, toW: {dE.Item2}, toS: {dE.Item3}, toE: {dE.Item4} {Environment.NewLine}";

                intelligent = new IntelligentRoundabout();
                intelligent.Init(patterns);
                while (!intelligent.SimulationFinished)
                {
                    intelligent = intelligent.GetBestNextOptionMain();
                }
                resString += $"Intelligent Roundabout results: avg time: {Math.Round(intelligent.GetAvgWaitTimeForFinished(),3)}, max: {intelligent.GetMaxWaitTime()}, dur: {intelligent.OwnCurrTime}{Environment.NewLine}";

                conventional = new ConventionalRoundabout();
                conventional.Init(patterns);
                while (!conventional.SimulationFinished)
                {
                    conventional.IterateSimaultion();
                }
                resString += $"Conventional Roundabout results: avg time: {Math.Round(conventional.GetAvgWaitTimeForFinished(),3)}, max: {conventional.GetMaxWaitTime()}, dur: {conventional.OwnCurrTime}{Environment.NewLine}";
                resString += $"{Environment.NewLine}{Environment.NewLine}";


            }
            var res = FlexibleMessageBox.Show(resString, "Finished. OK to save to file, Cancel to dismiss", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var ms = saveFileDialog.OpenFile();
                    Debug.WriteLine((ms as FileStream).Name);
                    StreamWriter sw = new StreamWriter(ms, new UnicodeEncoding());
                    try
                    {
                        sw.Write(resString);
                        sw.Flush(); //otherwise you are risking empty stream
                        ms.Seek(0, SeekOrigin.Begin);

                        // Test and work with the stream here. 
                        // If you need to start back at the beginning, be sure to Seek again.
                    }
                    finally
                    {
                        sw.Dispose();
                        MessageBox.Show($"Saved to: {(ms as FileStream)?.Name}");
                    }
                }
            }
        }
    }
}
