   M S B A M L   `   `   `  ����L  HStorageClassifier, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:StorageClassifierStorageClassifier  5   	   "    StorageClassifier.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:StorageClassifier     5   	     � Title$  Storage manager��5	   	   $	��450��6!   $	��800��6.   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��5* �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      .+�5   
   c� $��2��6   .@�5      o� .@�5      m� $��Файл��6   ���	#FFEEF5FD.@�5      m� -   5         m�Name$ 
loadButton��5      $��Загрузить��63   6F   m� 5      -   5        $ 
saveButton��5      $��Сохранить��63   6F   m� 5      -   5        $ 	faqButton��5      $��О программе��62   6G   5      5      �� 5      �� 5      -   5         ��Name$ addNodeButton��5      $(��"Добавить под. узел:��6,   6J   �� 5      -   5        $ addGlobalNodeButton��5      $4��.Добавить глобальный узел��62   6U   �� 5      -   5         ��Name$ nodeName��5      $	��100��6(   .��64   ��5       O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5!   1   �� 6   6sys&clr-namespace:System;assembly=mscorlib     61    �� 
TargetType" ��6    �� 	Resources 5"         CueBannerBrush j� 
AlignmentX	 j� 
AlignmentY
 j� Stretch !� Visual��%�   &	        !� 5#      $
 Left=�6A   $	 Center=�6S   $

 None=�6g    5$   "   �� 5%   &   $��Название��6,   
�������6?   5'      5(       �� Triggers 5)      P� 5*       P� Property � �� �� Empty P� Value# Z 66   . �5+   "   ��  �� Property � �� �� Value# [  6?   5,      P� 5-       � �� 66   Z� . �5.   "   ��  � ��# [  6?   5/      P� 50       �@J�IsKeyboardFocused$
 True��6C   . �51   "   ��  � ��
 �����6?   52      54      .��55   !   56      �� 57      �� 58      -   5        $ addLineButton��58      $!��Добавить товар��6,   6E   �� 59      �� 5:      -   5        $ exportButton��5:      $��Экспорт CSV��6+   6A   �� 5;      -	   5        $ lowValue��5;      $	��100��6(   .��64   ��5<      1&clr-namespace:System;assembly=mscorlibSystem 5=   1   �� 6   6sys&clr-namespace:System;assembly=mscorlib     61   " ��6    5>      ��%�   &	        !� 5?      $
 Left=�6A   $	 Center=�6S   $

 None=�6g    5@   "   �� 5A   &   $$��Маленькое кол-во��6,   
�������6G   5C      5D       5E      P� 5F       � ��# Z 66   . �5G   "   ��  � ��# [  6?   5H      P� 5I       � �� 66   Z� . �5J   "   ��  � ��# [  6?   5K      P� 5L       �@J�IsKeyboardFocused$
 True��6C   . �5M   "   ��  � ��
 �����6?   5N      5P      .��5Q   !   5R      5T      R� 5U   
   -
   5         R�Name$ treeView��5U      $��1��6%    � ContextMenu 5V      �� 5W      .@�5X      m� -   5        $ 
deleteNode��5X   :   $'��!Удалить выбранный��6   6i   m� 5Y      -   5        $ editNode��5Y   ;   $)��#Изменить выбранный��6   6f   5Z      5\      &   System.Windows.Controls.DataGrid  5]   
   -   5          Name$ productsGrid��5]   0   $��1��6   $��1��6#      Columns 5^      0  *System.Windows.Controls.DataGridTextColumn  5_      ,  &System.Windows.Controls.DataGridColumn   Header$ Название��6%      
IsReadOnly$
 True��67   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   ��  �� Path$
 Name�  5`      $ Артикул��6%   $
 True��66    6H   �� $
 Code�  5a      $ Цена��6%   $
 True��63    6E   �� $ Price�  5b      $ Остаток��6%   $
 True��66    6H   �� $
 Left�  5c      $ Путь��6%   $
 True��63    6E   �� $
 Path� 5e      �� 5f      .@�5g      m� -   5        $ deleteProduct��5g   :   $'��!Удалить выбранный��6   6o   m� 5h      -   5        $ editProduct��5h   ;   $)��#Изменить выбранный��6   6l   5i      5k      5n      5o      