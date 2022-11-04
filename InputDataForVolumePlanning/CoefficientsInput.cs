using SLAN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputDataForVolumePlanning
{
    public partial class CoefficientsInput : UserControl
    {
        int I, J, T, selectedId;
        List<string> options;
        public List<int> controlledIds { get; private set; }
        public BilateralInequality[] inequalities { get; private set; }

        public CoefficientsInput(int I, int J, int T)
        {
            InitializeComponent();
            options = new List<string>();
            controlledIds = new List<int>();
            inequalities = new BilateralInequality[I + J + T];
            for (int i = 0; i < I + J + T; i++) 
            {
                inequalities[i] = new BilateralInequality(new MyVector(I * J * T), 0, 100);
            }
            this.I = I;
            this.J = J;
            this.T = T;
            ListInit();
            MainComboBox.DataSource = options;
            MaxNumeric.Maximum = int.MaxValue;
            selectedId = 0;
            
        }

        private void MinNumeric_ValueChanged(object sender, EventArgs e)
        {
            MaxNumeric.Minimum = (int)MinNumeric.Value;
        }

        private void MaxNumeric_ValueChanged(object sender, EventArgs e)
        {
            MinNumeric.Maximum = (int)MaxNumeric.Value;
        }
        private void MainComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Save();
            selectedId = MainComboBox.SelectedIndex;
            MaxNumeric.Minimum = (decimal)inequalities[selectedId].Min;
            MinNumeric.Maximum = (decimal)inequalities[selectedId].Max;
            MaxNumeric.Value = (int)inequalities[selectedId].Max;
            MinNumeric.Value = (int)inequalities[selectedId].Min;
            ControlledCheckBox.Checked = controlledIds.Contains(selectedId);
            SetCoefsPanel();
        }

        private void SetCoefsPanel()
        {
            int first, second;
            string firstPart = "Коэффициент для ", secondPart, currentType;

            if (MainComboBox.SelectedIndex < I)
            {
                currentType = "I";
                first = J;
                second = T;
                firstPart += "работы #";
                secondPart = "в такт ";
            }
            else if (MainComboBox.SelectedIndex < I + J)
            {
                currentType = "J";
                first = I;
                second = T;
                firstPart += "изделия #";
                secondPart = "в такт ";
            }
            else 
            {
                currentType = "T";
                first = I;
                second = J;
                firstPart += "работы #";
                secondPart = "изделия #";
            }
            CoefsPanel.RowCount = first * second + 1;
            CoefsPanel.RowStyles.Clear();
            CoefsPanel.Controls.Clear();
            for (int row = 0; row <= first * second; row++) CoefsPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            for (int f = 1; f <= first; f++)
            {

                for (int s = 1; s <= second; s++)
                {
                    Label label = new Label()
                    {
                        Text = $"{firstPart}{s} {secondPart}{f}",
                        AutoSize = true,
                        Anchor = AnchorStyles.Left
                    };
                    CoefsPanel.Controls.Add(label, 0, s - 1 + second * (f - 1));
                    int i = 0, j = 0, t = 0;
                    switch (currentType) 
                    {
                        case "I": i = MainComboBox.SelectedIndex + 1; j = f; t = s; break;
                        case "J": i = f; j = MainComboBox.SelectedIndex + 1 - I; t = s; break;
                        case "T": i = f; j = s; t = MainComboBox.SelectedIndex + 1 - I - J; break;
                    }
                    NumericUpDown numeric = new NumericUpDown()
                    {
                        Minimum = int.MinValue,
                        Maximum = int.MaxValue,
                        Increment = 1,
                        Anchor = AnchorStyles.Left,
                        Value = (decimal)inequalities[MainComboBox.SelectedIndex].Coefficients[(i - 1) * 2 * 2 + (j - 1) * 2 + t - 1]
                    };
                    CoefsPanel.Controls.Add(numeric, 1, s - 1 + second * (f - 1));
                }
            }
        }
        public void Save()
        {
            inequalities[selectedId].Min = (int)MinNumeric.Value;
            inequalities[selectedId].Max = (int)MaxNumeric.Value;
            if(ControlledCheckBox.Checked && !controlledIds.Contains(selectedId)) controlledIds.Add(selectedId);
            else if(!ControlledCheckBox.Checked && controlledIds.Contains(selectedId)) controlledIds.Remove(selectedId);
            int first, second;
            string currentType;

            if (selectedId < I)
            {
                currentType = "I";
                first = J;
                second = T;
            }
            else if (selectedId < I + J)
            {
                currentType = "J";
                first = I;
                second = T;
            }
            else
            {
                currentType = "T";
                first = I;
                second = J;
            }
           
            for (int f = 1; f <= first; f++)
            {

                for (int s = 1; s <= second; s++)
                {
                    int i = 0, j = 0, t = 0;
                    switch (currentType)
                    {
                        case "I": i = selectedId + 1; j = f; t = s; break;
                        case "J": i = f; j = selectedId + 1 - I; t = s; break;
                        case "T": i = f; j = s; t = selectedId + 1 - I - J; break;
                    }
                    NumericUpDown numeric = CoefsPanel.GetControlFromPosition(1, s - 1 + second * (f - 1)) as NumericUpDown;
                    if (numeric != null)
                        inequalities[selectedId].Coefficients[(i - 1) * 2 * 2 + (j - 1) * 2 + t - 1] = (float)numeric.Value;
                }
            }
        }


        private void ListInit() 
        {
            for (int i = 1; i <= I; options.Add($"Изделие #{i++}")) ;
            for (int i = 1; i <= J; options.Add($"Работа #{i++}")) ;
            for (int i = 1; i <= T; options.Add($"Такт #{i++}")) ;

        }
    }
}
