using System;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using Lab10.Models;
using Lab10.Services;

namespace Lab10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string path1 = $"{Environment.CurrentDirectory}\\MainInformList.json";

        private FileIO _FileService;

        private Data _data;

        private BindingList<OrderComponent> listcomp = new BindingList<OrderComponent>();//список компонентов
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _FileService = new FileIO(path1);
                _data = _FileService.Load();//заполнение данными из файла
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MainData.ItemsSource = _data.Orders;//закрепление заказов и верхнего datagrid
            
            foreach (var item in _data.Dishes)
            {
                listcomp.Add(new OrderComponent(item));//заполнение списка компонентов
            }
            
            listcomp.ListChanged += Listcomp_ListChanged;//добавление обработчика
            
            ComponentsData.ItemsSource = listcomp;//закрепление компонентов и нижнего datagrid
        }

        private void Listcomp_ListChanged(object sender, ListChangedEventArgs e)
        {

            OrderComponent needed = listcomp[e.NewIndex];//вынесение в отдельную переменную компонент,взятый из списка по индексу
            Order order = (Order)MainData.SelectedItem;//вынесение в отдельную переменную выбранный заказ

            if (needed.IsSelect == true)//проверка на нажатый флажок в checkbox
            {
                if (!order.Components.Contains(needed))
                {
                    order.Components.Add(new OrderComponent(needed.Dish, needed.IsSelect, needed.CountComp));//добавление компонента в заказ
                }
                else
                {
                    order.Components.Find(x => x.Dish.Name == needed.Dish.Name).CountComp = needed.CountComp;//установка количества выбранного компонента
                }
            }
            else
            {
                if (order.Components.Contains(needed))
                {
                    order.Components.Remove(needed);//удаление компонента в заказе
                }

            }
            order.Account();//вызов метода вычисления стоимости заказа
        }

        private void Couriers_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox combo = (ComboBox)sender;//приведение к одному типу
            combo.ItemsSource = _data.Couriers;//заполнение combobox
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
             try
             {
                 _FileService.Save(_data);//сохранение
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
        }
        /// <summary>
        /// Метод, осуществляющий вывод выбранных компонентов в заказе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listcomp.ListChanged -= Listcomp_ListChanged;//выключение, чтобы не изменить количества компонента
            if (MainData.SelectedItem != null && MainData.SelectedItem is Order)
            {
                Order order = (Order)MainData.SelectedItem;//вынесение в отдельную переменную выбранный заказ
                foreach (OrderComponent item in listcomp)
                {
                    if (order.Components.Exists(x=>x.Dish.Name==item.Dish.Name))
                    {
                        item.IsSelect = true;
                        item.CountComp = order.Components.Find(x => x.Dish.Name == item.Dish.Name).CountComp;//вывод найденного количества
                    }
                    else
                    {
                        item.CountComp = 0;
                        item.IsSelect = false;
                    }
                }
            }
            listcomp.ListChanged += Listcomp_ListChanged;
        }
        /// <summary>
        /// Кнопка удаления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext is Order)
            {
                _data.Orders.Remove((Order)((Button)sender).DataContext);
            }
        }
    }
}
