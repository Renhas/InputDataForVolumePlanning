using SLAN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputDataForVolumePlanning
{
    public partial class InnerSegments : UserControl
    {
        public List<float[]> Segments { get; private set; }
        public InnerSegments(BilateralInequality inequality)
        {
            InitializeComponent();
            Segments = new List<float[]>();
            Segments.Add(new float[] { inequality.Min, inequality.Max });
            SegmentsPanelInit();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Segments.Add(new float[] { Segments.Last()[0], Segments.Last()[1] });
            SegmentsPanel.Width += 275;
            this.Width += 275;
            if (Segments.Count > 1) DeleteButton.Visible = DeleteButton.Enabled = true;
            SegmentsPanelInit();
            SegmentsPanel.Refresh();
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Segments.Remove(Segments.Last());
            SegmentsPanel.Width -= 275;
            this.Width -= 275;
            if (Segments.Count == 1) DeleteButton.Visible = DeleteButton.Enabled = false;
            SegmentsPanelInit();
            SegmentsPanel.Refresh();
        }

        private void SegmentsPanelInit() 
        {
            SegmentsPanel.Controls.Clear();

            var panel = new FlowLayoutPanel()
            {
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(260, 30),
                Margin = new Padding(3),
                FlowDirection = FlowDirection.LeftToRight
            };

            var firstNumeric = new NumericUpDown()
            {
                Increment = 1,
                Enabled = false,
                Size = new Size(120, 23),
                Minimum = 0,
                Maximum = (decimal)Segments[0][0],
                Value = (decimal)Segments[0][0]
            };

            var secondNumeric = new NumericUpDown()
            {
                Increment = 1,
                Enabled = false,
                Size = new Size(120, 23),
                Minimum = 0,
                Maximum = (decimal)Segments[0][1],
                Value = (decimal)Segments[0][1]
            };
            panel.Controls.Add(firstNumeric);
            panel.Controls.Add(secondNumeric);
            SegmentsPanel.Controls.Add(panel);

            for (int i = 1; i < Segments.Count; i++)
            {
                panel = new FlowLayoutPanel()
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    Size = new Size(260, 30),
                    Margin = new Padding(3),
                    FlowDirection = FlowDirection.LeftToRight,
                    Tag = i
                };

                firstNumeric = new NumericUpDown()
                {
                    Increment = 1,
                    Size = new Size(120, 23),
                    Minimum = (decimal)Segments[i - 1][0],
                    Maximum = (decimal)Segments[i][1],
                    Value = (decimal)Segments[i][0]
                };
                /*firstNumeric.DataBindings.Add(new Binding("Value", Segments, $"[{i}][0]", false, DataSourceUpdateMode.OnPropertyChanged));
                firstNumeric.DataBindings.Add(new Binding("Minimum", Segments, $"[{i-1}][0]", false, DataSourceUpdateMode.OnPropertyChanged));*/
                firstNumeric.Tag = firstNumeric.Value;
                firstNumeric.ValueChanged += MinNumeric_ValueChanged;


                secondNumeric = new NumericUpDown()
                {
                    Increment = 1,
                    Size = new Size(120, 23),
                    Minimum = (decimal)Segments[i][0],
                    Maximum = (decimal)Segments[i - 1][1],
                    Value = (decimal)Segments[i][1]
                };
                /*secondNumeric.DataBindings.Add(new Binding("Value", Segments[i][1], "", false, DataSourceUpdateMode.OnPropertyChanged));
                secondNumeric.DataBindings.Add(new Binding("Maximum", Segments[i - 1][1], "", false, DataSourceUpdateMode.OnPropertyChanged));*/
                secondNumeric.Tag = secondNumeric.Tag;
                secondNumeric.ValueChanged += MaxNumeric_ValueChanged;

                panel.Controls.Add(firstNumeric);
                panel.Controls.Add(secondNumeric);
                SegmentsPanel.Controls.Add(panel);
            }
        }
        private void MinNumeric_ValueChanged(object? sender, EventArgs e)
        {
            var MinNumeric = sender as NumericUpDown;
            if (MinNumeric == null) return;
            var panel = MinNumeric.Parent as FlowLayoutPanel;
            if (panel == null) return;
            var MaxNumeric = panel.Controls[1] as NumericUpDown;
            if (MaxNumeric == null) return;

            if ((int)panel.Tag < Segments.Count - 1) 
            {
                var nextPanel = SegmentsPanel.Controls[(int)panel.Tag + 1] as FlowLayoutPanel;
                (nextPanel.Controls[0] as NumericUpDown).Minimum = MinNumeric.Value;
            }

            Segments[(int)panel.Tag][0] = (float)MinNumeric.Value;
            MinNumeric.Tag = MinNumeric.Value;
            MaxNumeric.Minimum = (int)MinNumeric.Value;
        }

        private void MaxNumeric_ValueChanged(object? sender, EventArgs e)
        {
            var MaxNumeric = sender as NumericUpDown;
            if (MaxNumeric == null) return;
            var panel = MaxNumeric.Parent as FlowLayoutPanel;
            if (panel == null) return;
            var MinNumeric = panel.Controls[0] as NumericUpDown;
            if (MinNumeric == null) return;

            if ((int)panel.Tag < Segments.Count - 1)
            {
                var nextPanel = SegmentsPanel.Controls[(int)panel.Tag + 1] as FlowLayoutPanel;
                (nextPanel.Controls[1] as NumericUpDown).Maximum = MaxNumeric.Value;
            }

            Segments[(int)panel.Tag][1] = (float)MaxNumeric.Value;
            MaxNumeric.Tag = MaxNumeric.Value;
            MinNumeric.Maximum = (int)MaxNumeric.Value;
        }


    }
}
