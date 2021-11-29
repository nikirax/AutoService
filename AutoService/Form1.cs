using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoService
{
    public partial class Form1 : Form 
    {

        //List<Auto> listAuto = new List<Auto>();

        public Form1()
        {
            InitializeComponent();
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form ifrm = new Form2();
            ifrm.Show(); // отображаем Form2
            this.Hide();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                using (var rw = new StreamReader(@"C:\Users\nikit\source\repos\AutoService\AutoService\Resours\auto.txt"))
                {
                    label3.Text = rw.ReadToEnd();
                }
            }
            else if(comboBox1.SelectedIndex == 0)
            {
                using (var rw = new StreamReader(@"C:\Users\nikit\source\repos\AutoService\AutoService\Resours\person.txt"))
                {
                    label3.Text = rw.ReadToEnd();
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали что искать");
            }
        }
    }
}
