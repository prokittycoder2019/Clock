using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Timer : Form
    {
        int _sec;
        public Timer()
        {
            InitializeComponent();
            _sec = 0;
        }
            
        private void timer1_Tick(object sender, EventArgs e)
        {

            _sec++;
            UpdateDisplay();

        }

        private void UpdateDisplay()
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(_sec);
            label1.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _sec = 0;
            UpdateDisplay();
        }
    }
}
