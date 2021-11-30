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
// TODO: Сделать возможность удалять и изменять текущие записи
// TODO: Добавить возсожность фильтровать а то есть искать нужное в файле.
// TODO: Необязательно, но шифровать свои записи в каком нибуть json или xml
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
                            Table.Rows[i-1].Cells[j-1].Value = ws.Cells[i,j].Value;
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
                            Table.Rows[i - 1].Cells[j - 1].Value = ws.Cells[i, j].Value;
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
        //TODO: Доработать фильтр чтобы корректно работал(сама ошибка:он почему то не работает больше 1 раза за 1 запуск приложения)
        public void button5_Click(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex == 0)
            {
                Filter(textBox1.Text,2);
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                Filter(textBox1.Text, 3);
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                Filter(textBox1.Text, 2);
            }
            else if (comboBox2.SelectedIndex == 3)
            {
                Filter(textBox1.Text, 3);
            }
        }
        /// <summary>
        /// Сам фильтр
        /// </summary>
        /// <param name="line">Значение на которое проверяем</param>
        /// <param name="index">индекс(в экселе столбец) проверяемого значения</param>
        public void Filter(string line, int index)
        {
            //Ищем по фильтру
            if (comboBox1.SelectedIndex == 1)
            {
                string path = @"C:\Users\nikit\source\repos\AutoService\AutoService\Resours\auto.xlsx";
                FileInfo fileInfo = new FileInfo(path);
                using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
                {
                    var ws = excelPackage.Workbook.Worksheets.FirstOrDefault();
                    Table.RowCount = Convert.ToInt32(ws.Cells[1, 8].Value) + 1;
                    Table.ColumnCount = 7;
                    for (var i = 1; i <= Table.RowCount; i++)
                    {
                        if ((string)ws.Cells[i, index].Value == line || i == 1)
                        {
                            for (var j = 1; j <= Table.ColumnCount; j++)
                            {
                                Table.Rows[i - 1].Cells[j - 1].Value = ws.Cells[i, j].Value;
                            }
                        }
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 0)
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
                        if ((string)ws.Cells[i, index].Value == line || i == 1)
                        {
                            for (var j = 1; j <= Table.ColumnCount; j++)
                            {
                                Table.Rows[i - 1].Cells[j - 1].Value = ws.Cells[i, j].Value;
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали что искать");//ошибка
            }
        }
    }
}
