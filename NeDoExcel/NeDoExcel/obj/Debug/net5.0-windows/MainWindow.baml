   M S B A M L   `   `   `  ����D  @NeDoExcel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:NeDoExcel	NeDoExcel  5   	       NeDoExcel.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:NeDoExcel     5   	     � Title$  
MainWindow��5
   	   $	��450��6   $	��800��6)   ���	#FF272727.��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   6*   �� 5       � ColumnDefinitions 5   
   �� 5      $��8* �6   6,   �� 5      $��2* �6   6,   .+�5   
   c� ���	#FF272727���	#FF272727$��	0,0,-24,0q�6@    `� IsLocked$
 True��6S   $��2��6o   .@�5      o� ���	#FF272727.@�5      m� $��Файл��6   ���	#FF272727���	#FFE0DDDD$��0,0,0,0q�6W   $��25��6q   ��5      �� 5       �� Triggers 5      P� 5   "    P� Property �@J�IsMouseOver P� Value$
 true��6J   . �5   &   ��  �� Property � �� �� Value
 �����6L   �� 5   &    � �� �#2933406L   5   #   5      .@�5!      m� -   5        $��Открыть��5!      60   5#      5$      �� 5%      -   5        $��Button1��5%      ���	#FFE0DDDD6U   �� 5&      $��О программе��6   ���	#FFE0DDDD6D   5'      &   System.Windows.Controls.DataGrid  5(   
   -   5        	  Name$	 	tableGrid��5(      $��1��6&   
   SelectionMode$
 Extended=�6�      CanUserSortColumns$ False��6�      SelectionUnit$ CellOrRowHeader=�6�      
IsReadOnly$
 True��6�   ��63   �� 6�   �� 5)   
   $��Посчитать:��6   $��1��6%   $��Center=�65   $��0,5,0,0q�6R   $��1��6c   $	��Top=�6p   
�������6�   �� 5*   
   -   5         ��Name$ midLabel��5*      $��Среднее - ��6"   $��1��67   $
��Left=�6G   $��	10,36,0,0q�6b   $��1��6u   $	��Top=�6�   
�������6�   �� 5+   
   $��Медиана - ��6   $��1��6%   $
��Left=�65   $��	10,67,0,0q�6P   $��1��6c   $	��Top=�6p   
�������6�   �� 5,   
   $$��Среднекв. откл. - ��6   $��1��6-   $
��Left=�6=   $��	10,98,0,0q�6X   $��1��6k   $	��Top=�6x   
�������6�   �� 5-   
   $��Дисперсия - ��6   $��1��6'   $
��Left=�67   $��
10,129,0,0q�6R   $��1��6f   $	��Top=�6s   
�������6�   �� 5.   
   -   5         ��Name$ countButton��5.      $��Посчитать��6&   $��1��6:   $
��Left=�6J   $��1��6e   $	��Top=�6r   $��30��6�   $��72��6�   $��
15,160,0,0q�6�   ���	#FF272727���	#FFE0DDDD��5/      �� 50       �� 
TargetType" ��6   .�51      ��  � �� 52      �� 53       �� 
TargetType" ��6.   .R�54   "   �� #��z��6)   
�������$��1q�6g   ._�55   &   �� $��Center=�67   $��Center=�6T   56   #   57      59      5:      5<      �� 5=   
   $��1��6   $
��Left=�6    $��
15,195,0,0q�6;   $��1��6O   $	��Top=�6\   ���	#FF272727���	#FFE0DDDD$��92��6�   .��5>      �� ���	#FF272727���	#FFE0DDDD$"Обратите внимание,�� 5?      %#значения считаются�� 5@      только�� 5A      (&для выделенных ячеек60   6<   5E      5F      