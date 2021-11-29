using System.Collections.Generic;

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

        public void AddAuto(string number,string marka,string model,string nameHolder,string damage)
        {
            number = Number;
            marka = Marka;
            model = Model;
            nameHolder = NameHolder;
            damage = Damage;
            List<Auto> listAuto = new List<Auto>();
        }
    }
}
