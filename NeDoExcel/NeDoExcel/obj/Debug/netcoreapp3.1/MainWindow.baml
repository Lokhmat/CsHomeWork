   M S B A M L   `   `   `  ����D  @NeDoExcel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:NeDoExcel	NeDoExcel  5   	       NeDoExcel.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:NeDoExcel     5   	     � Title$  
MainWindow��5
   	   $	��450��6   $	��800��6)   ���	#FF272727.��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   6*   �� 5       � ColumnDefinitions 5   
   �� 5      $��8* �6   6,   �� 5      $��2* �6   6,   .+�5   
   c� ���	#FF272727���	#FF272727$��	0,0,-24,0q�6@    `� IsLocked$
 True��6S   $��2��6o   .@�5      o� ���	#FF272727.@�5      m� $��Файл��6   ���	#FF272727���	#FFE0DDDD$��0,0,0,0q�6W   $��25��6q   ��5      �� 5       �� Triggers 5      P� 5   "    P� Property �@J�IsMouseOver P� Value$
 true��6J   . �5   &   ��  �� Property � �� �� Value
 �����6L   �� 5   &    � �� �#2933406L   5   #   5      .@�5!      m� -   5        $��Открыть��5!      60   5#      5$      �� 5%      -   5        $*��$Построить график X->Y��5%      ���	#FFE0DDDD6e   �� 5&      -   5        $��О программе��5&      ���	#FFE0DDDD6\   5'      &   System.Windows.Controls.DataGrid  5(   
   -   5        	  Name$	 	tableGrid��5(      $��1��6&   
   SelectionMode$
 Extended=�6K      CanUserSortColumns$ False��6d      SelectionUnit$ CellOrRowHeader=�6      
IsReadOnly$
 True��6�   ��63   �� 6�   �� 5)   
   $��Посчитать:��6   $��1��6%   $��Center=�65   $��0,5,0,0q�6R   $��1��6c   $	��Top=�6p   
�������6�   �� 5*   
   -   5         ��Name$ midLabel��5*      $��Среднее - ��6"   $��1��67   $
��Left=�6G   $��	10,36,0,0q�6b   $��1��6u   $	��Top=�6�   
�������6�   �� 5+   
   -   5        $ medLabel��5+      $��Медиана - ��6"   $��1��67   $
��Left=�6G   $��	10,67,0,0q�6b   $��1��6u   $	��Top=�6�   
�������6�   �� 5,   
   -   5        $ 	avSqLabel��5,      $$��Среднекв. откл. - ��6#   $��1��6@   $
��Left=�6P   $��	10,98,0,0q�6k   $��1��6~   $	��Top=�6�   
�������6�   �� 5-   
   -   5        $ 	dispLabel��5-      $��Дисперсия - ��6#   $��1��6:   $
��Left=�6J   $��
10,129,0,0q�6e   $��1��6y   $	��Top=�6�   
�������6�   �� 5.   
   -	   5         ��Name$ countButton��5.      $��Посчитать��6&   $��1��6:   $
��Left=�6J   $��1��6e   $	��Top=�6r   $��30��6�   $��72��6�   $��
15,160,0,0q�6�   ���	#FF272727���	#FFE0DDDD��5/      �� 50       �� 
TargetType" ��6   .�51      ��  � �� 52      �� 53       �� 
TargetType" ��6.   .R�54   "   �� #��z��6)   
�������$��1q�6g   ._�55   &   �� $��Center=�67   $��Center=�6T   56   #   57      59      5:      5<      �� 5=   
   $��1��6   $
��Left=�6    $��
10,195,0,0q�6;   $��1��6O   $	��Top=�6\   ���	#FF272727���	#FFE0DDDD$-��'Введите номер стобца:��6�   �� 5>   
   -
   5         ��Name$ colId��5>      $��1��6!   $
��Left=�61   $��
15,226,0,0q�6L   $��1��6`   $�� ��6m    �� TextWrapping$
 Wrap=�6u   $	��Top=�6�   $��92��6�   $��23��6�   ���	#FF272727���	#FFE0DDDD6�   �� 5?   
   -   5        $ 
gistButton��5?      $/��)Построить гистограмму��6>   $��1��6^   $
��Left=�6n   $��1��6�   $	��Top=�6�   $��30��6�   $	��141��6�   $��
15,254,0,0q�6�   ���	#FF272727���	#FFE0DDDD��5@      �� 5A      " ��6   .�5B      ��  � �� 5C      �� 5D      " ��6.   .R�5E   "   �� #��z��6)   
�������$��1q�6g   ._�5F   &   �� $��Center=�67   $��Center=�6T   5G   #   5H      5J      5K      5M      �� 5N   
   -   5        $	 xId��5N      $��1��6   $
��Left=�6/   $��
17,318,0,0q�6J   $��1��6^   $�� ��6k   $
 Wrap=�6s   $	��Top=�6�   $��92��6�   $��23��6�   ���	#FF272727���	#FFE0DDDD6�   �� 5O   
   -   5        $	 yId��5O      $��1��6   $
��Left=�6/   $��
17,346,0,0q�6J   $��1��6^   $�� ��6k   $
 Wrap=�6s   $	��Top=�6�   $��92��6�   $��23��6�   ���	#FF272727���	#FFE0DDDD6�   �� 5P   
   -   5        $ xLabel��5P      $
�� - X��6    $��1��6/   $
��Left=�6?   $��114,317,0,0q�6Z   $��1��6o   $	��Top=�6|   
�������$��30��6�   �� 5Q   
   -   5        $ yLabel��5Q      $
�� - Y��6    $��1��6/   $
��Left=�6?   $��114,343,0,0q�6Z   $��1��6o   $	��Top=�6|   
�������$��30��6�   5U      5V      