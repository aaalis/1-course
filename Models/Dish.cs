using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10.Models
{
    class Dish
    {
		private string _name;
		public string Name
		{
			get { return _name; }
			set
			{
				if (_name == value)
				{
					return;
				}
				_name = value;
			}
		}
		private int _price;
		public int Price
		{
			get { return _price; }
			set
			{
				if (_price == value)
				{
					return;
				}
				_price = value;
			}
		}
	}
}
