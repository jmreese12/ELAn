using ELAn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Matrix m1 = new int[,] 
            { 
             { 0, 1 },
             { 2, 3 } 
            };

            Matrix m2 = new int[,] 
            { 
             { 0, 3 },
             { 4, 5 } 
            };

            Matrix m = (m1 + m2);
          
        }
    }
}
