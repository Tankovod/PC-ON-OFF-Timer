using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        int myVar;
        public Form1()
        {
            InitializeComponent();

            int myVar;

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe"; //задаем какую программу запустить
            p.StartInfo.Arguments = "/c shutdown -s"; //задаем параметры с которыми она запустится
                                                      // p.Start(); // запускаем
            notifyIcon1.Visible = false;
            this.notifyIcon1.MouseDoubleClick += new MouseEventHandler(notifyIcon1_MouseDoubleClick);
            this.Resize += new System.EventHandler(this.Form1_Resize);

           
        }

        private decimal numUpDownVal;
        public decimal NumUpDown
        {
            get
            {
                return numUpDownVal;
            }
            set
            {
                numUpDownVal = value;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // проверяем наше окно, и если оно было свернуто, делаем событие        
            if (WindowState == FormWindowState.Minimized)
            {
                // прячем наше окно из панели
                this.ShowInTaskbar = false;
                // делаем нашу иконку в трее активной
                notifyIcon1.Visible = true;
            }
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
                        
            timer1.Dispose();//освобождает ресурсы от таймера
            timer2.Dispose();
                      
            if (radioButton1.Checked && checkBox1.Checked)
            {
                Process.Start("shutdown", "/s /f /t 0");
            }

            if (radioButton2.Checked && checkBox1.Checked)
            {
                Process.Start("shutdown", "/r /f /t 0");
            }

            if (radioButton1.Checked && !checkBox1.Checked)
            {
                Process.Start("shutdown", "/s /t 15");
            }

            if (radioButton2.Checked && !checkBox1.Checked)
            {
                Process.Start("shutdown", "/r /t 15");
            }

            if (radioButton3.Checked)
            {
                Process.Start("shutdown", "/h");
            }


        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer2.Tick -= new EventHandler(timer2_Tick);
            var hour = trackBarH.Value;
            var h = hour * 3600 * 1000;
            var minute = TrackBarM.Value;
            var m = minute * 60 * 1000;
            var t = m + h;
                      
            timer1.Interval = t + 1;
           
            timer1.Enabled = true;
            timer1.Start();

            timer2.Interval = 1000;
            timer2.Tick += new EventHandler(timer2_Tick);
            
            
            var chas = t / 3600 / 1000;
            var min = (t  - (chas * 3600 * 1000))/ 60 / 1000;
            var sec = (t - (chas * 3600*1000) - (min * 60 * 1000)) / 1000;


            label6.Text = chas.ToString(); label7.Text = min.ToString(); label8.Text = sec.ToString();

            timer2.Enabled = true;
            timer2.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Enabled= false;
            timer2.Stop();
            timer2.Enabled= false;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
            string progress = timer1.ToString();
           // progressBar1.Top = ;
        }

       


        private void trackBarH_Scroll(object sender, EventArgs e)
        {
            labelH.Text = trackBarH.Value.ToString();
            var hour = trackBarH.Value;
            var h = hour * 3600 * 1000;
        }

        private void TrackBarM_Scroll(object sender, EventArgs e)
        {
            labelM.Text = TrackBarM.Value.ToString();
            var minute = TrackBarM.Value;
            var m = minute * 60 * 1000;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        public void button3_Click(object sender, EventArgs e)
        {
            timer1.Dispose();
            timer2.Dispose();
            timer2.Stop();
            label6.Text = "0"; label7.Text = "0"; label8.Text = "0";
            progressBar1.Value = 0;
            TrackBarM.Value = 1;
            trackBarH.Value = 0;
            labelH.Text = trackBarH.Value.ToString();
            labelM.Text = TrackBarM.Value.ToString();

        }
        Form2 frm;
        private void timer2_Tick(object sender, EventArgs e)
        {
            
            //var mode = timer1.Interval;

            int lbs = int.Parse(label8.Text);
            int lbm = int.Parse(label7.Text);
            int lbh = int.Parse(label6.Text);

            var mode = lbs * 1000 + lbm * 1000 * 60 + lbh * 1000 * 3600;
            var hole = mode - 1000;
            
            var chas = hole / 3600 / 1000;
            var min = (hole - (chas * 3600 * 1000)) / 60 / 1000;
            var sec = (hole - (chas * 3600 * 1000) - (min * 60 * 1000)) / 1000;
            
            label6.Text = chas.ToString(); label7.Text = min.ToString(); label8.Text = sec.ToString();

            try
            {
                progressBar1.Maximum = timer1.Interval + 1;
                progressBar1.Value = timer1.Interval - hole;
            }
            catch (Exception) { }


            if (label8.Text == "0" && label7.Text == "1" && label6.Text == "0")
            {
                //открываем форму 2

                if (frm != null)
                {

                    frm.Close();
                }

                frm = new Form2();

                frm.Show(this);



            }

            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // делаем нашу иконку скрытой
            notifyIcon1.Visible = false;
            // возвращаем отображение окна в панели
            this.ShowInTaskbar = true;
            //разворачиваем окно
            WindowState = FormWindowState.Normal;
        }

        internal void button3_Click()
        {
            throw new NotImplementedException();
        }
    }
}
