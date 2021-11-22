using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10.Models
{
    class Data
    {
        public List<string> Couriers { get; set; }//список курьеров
        public BindingList<Order> Orders { get; set; }//список заказов
        public BindingList<Dish> Dishes { get; set; }//список компонентов/блюд
    }
}
