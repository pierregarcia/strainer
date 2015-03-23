using System;
using SQLite.Net.Attributes;
using Xamarin.Forms;

namespace Todo
{
	public class TodoItem
	{
		public TodoItem ()
		{
            BaseAlcoolIndex = -1;
            GlasswareIndex = -1;
            MeasureIndex = -1;
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Name { get; set; }
		public string Notes { get; set; }
        public string BaseAlcool { get; set;}
        public string BaseAlcoolColor { get; set;}
        public int BaseAlcoolIndex { get; set;}

        public string Glassware { get; set;}
        public int GlasswareIndex { get; set;}

        public string Measure { get; set;}
        public int MeasureIndex { get; set;}

		public bool Done { get; set; }
	}
}

