using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab10.Models
{
    class OrderComponent : INotifyPropertyChanged
	{
		public Dish Dish { get; set; }//объект,содержащий имя и цену компонента
		
		private bool _isSelect;
		public bool IsSelect
		{
			get { return _isSelect; }
			set
			{
				if (_isSelect == value)
				{
					return;
				}
				_isSelect = value;
				OnProperyChanged();
			}
		}
		private int _countComp;
		public int CountComp
		{
			get { return _countComp; }
			set
			{
				if (_countComp == value)
				{
					return;
				}
				_countComp = value;
				OnProperyChanged();
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnProperyChanged([CallerMemberName]string propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		public OrderComponent(Dish Dish)
		{
			this.Dish = Dish;
		}
		public OrderComponent(Dish dish,bool IsSelect,int CountComp)
		{
			this.Dish = dish;
			this.IsSelect = IsSelect;
			this.CountComp = CountComp;
		}
		public OrderComponent() { }
		/// <summary>
		/// Переопределенный метод для сравнения объектов по имени объекта
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			if (obj is OrderComponent)
			{
				if (((OrderComponent)obj).Dish.Name == Dish.Name)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}
	}
}
