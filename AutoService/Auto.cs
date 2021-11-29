using System;
using System.Collections.Generic;
using System.IO;

namespace AutoService
{
    /// <summary>
    /// Авто 
    /// </summary>
    class Auto 
    {
        /// <summary>
        /// Номер авто
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// Марка авто
        /// </summary>
        public string Marka { get; set; }
        /// <summary>
        /// Модель авто
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// Инициалы владельца авто 
        /// </summary>
        public string NameHolder { get; set; }
        /// <summary>
        /// Поломка
        /// </summary>
        public string Damage { get; set; }
        /// <summary>
        /// Лист авто для добавления в файл
        /// </summary>
        public List<Auto> listAuto = new List<Auto>();

        public override string ToString()
        {
            return $"Номер авто: {Number},Марка авто: {Marka},Модель: {Model},Имя владельца: {NameHolder},Что нужно починить: {Damage}";
        }
    }
}
