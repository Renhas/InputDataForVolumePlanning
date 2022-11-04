using SLAN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputDataForVolumePlanning
{
    public partial class ControlledInput : UserControl
    {
        int I, J, T;
        List<int> controlledIds;
        BilateralInequality[] inequalities;

        public ControlledInput(int I, int J, int T, List<int> controlled, BilateralInequality[] inequalities)
        {
            InitializeComponent();
            this.I = I;
            this.J = J;
            this.T = T;
            controlledIds = controlled;
            this.inequalities = inequalities;
            PanelInit();
        }
        public List<int> GetSortedControlled() 
        {
            List<int> sorted = new List<int>();
            for (int row = 0; row < MainPanel.RowCount - 1; row++) 
            {
                var label = MainPanel.GetControlFromPosition(1, row) as Label;
                sorted.Add((int)label.Tag);
            }
            return sorted;
        }

        public List<float[]>[] GetSortedSegments() 
        {
            List<float[]>[] result = new List<float[]>[controlledIds.Count];
            for (int row = 0; row < MainPanel.RowCount - 1; row++)
            {
                var segments = MainPanel.GetControlFromPosition(2, row) as InnerSegments;
                result[row] = (segments.Segments);
            }
            return result;
        }
        private void PanelInit() 
        {
            MainPanel.Controls.Clear();
            MainPanel.RowCount = controlledIds.Count + 1;
            MainPanel.RowStyles.Clear();
            for (int i = 0; i < MainPanel.RowCount; i++) MainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            for (int i = 0; i < controlledIds.Count; i++)
            {
                var panel = new FlowLayoutPanel()
                {
                    FlowDirection = FlowDirection.TopDown,
                    Size = new Size(15, 60),
                    Dock = DockStyle.Fill
                };

                Button up = new Button()
                {
                    Text = "˄",
                    Size = new Size(15, 20)
                };
                up.Click += Up_Click;
                Button down = new Button()
                {
                    Text = "˅",
                    Size = new Size(15, 20)
                };
                down.Click += Down_Click;
                if (i != 0) panel.Controls.Add(up);
                if (i != controlledIds.Count - 1) panel.Controls.Add(down);
                MainPanel.Controls.Add(panel, 0, i);

                string text;
                if (controlledIds[i] < I) text = $"Изделие #{controlledIds[i] + 1}";
                else if (controlledIds[i] < I + J) text = $"Работа #{controlledIds[i] - I + 1}";
                else text = $"Такт {controlledIds[i] - I - J + 1}";
                Label label = new Label()
                {
                    Text = text,
                    AutoSize = true,
                    Anchor = AnchorStyles.Left,
                    Tag = controlledIds[i]
                };
                MainPanel.Controls.Add(label, 1, i);

                InnerSegments segments = new InnerSegments(inequalities[controlledIds[i]])
                {
                    Anchor = AnchorStyles.Left
                };
                MainPanel.Controls.Add(segments, 2, i);

            }
        }

        private void Up_Click(object? sender, EventArgs e) 
        {
            Button button = sender as Button;
            if (button == null) return;
            var buttonPanel = (FlowLayoutPanel)button.Parent;
            var position = MainPanel.GetPositionFromControl(buttonPanel);
            var currentLabel = MainPanel.GetControlFromPosition(position.Column + 1, position.Row);
            var currentSegments = MainPanel.GetControlFromPosition(position.Column + 2, position.Row);
            var prevLabel = MainPanel.GetControlFromPosition(position.Column + 1, position.Row - 1);
            var prevSegments = MainPanel.GetControlFromPosition(position.Column + 2, position.Row - 1);

            MainPanel.SetRow(currentLabel, position.Row - 1);
            MainPanel.SetRow(currentSegments, position.Row - 1);
            MainPanel.SetRow(prevLabel, position.Row);
            MainPanel.SetRow(prevSegments, position.Row);
        }

        private void Down_Click(object? sender, EventArgs e) 
        {
            Button button = sender as Button;
            if (button == null) return;
            var buttonPanel = (FlowLayoutPanel)button.Parent;
            var position = MainPanel.GetPositionFromControl(buttonPanel);
            var currentLabel = MainPanel.GetControlFromPosition(position.Column + 1, position.Row);
            var currentSegments = MainPanel.GetControlFromPosition(position.Column + 2, position.Row);
            var prevLabel = MainPanel.GetControlFromPosition(position.Column + 1, position.Row + 1);
            var prevSegments = MainPanel.GetControlFromPosition(position.Column + 2, position.Row + 1);

            MainPanel.SetRow(currentLabel, position.Row + 1);
            MainPanel.SetRow(currentSegments, position.Row + 1);
            MainPanel.SetRow(prevLabel, position.Row);
            MainPanel.SetRow(prevSegments, position.Row);
        }
    }
}
