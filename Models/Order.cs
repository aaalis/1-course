using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using Lab10.Services;

namespace Lab10.Models
{
	class Order : INotifyPropertyChanged
	{		
		private DateTime DateTime { get; set; } = DateTime.Now;
		private Random rndforcount = new Random();

		#region Property
		private string _dDate;
		public string dDate
		{
			get { return _dDate; }
			set
			{
				_dDate = value;
				OnProperyChanged();
			}
		}

		private string _dTime;
		public string dTime
		{
			get { return _dTime; }
			set
			{
				_dTime = value;
				OnProperyChanged();
			}
		}
		
		private int _count;
		public int Count
		{
			get
			{
				return _count;
			}
			set
			{
				if (_count == value)
				{
					return;
				}
				_count = value;
				OnProperyChanged();
			}
		}

		private string _address;
		public string Address
		{
			get { return _address; }
			set
			{
				if (_address == value)
				{
					return;
				}
				_address = value;
				OnProperyChanged();
			}
		}
		
		private string _selectcourier;
		public string SelectCourier
		{
			get { return _selectcourier; }
			set
			{
				_selectcourier = value;
				OnProperyChanged();
			}
		}
		
		private int _time;
		public int Time
		{
			get { return _time; }
			set
			{
				if (_time == value)
				{
					return;
				}
				_time = value;
				OnProperyChanged();
			}
		}
		
		private int _sale;
		public int Sale
		{
			get { return _sale; }
			set
			{
				if (_sale == value)
				{
					return;
				}
				_sale = value;
				Account();
				OnProperyChanged();
			}
		}
		
		private double _totalprice;
		public double TotalPrice
		{
			get { return _totalprice; }
			set
			{
				_totalprice = value;
				OnProperyChanged();
			}
		}
		#endregion
		public List<OrderComponent> Components { get; set; } = new List<OrderComponent>();//список компонентов, которые содержаться в заказе

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnProperyChanged([CallerMemberName]string propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		public Order()
		{
			_count = rndforcount.Next(1000, 9999);
			dDate = DateTime.ToString("dd:MM:yyyy");
			dTime = DateTime.ToString("HH:mm:ss");
		}
		/// <summary>
		/// Метод,в котором вычисляется _totalprice
		/// </summary>
		public void Account()
		{
			double total = 0;
			foreach (OrderComponent item in Components)
			{
				total += item.CountComp * item.Dish.Price;
			}
			total = total - (total * _sale / 100);
			TotalPrice = total;
		}
	}
}
