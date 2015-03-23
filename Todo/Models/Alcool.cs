using System;
using SQLite.Net.Attributes;
using Xamarin.Forms;

namespace Todo
{
    public class Alcool
    {
        public Alcool ()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Index { get; set;}
    }
}

