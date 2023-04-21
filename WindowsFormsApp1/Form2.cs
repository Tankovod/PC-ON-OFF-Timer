using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {

        

       
        public Form2()
        {
            InitializeComponent();
            timer1.Tick -= new EventHandler(timer1_Tick);
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        public void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm1.timer1.Dispose();
            frm1.timer2.Dispose();
        }

        


        private void label1_Click(object sender, EventArgs e)
        {

        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Form1 frm1;
        private void button2_Click(object sender, EventArgs e)
        {
            frm1 = new Form1();
            


            try
            {
              
                frm1.timer1.Enabled = false;
                frm1.timer2.Enabled = false;
                frm1.timer1.Dispose();//освобождает ресурсы от таймера
                frm1.timer2.Dispose();
                frm1.button3_Click();
            }
            catch (Exception) { }
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Form2 frm2;
            int lbs = int.Parse(label1.Text);
            string time = (lbs - 1).ToString();
            label1.Text = time;

             
    }
    }
}
