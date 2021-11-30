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
using OfficeOpenXml;
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
            Visibles();
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
            if (comboBox1.SelectedIndex == 1)//auto
            {
                string path = @"C:\Users\nikit\source\repos\AutoService\AutoService\Resours\auto.xlsx";
                FileInfo fileInfo = new FileInfo(path);
                using(ExcelPackage excelPackage = new ExcelPackage(fileInfo))
                {
                    var ws = excelPackage.Workbook.Worksheets.FirstOrDefault();
                    Table.RowCount = Convert.ToInt32(ws.Cells[1, 8].Value)+1;
                    Table.ColumnCount = 7;
                    for (var i = 1;i <= Table.RowCount; i++)
                    {
                        for(var j = 1; j <= Table.ColumnCount; j++)
                        {
                            if (Filter(textBox1.Text, (string)ws.Cells[i, indexcreate()].Value,i)||textBox1.Text == "")
                                Table.Rows[i - 1].Cells[j - 1].Value = ws.Cells[i, j].Value;
                            else
                                Table.Rows[i - 1].Cells[j - 1].Value = "";
                        }
                    }
                }
            }
            else if(comboBox1.SelectedIndex == 0)//person
            {
                string path = @"C:\Users\nikit\source\repos\AutoService\AutoService\Resours\person.xlsx";
                FileInfo fileInfo = new FileInfo(path);
                using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
                {
                    var ws = excelPackage.Workbook.Worksheets.FirstOrDefault();
                    Table.RowCount = Convert.ToInt32(ws.Cells[1, 7].Value) + 1;
                    Table.ColumnCount = 6;
                    for (var i = 1; i <= Table.RowCount; i++)
                    {
                        for (var j = 1; j <= Table.ColumnCount; j++)
                        {
                            if (Filter(textBox1.Text, (string)ws.Cells[i, indexcreate()].Value,i)||textBox1.Text == "")
                                Table.Rows[i - 1].Cells[j - 1].Value = ws.Cells[i, j].Value;
                            else
                                Table.Rows[i - 1].Cells[j - 1].Value = "";
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали что искать");//ошибка
            }
        }
        /// <summary>
        /// проверка на пароль
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if(Password.Text == "Password")
            {
                MessageBox.Show("Теперь вы можете изменять, как закончите нажмите на новую кнопку ,иначе ничего не сохранится!");
                Table.ReadOnly = false;
                button4.Visible = true;
            }
            else
            {
                MessageBox.Show("Неправильный пароль");
            }
        }
        /// <summary>
        /// Если пароль верный то тут разршается редактировать пользрвателю таблицу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            Table.ReadOnly = true;//запрещаем редактирование
            Password.Text = "";//очищаем пароль
            //сохраняем изменения
            if (comboBox1.SelectedIndex == 0)
            {
                string path = @"C:\Users\nikit\source\repos\AutoService\AutoService\Resours\person.xlsx";
                FileInfo filePath = new FileInfo(path);//добаляем наш файл
                using (var excelPack = new ExcelPackage(filePath))//в новом потоке записываем новые значения
                {
                    var ws = excelPack.Workbook.Worksheets.FirstOrDefault();
                    Table.RowCount = Convert.ToInt32(ws.Cells[1, 7].Value) + 1;
                    Table.ColumnCount = 6;
                    for (var i = 1; i <= Table.RowCount; i++)
                    {
                        for (var j = 1; j <= Table.ColumnCount; j++)
                        {
                            ws.Cells[i, j].Value = Table.Rows[i - 1].Cells[j - 1].Value;
                        }
                    }
                    excelPack.Save();//сохраняем
                }
                MessageBox.Show("Изменения сохранены");
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                string path = @"C:\Users\nikit\source\repos\AutoService\AutoService\Resours\auto.xlsx";
                FileInfo filePath = new FileInfo(path);//добаляем наш файл
                using (var excelPack = new ExcelPackage(filePath))//в новом потоке записываем новые значения
                {
                    var ws = excelPack.Workbook.Worksheets.FirstOrDefault();
                    Table.RowCount = Convert.ToInt32(ws.Cells[1, 8].Value) + 1;
                    Table.ColumnCount = 7;
                    for (var i = 1; i <= Table.RowCount; i++)
                    {
                        for (var j = 1; j <= Table.ColumnCount; j++)
                        {
                            ws.Cells[i, j].Value = Table.Rows[i - 1].Cells[j - 1].Value;
                        }
                    }
                    excelPack.Save();//сохраняем
                }
                MessageBox.Show("Изменения сохранены");
            }
        }
        /// <summary>
        /// Некое подобие фильтра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button5_Click(object sender, EventArgs e)
        {
            button1_Click(e, e);
        }
        /// <summary>
        /// показывает нужный индекс 
        /// </summary>
        /// <returns></returns>
        public int indexcreate()
        {
            if (comboBox2.SelectedIndex == 0)
            {
                return 2;
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                return 3;
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                return 2;
            }
            else if (comboBox2.SelectedIndex == 3)
            {
                return 3;
            }
            else
            {
                MessageBox.Show("Выберете что хотите фильтровать");
            }
            return 0;
        }
        /// <summary>
        /// Сам фильтр
        /// </summary>
        /// <param name="line">Значение на которое проверяем</param>
        /// <param name="index">индекс(в экселе столбец) проверяемого значения</param>
        public bool Filter(string line, string index,int i)
        {
            if(line == index || i == 1)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Показывает и скрывает элементы изменения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            if (label4.Visible == false)
            {
                label4.Visible = true;
                Password.Visible = true;
                button3.Visible = true;
                Visibles(true);
            }
            else
            {
                label4.Visible = false;
                Password.Visible = false;
                button3.Visible = false;
                Visibles();
            }
        }
        /// <summary>
        /// Показывает и скрывает элементы фильтра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click_1(object sender, EventArgs e)
        {
            if (label1.Visible == false)
            {
                label1.Visible = true;
                label2.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                comboBox2.Visible = true;
                textBox1.Visible = true;
                Visibles(true);
            }
            else
            {
                label1.Visible = false;
                label2.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                comboBox2.Visible = false;
                textBox1.Visible = false;
                Visibles();
            }
        }
        /// <summary>
        /// Добавляют красоты с выдвигающимися функциями
        /// </summary>
        public void Visibles()
        {
            Point loc = label3.Location;
            loc.Y = 126;
            label3.Location = loc;
            Point loc1 = button6.Location;
            loc1.Y = 126;
            button6.Location = loc1;
        }
        public void Visibles(bool o)
        {
            Point loc = label3.Location;
            loc.Y = 324;
            label3.Location = loc;
            Point loc1 = button6.Location;
            loc1.Y = 326;
            button6.Location = loc1;
        }
    }
}
