using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoService
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            // вызываем главную форму приложения, которая открыла текущую форму Form2, главная форма всегда = 0
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
        }

        private void AddAuto_Click(object sender, EventArgs e)
        {
            Auto auto = new Auto();
            auto.AddAuto(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
        }

        private void AddPerson_Click(object sender, EventArgs e)
        {
            Person person = new Person();
            person.AddPerson(textBox6.Text, textBox7.Text, Convert.ToByte(textBox8.Text), textBox9.Text);
        }
    }
}
