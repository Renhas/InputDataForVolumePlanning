using SLAN;
using GeneralizedSystem;
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
    public partial class ResultOutput : UserControl
    {
        int I, J, T;
        List<int> controlledIds;
        BilateralInequality[] inequalities;
        List<float[]>[] segments;
        public ResultOutput(int I, int J, int T, List<int> sortedControlledIds, BilateralInequality[] inequalities, List<float[]>[] segments)
        {
            InitializeComponent();
            this.I = I;
            this.J = J;
            this.T = T;
            controlledIds = sortedControlledIds;
            this.inequalities = inequalities;
            this.segments = segments;
            BilateralToControlled();
            Solve();
        }

        private void Solve()
        {
            ResultList.Items.Clear();
            var system = CreateSystem();
            var result = VolumePlanningAlgorythm.Run(system, 1000, 0.01f);
            if (result is null) 
            {
                ResultList.Items.Add("Система не совместна, решения нет");
                return;
            }

            ResultList.Items.Add("Нормо-часы:\n");
            for (int i = 0; i < inequalities.Length; i++) 
            {
                string text;
                if (i < I) text = $"Изделие #{i + 1}: ";
                else if (i < I + J) text = $"Работа #{i - I + 1}: ";
                else text = $"Такт {i - I - J + 1}: ";

                var inequality = inequalities[i];
                if (inequality.Min == inequality.Max) text += $"{inequality.Min}\n";
                else text += $"от {inequality.Min} до {inequality.Max}\n";
                ResultList.Items.Add(text);
            }
        }

        private BilateralInequalitySystem CreateSystem()
        {
            var system = new BilateralInequalitySystem(I * T * J, controlledIds.Count);

            for (int id = 0; id < controlledIds.Count; id++) 
            {
                system.Add(inequalities[controlledIds[id]]);
            }
            for (int id = 0; id < I + J + T; id++) 
            {
                if (controlledIds.Contains(id)) continue;
                system.Add(inequalities[id]);
            }
            for (int id = 0; id < I * J * T; id++) 
            {
                system.Add(new Inequality(new MyVector(I * J * T, id + 1), 0));
            }
            return system;
        }

        private void BilateralToControlled() 
        {
            for (int i = 0; i < controlledIds.Count; i++) 
            {
                int id = controlledIds[i];
                var inequality = inequalities[id];
                var IntSegments = new List<int[]>();
                for (int j = 0; j < segments[i].Count; j++) IntSegments.Add(new int[] { (int)segments[i][j][0], (int)segments[i][j][1] });
                inequalities[id] = new ControlledBilateralInequality(inequality.Coefficients, IntSegments, (int)inequality.Min, (int)inequality.Max);
            }
        }
    }
}
