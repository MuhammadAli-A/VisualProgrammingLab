   M S B A M L   `   `   `  ����?  ;VP 2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VP_2VP_2  5   	       VP_2.Orders_Management   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:VP_2     5   	     � Title$  Orders Management��5   	   $	��450��6#   $	��800��60    � 	Resources 5
         PrimaryColor �� Color  SecondaryColor  AccentColor  ButtonStyle �� 
TargetType �� Property �� Value  DataGridStyle&   System.Windows.Controls.DataGrid��%S  &	        &	 !     &	 B     &	 c     7   &	 L    7  7  �� 5   
   $ #36454F��6/   �� 5   
   $ #8B5E3C��61   �� 5   
   $ #F4F6F6��6.   �� 5   
   " ��6$   .�5      ��  � ��8   6+   �� 5       � ��
 �����6+   �� 5       � ��$	 120��6&   �� 5       � ��$ 40��6'   �� 5       � ��$ 5q�6'   �� 5       � ��$
 Bold"�6+   �� 5       � ��
 ���� 6,   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��$ 14(�6)   �� 5       � ��$
 10,5q�6(   �� 5       � ��$ Center=�6;   �� 5        � ��$ Center=�69   5!      �� 5$   
   "  6&   .�5%      ��  � ��8   6+   �� 5&       � ��
 �   �6+   �� 5'        �@ AlternatingRowBackground8  69   �� 5(       � ��
 �   �6,   5)      5*      .��5,      � #��[ 6   .+�5.   
   ��  �� Orientation$ 
Horizontal=�6   $
��Left=�6.   $	��Top=�6I   $��10q�6a   .+�50      �� -   5         ��Name$ DeleteOrderButton��50      $��Delete Order��60   #��[ 6G   6l   �� 51      -   5        $ UpdateOrderButton��51      $��Update Order��60   #��[ 6G   6l   �� 52      -   5        $ SearchOrderButton��52      $��Search��60   #��[ 6A   6f   53        56   
   -   5          Name$ orderDataGrid��56      	   AutoGenerateColumns	 . $��Stretch=�57      $��Stretch=�61   $��10,60,10,10q�58      #��[ 6(   59      5:      