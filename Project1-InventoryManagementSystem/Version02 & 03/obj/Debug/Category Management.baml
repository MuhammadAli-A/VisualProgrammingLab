   M S B A M L   `   `   `  ����?  ;VP 2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VP_2VP_2  5   	       VP_2.Category_Management   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:VP_2     5   	     � Title$  Category Management��5   	   $	��500��6%   $	��800��62    � 	Resources 5	         PrimaryColor �� Color  SecondaryColor  AccentColor  ButtonStyle �� 
TargetType �� Property �� Value��%S  &	        &	 !     &	 B     &	 c     7   �� 5   
   $ #36454F��6/   �� 5   
   $ #8B5E3C��61   �� 5   
   $ #DCDCDC��6.   �� 5   
   " ��6$   .�5      ��  � ��8   6+   �� 5       � ��
 �����6+   �� 5       � ��$	 120��6&   �� 5       � ��$ 40��6'   �� 5       � ��$ 10q�6'   �� 5       � ��$
 Bold"�6+   �� 5       � ��
 ���� 6,   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��$ 14(�6)   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   5       5!      .��5#      � #��[ 6   .+�5%   
   �� $��Category Management��6   $��32(�6/   $
��Bold"�6=   #��[  6O   $��Center=�5&      $	��Top=�61   $��0,10,0,0q�6I   &   System.Windows.Controls.DataGrid  5)   
   -   5          Name$ categoryDataGrid��5)         AutoGenerateColumns . $��Stretch=�5*      $��Stretch=�61   $��20,60,20,120q�5+         
IsReadOnly . 	   SelectionMode$	 Single=�6;   6R   �� 5.   
   
 �� Orientation$
 
Horizontal=�6   $��Center=�6.   $��Bottom=�6K   $��0,0,0,20q�6f   .+�50      �� -   5         ��Name$ AddCategoryButton��50      $	��Add��60   #��[ 6>   6c   �� 53      -   5        $ UpdateCategoryButton��53      $��Update��63   #��[ 6D   6i   �� 56      -   5        $ DeleteCategoryButton��56      $��Delete��63   #��[ 6D   6i   �� 59      $
 
Horizontal=�6   $��Center=�62   .+�5:      �� -   5        $ SearchButton��5:      $��Search��6/   #��[ 6@   $	��120��6e   6q   5;      5<      5=      5>      