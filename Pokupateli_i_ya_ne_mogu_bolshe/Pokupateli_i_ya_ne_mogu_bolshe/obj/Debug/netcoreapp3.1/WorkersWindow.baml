   M S B A M L   `   `   `  ����Y  UPokupateli_i_ya_ne_mogu_bolshe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Pokupateli_i_ya_ne_mogu_bolshePokupateli_i_ya_ne_mogu_bolshe  5   	   2    ,Pokupateli_i_ya_ne_mogu_bolshe.WorkersWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:Pokupateli_i_ya_ne_mogu_bolshe     5   	     � Title$  WorkersWindow��5   	   $	��450��6   $	��800��6,   .��5	      �  � RowDefinitions 5
   
   �� 5      $��2* �6   �� 5       � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��5* �6   .+�5   
   �� -   5         ��Name$ 	Customers��5   $   $��2��6    �� View 5      �� 5      .P�5      �� $��
Логин��6%    �� DisplayMemberBinding 64   ��  �� Path$ Login��� 5      $��Имя��6%    62   �� $
 Name��� 5      $��
Адрес��6%    64   �� $ Adress�5      5      �� 5   
   -   5        $ Orders��5   0   $��2��6   $��2��6#    5      �� 5      .P�5      �� $��
Номер��6%    64   �� $ Number��� 5      $��Стоимость��6%    68   �� $ Price��� 5       $��Время заказа��6%    6;   �� $ DateTime��� 5!      $��Заказчик��6%    67   �� $ 
Cust.Login��� 5"      $��Статус��6%    �� Width$	 300��65    6A   �� $ Status�5#      5%      �� 5&   
   -   5         ��Name$ 	Processed��5&   n   $��Обработан��6   $��1��6%   $
��Left=�65   $��	0,249,0,0q�6P   $��70��6c   $��20��6�   $	��Top=�6�   �� 5'   
   -   5        $ Shipped��5'   n   $��Отгружен��6   $��1��6$   $
��Left=�64   $��
75,249,0,0q�6O   $��70��6c   $��20��6�   $	��Top=�6�   �� 5(   
   -   5        $
 Done��5(   o   $��Исполнен��6   $��1��6$   $
��Left=�64   $��150,249,0,0q�6O   $��70��6d   $��20��6�   $	��Top=�6�   �� 5)   
   -   5        	 ��Name$	 Active��5)   �   $#��Только активные��6   $��1��6-   $
��Left=�6=   $��225,252,0,0q�6X   $	��Top=�6m   6�   �� 5*   
   -   5        $ OpenOne��5*   �   $)��#Открыть выбранного��6   $��1��6.   $
��Left=�6>   $��5,10,0,0q�6Y   $	��Top=�6k   $	��150��6�   6�   �� 5+   
   -   5        $ OpenAll��5+   �   $(��"Открыть все заказы��6   $��1��6.   $
��Left=�6>   $��5,35,0,0q�6Y   $	��Top=�6k   $	��150��6�   6�   5.      5/      