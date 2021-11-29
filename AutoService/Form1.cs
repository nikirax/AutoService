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
    /// <summary>
    /// Основная форма где можно найти и посмотреть всех пользователей и авто 
    /// </summary>
    public partial class Form1 : Form 
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        /// <summary>
        /// Вызов 2 формы при нажатии кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Form ifrm = new Form2();
            ifrm.Show(); // отображаем Form2
            this.Hide();
        }
        /// <summary>
        /// Чтение файла взависимости что мы выбрали из выпадающего списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button1_Click(object sender, EventArgs e)
        {
            //Ищем по индексу
            if (comboBox1.SelectedIndex == 1)
            {
                using (var rw = new StreamReader(@"C:\Users\nikit\source\repos\AutoService\AutoService\Resours\auto.txt"))
                {
                    label3.Text = rw.ReadToEnd();//авто читаем
                }
            }
            else if(comboBox1.SelectedIndex == 0)
            {
                using (var rw = new StreamReader(@"C:\Users\nikit\source\repos\AutoService\AutoService\Resours\person.txt"))
                {
                    label3.Text = rw.ReadToEnd();//персонал читаем
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали что искать");//ошибка
            }
        }
    }
}
