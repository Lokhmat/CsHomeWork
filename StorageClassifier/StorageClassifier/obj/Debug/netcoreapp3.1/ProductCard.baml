   M S B A M L   `   `   `  ����L  HStorageClassifier, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:StorageClassifierStorageClassifier  5   	   #    StorageClassifier.ProductCard   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:StorageClassifier     5   	     � Title$  ProductCard��5   	   $	��450��6   $	��800��6*   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��Название��6   $��0��6#   $	��100��60   $��Center=�6<   �� 5   
   -   5         ��Name$
 Name��5      $	��200��6    $��Right=�6,   $��0��6H   $��30��6U   $��Center=�6a   $��0,0,10,0q�6|   �� 5   
   $��Артикул��6   $��1��6"   $	��100��6/   $��Center=�6;   �� 5   
   -   5        $
 Code��5      $	��200��6    $��Right=�6,   $��1��6H   $��30��6U   $��Center=�6a   $��0,0,10,0q�6|   �� 5   
   $��Цена��6   $��2��6   $	��100��6,   $��Center=�68   �� 5   
   -   5        $ Price��5      $	��200��6!   $��Right=�6-   $��2��6I   $��30��6V   $��Center=�6b   $��0,0,10,0q�6}   �� 5   
   $��Остаток��6   $��3��6"   $	��100��6/   $��Center=�6;   �� 5   
   -   5        $
 Left��5      $	��200��6    $��Right=�6,   $��3��6H   $��30��6U   $��Center=�6a   $��0,0,10,0q�6|   �� 5   
   -   5         ��Name$ 
saveButton��5   #   ${�False��6   $��4��68   $��Сохранить��6E   $��80��6Y   $��30��6d   $��Right=�6p   $��0,0,10,0q�6�   6�   5      5      