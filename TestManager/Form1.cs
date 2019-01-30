using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegressionSuite;
namespace TestManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            try {
                SmokeTests test1 = new SmokeTests();
                if (rbtSequential.Checked)
                    test1.MainSequentialMethod();
                else if (rbtParallel.Checked)
                    test1.MainParallelMethod(cmbNoOfBrowsers.SelectedItem.ToString());
                }
            catch(Exception ex) { MessageBox.Show(ex.InnerException.Message); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbNoOfBrowsers.SelectedItem = "2";
        }
    }
}
