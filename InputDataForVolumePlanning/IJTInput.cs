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
    public partial class IJTInput : UserControl
    {
        public IJTInput(int i = 1, int j = 1, int t = 1)
        {
            InitializeComponent();
            I = i;
            J = j;
            T = t;
        }

        public int I 
        {
            get { return (int)ItemsNumeric.Value; }
            set { ItemsNumeric.Value = value; }
        }

        public int J 
        {
            get { return (int)JobsNumeric.Value; }
            set { JobsNumeric.Value = value; }
        }

        public int T 
        {
            get { return (int)TactsNumeric.Value; }
            set { TactsNumeric.Value = value; }
        }
    }
}
