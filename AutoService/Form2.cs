using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using OfficeOpenXml;

namespace AutoService
{
    /// <summary>
    /// Форма добавления новых авто и рабочих
    /// </summary>
    // TODO: Полностью избавится от листов и настроиты !!Красивый!! вывод
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
            if (Mistakes(textBox1.Text,true)||
                Mistakes(textBox2.Text)||
                Mistakes(textBox3.Text, true)||
                Mistakes(textBox4.Text)||
                Mistakes(textBox5.Text, true))
            {
                MessageBox.Show("Чувак тут чет не то");
            }
            else
            {
                Auto auto = new Auto();
                auto.listAuto.Add(new Auto
                {
                    Number = textBox1.Text,
                    Marka = textBox2.Text,
                    Model = textBox3.Text,
                    NameHolder = textBox4.Text,
                    Damage = textBox5.Text
                });//добавляем в лист
                using (var sw = new StreamWriter(
                    @"C:\Users\nikit\source\repos\AutoService\AutoService\Resours\auto.txt", true))
                {
                    sw.WriteLine(auto.listAuto[0]);//записываем в файл в новом потоке
                }
                string path = @"C:\Users\nikit\source\repos\AutoService\AutoService\Resours\auto.xlsx";
                FileInfo filePath = new FileInfo(path);//добаляем наш файл
                using (var excelPack = new ExcelPackage(filePath))//в новом потоке записываем новые значения
                {
                    var ws = excelPack.Workbook.Worksheets.FirstOrDefault();//рабочий лист
                    int j = Convert.ToInt32(ws.Cells[1, 7].Value);//кастыль он тут нужен
                    ws.Cells[j, 1].Value = j;//ID
                    ws.Cells[j, 2].Value = textBox1.Text;//Number
                    ws.Cells[j, 3].Value = textBox2.Text;//Marka
                    ws.Cells[j, 4].Value = textBox3.Text;//Model
                    ws.Cells[j, 5].Value = textBox4.Text;//NameHolder
                    ws.Cells[j, 6].Value = textBox5.Text;//Damage
                    j++;
                    ws.Cells[1, 7].Value = j;//записываем кастыль
                    excelPack.Save();//не забываем сохранить
                }
            }
        }
        /// <summary>
        /// Кнопка добавления нового рабочего в список, а позже и в файл 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPerson_Click(object sender, EventArgs e)
        {
            if (Mistakes(textBox6.Text) ||
               Mistakes(textBox7.Text) ||
               textBox8.Text == null || (!Regex.IsMatch(textBox8.Text, @"^[0-9]+$")) ||
               Mistakes(textBox9.Text))
            {
                MessageBox.Show("Чувак тут чет не то");
            }
            else
            {
                //для вывода
                Person person = new Person();
                person.listPerson.Add(new Person
                {
                    Name = textBox6.Text,
                    LastName = textBox7.Text,
                    Age = Convert.ToByte(textBox8.Text),
                    Post = textBox9.Text
                });//добавляем в лист
                using (var sw = new StreamWriter(
                    @"C:\Users\nikit\source\repos\AutoService\AutoService\Resours\person.txt", true))
                {
                    sw.WriteLine(person.listPerson[0]);//записываем в файл в новом потоке
                }
                //запись для изменинений и удаления
                //ссылка на xmlx документ 
                string path = @"C:\Users\nikit\source\repos\AutoService\AutoService\Resours\person.xlsx";
                FileInfo filePath = new FileInfo(path);//добаляем наш файл
                using (var excelPack = new ExcelPackage(filePath))//в новом потоке записываем новые значения
                {
                    var ws = excelPack.Workbook.Worksheets.FirstOrDefault();//рабочий лист
                    int j = Convert.ToInt32(ws.Cells[1, 6].Value);//кастыль
                    ws.Cells[j, 1].Value = j;//Id
                    ws.Cells[j, 2].Value = textBox6.Text;//Name
                    ws.Cells[j, 3].Value = textBox7.Text;//LastName
                    ws.Cells[j, 4].Value = Convert.ToByte(textBox8.Text);//Age не знаю зачем я записываю в числе если потом она все равно строка ну  и ладно
                    ws.Cells[j, 5].Value = textBox9.Text;//Post
                    j++;
                    ws.Cells[1, 6].Value = j;//rкастыль
                    excelPack.Save();//сохраняем
                }
            }
        }
        /// <summary>
        /// Проверяет есть ли в тексте только буквы
        /// </summary>
        /// <param name="text">Текст который будем проверять</param>
        /// <returns></returns>
        public bool Mistakes(string text)
        {
            if (text == null ||
                text == "" ||
                Regex.IsMatch(text, @"^[0-9]+$"))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Проверяет есть ли в тексте только цифры и буквы
        /// </summary>
        /// <param name="text">Текст который будем проверять</param>
        /// <param name="numbers">Есть ли цифры</param>
        /// <returns></returns>
        public bool Mistakes(string text,bool numbers)
        {
            if(numbers == true)
            {
                if (text == null ||
                   text == "")
                {
                    return true;
                }
            }
            else
            {
                return Mistakes(text);
            }
            return false;
        }
    }
}
