using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Countdown : Form
    {
        int _sec;
        public Countdown()
        {
            InitializeComponent();
            InitComboBox(comboBox1,0,24);
            InitComboBox(comboBox2, 0, 60);
            InitComboBox(comboBox3, 0, 60);
            _sec = 0;

        }

        private void InitComboBox(ComboBox cb, int start, int stop)
        {
            IEnumerable<int> time = Enumerable.Range(start, stop);
            foreach (var t in time)
            {
                cb.Items.Add(t);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetTime();
            UpdateDisplay();
            timer1.Start();


        }

        private void ResetTime()
        {
            int hours = ValidateTime(comboBox1, 23);
            int mins = ValidateTime(comboBox2, 59);
            int secs = ValidateTime(comboBox3, 59);

            _sec = secs + mins * 60 + hours * 3600;
        }

        private int ValidateTime(ComboBox cb,int max)
        {
            int time= Convert.ToInt32(cb.Text);
            if (time > max)
            {
                time = max;
            }
            return time;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _sec--;
            UpdateDisplay();
            if (_sec == 0)
            {
                timer1.Stop();
                SystemSounds.Beep.Play();
                
            }
        }
        private void UpdateDisplay()
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(_sec);
            label1.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetTime();
            UpdateDisplay();
        }
    }
}
