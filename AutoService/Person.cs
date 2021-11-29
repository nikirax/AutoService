
using System.Collections.Generic;

namespace AutoService
{
    /// <summary>
    /// Список работников
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public byte Age { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public string Post { get; set; }
        /// <summary>
        /// Лист рабочих для добавления в файл
        /// </summary>
        public List<Person> listPerson = new List<Person>();

        public override string ToString()
        {
            return $"Имя: {Name},  Фамилия: {LastName},  Возраст: {Age},  Должность: {Post}";
        }
    }
}
