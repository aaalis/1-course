   M S B A M L   `   `   `  ����	  Lab10    Lab10.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5        $	��570��5      $
��1150��6'     � 
ResizeMode$  CanMinimize=�6K   ��5      �� 5   
    �� Color$ 	#FFFFFFE1��6   .��5
      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��0��6,   $	��220��69   $��Center=�6F   $��Stretch=�6c   $
��18,0q�6   $	��998��6�   .+�5      �� $��Center=�6   $��Center=�63   $��25��6W   $��16(�6c    �� TextWrapping$
 Wrap=�6q   $7��1Основные сведения о заказе��6�   $	��Top=�6�   $	��306��6�   $��0,0,0,10q�6�   &   System.Windows.Controls.DataGrid  5      -   5          Name$ MainData��5   2   $
��Left=�6   $	��195��6D   $	��Top=�6Q   $
��1008��6i   $��14(�6v      AutoGenerateColumns .     SelectionMode$ Single=�6�      HorizontalGridLinesBrush
 �����	   VerticalGridLinesBrush
	 �����$��0,0,0,10q�6"  
   Columns
 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Дата��6-   -   5        Date��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 5   I      CellTemplate 5      �� 5      .R�5   "   (  "System.Windows.Controls.DatePicker     SelectedDate 6-   ��  �� Path$ dDate� �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�5      5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        	dTime��$ 
Время��5   �   $	 100 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� $ dTime�$ PropertyChanged=�$ TwoWay=�6�     5      $ 
Номер��6z   -   5        	Count��$ 75 5   �    6)   �� $ Count�$ PropertyChanged=�$ TwoWay=�6�     5      $ 
Адрес��6|   -   5        Address��$	 255 5   �    6)   �� $ Address�$ PropertyChanged=�$ TwoWay=�6�     5      $ Курьер��6-   -   5        Courier��$ 80 5   N    5      �� 5      .R�5    "   ��  ��Name$ Couriers��6+   -   5        
����iA� �� SelectedItem 5    =   �� *SelectCourier+$ PropertyChanged=�$ TwoWay=���5!   &   �� 5"   *   .R�5#   .   �� ��68   �� 5$   +   5&   #   5'      5)        5*      $! Время доставки��6y   -	   5        Time��$	 120 5*   �    6)   �� $
 Time�$ PropertyChanged=�$ TwoWay=�6�     5+      $ Скидка,%��6y   -
   5        Sale��$ 80 5+   �    6)   �� $
 Sale�$ PropertyChanged=�$ TwoWay=�6�     5,      $ Стоимость,руб��6   -   5        
TotalPrice��$	 100 5,   �    6)   �� $ 
TotalPrice�$ PropertyChanged=�$ TwoWay=�   HeaderStyle 5-      �� 5.       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6$   .�5/   "   ��  �� Property � �� �� Value
 � E��6?   50         	CellStyle 52      �� 53      *	  $System.Windows.Controls.DataGridCell" 	 6$   .�54   "   ��  � ��
 � E��6?   55      57        58       59      �� 5:      .R�5;   "   ��  ��Name$ Delete��6)   -   5        $��25��5;   9   $��25��6D   $��0q�6e   ��6q   Z� ��6�   Z� .��5<   &   �� $��
delbut.png��6,   $��25��6@   $��25��6K   5=   #   5>      5@      5B      5C      �� 5D   
   $��1��6   $ Vertical=�6"   $��Center=�69   $	��Top=�6V   $	��220��6n   $��267,0q�6{   $	��500��6�   .+�5E      �� $��Center=�6   $��Center=�63   $��25��6W   $��16(�6c   $
 Wrap=�6q   $'��!Компоненты заказа��6�   $	��Top=�6�   $	��306��6�   $��0,0,0,10q�6�     5F      -   5        $ ComponentsData��5F   4   $��Center=�6   $	��195��6L   $	��Top=�6Y   $	��500��6q   $��14(�6}    .  $��0,0,0,13q�6�      CanUserAddRows .  
 5G      4
  .System.Windows.Controls.DataGridCheckBoxColumn
  5H      $ 50 6-   -   5        isSelect��$  ��5J   )    5K   )   �� $ IsSelect�$ PropertyChanged=�$ TwoWay=�  5L      $ Название��6)   -   5        Dish��   
IsReadOnly . $	 250 5P   %    5M   %   �� $ 	Dish.Name�5P   %     5Q      $ Цена,руб��6)   -   5        	Price�� . $	 100 5U   %    5R   %   �� $ 
Dish.Price�5U   %     5V      $ Количество��6)   -   5        	CountComp��$ * 5Y   %    5W   %   �� $ 	CountComp�$ 	LostFocus=�$ TwoWay=�5Y   %   5[      5\      5]      5^      