﻿using System;
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
    /// Форма добавления новых авто и рабочих
    /// </summary>
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Вызываем 1 форму если 2 закрыта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            // вызываем главную форму приложения, которая открыла текущую форму Form2, главная форма всегда = 0
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
        }
        /// <summary>
        /// Кнопка добавления нового авто в список, а позже и в файл 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddAuto_Click(object sender, EventArgs e)
        {
            Auto auto = new Auto();
            auto.listAuto.Add(new Auto { Number = textBox1.Text, Marka = textBox2.Text,Model = textBox3.Text,NameHolder = textBox4.Text, Damage = textBox5.Text });//добавляем в лист
            using (var sw = new StreamWriter(@"C:\Users\nikit\source\repos\AutoService\AutoService\Resours\auto.txt", true))
            {
                sw.WriteLine(auto.listAuto[0]);//записываем в файл в новом потоке
            }
        }
        /// <summary>
        /// Кнопка добавления нового рабочего в список, а позже и в файл 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPerson_Click(object sender, EventArgs e)
        {
            Person person = new Person();
            person.listPerson.Add(new Person {Name = textBox6.Text,LastName = textBox7.Text, Age = Convert.ToByte(textBox8.Text) , Post = textBox9.Text});//добавляем в лист
            using (var sw = new StreamWriter(@"C:\Users\nikit\source\repos\AutoService\AutoService\Resours\person.txt", true))
            {
                sw.WriteLine(person.listPerson[0]);//записываем в файл в новом потоке
            }
        }
    }
}
