﻿
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

        public void AddPerson(string name, string lastName, byte age, string post)
        {
            name = Name;
            lastName = LastName;
            age = Age;
            post = Post;
            List<Person> listPerson = new List<Person>();
        }
    }
}