   M S B A M L   `   `   `  ����?  ;VP 2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VP_2VP_2  5   	       VP_2.Window2   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:VP_2     5   	     � Title$  User Management��5   	   $	��450��6!   $	��800��6.    � 	Resources 5
         PrimaryColor �� Color  SecondaryColor  AccentColor  	TextColor  BackgroundColor  ButtonStyle �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   Color   
BlurRadius   	Direction	   ShadowDepth
 �� 
TargetType �� Padding �� Triggers P� Property P� Value  DataGridStyle&   System.Windows.Controls.DataGrid��%�  &	        &	 !     &	 B     &	 c     &	 �     &	 �     7   &	 �    7  7  �� 5   
   $ #36454F��6/   �� 5   
   $ #8B5E3C��61   �� 5   
   $ #808080��6.   �� 5   
   $ #2C3E50��6,   �� 5   
   $ #F4F6F6��62   �� 5   
   " ��6$   .�5      ��  � ��8   6+   �� 5       � ��
 �����6+   �� 5       � ��$	 150��6&   �� 5       � ��$ 50��6'   �� 5       � ��$ 10q�6'   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 16(�6)   �� 5       � ��
 ���� 6,   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � ��$
 12,5q�6(   �� 5        �@J�Effect 5!        5"      $ Black��6'   $ 10Q�65   $	 270Q�6E   $	 5Q�6U   5$      �� 5%       � �� 5&      �� 5'      "
 ��6&   .R�5(      �� #��z��6!   #��z��5)   !   $��1q�5*   !   # z��5+   !   ._�5,      �� $��Center=�6/   $��Center=�5-   /   5.      5/      51       52      P� 53       �@J�IsMouseOver . . �54      ��  � �� �#2980B963   �� 55       �@J�Effect 56        57      $ Black��6/   $ 15Q�6=   $	 270Q�6M   $	 10Q�6]   59      5:      P� 5;       � �� . . �5<      ��  � �� �#1ABC9C63   �� 5=       �@J�Effect 5>        5?      $ Black��6/   $ 8Q�6=   $	 270Q�6L   $	 3Q�6\   5A      5B      5D      �� 5G   
   "  6&   .�5H      ��  � ��8   6+   �� 5I       � ��
 �   �6+   �� 5J        �@ AlternatingRowBackground8  69   �� 5K       � ��
 �   �6,   5L      5M      .��5O      � #��[ 6   .+�5Q   
   �� $��User Management��6   $��30(�6+   $
��Bold"�69   $��10q�6K   $��Center=�6W   $	��Top=�6t   �� 5T   
    �� Orientation$ 
Horizontal=�6   $
��Left=�6.   $	��Top=�6I   $��10,40,10,10q�6a   .+�5U      �� -   5         ��Name$ AddUserButton��5U      $��Add User��6,   #��[ 6?   6d   �� 5V      -   5        $ DeleteUserButton��5V      $��Delete User��6/   #��[ 6E   6j   �� 5W      -   5        $ UpdateUserButton��5W      $��Update User��6/   #��[ 6E   6j   �� 5X      -   5        $ SearchUserButton��5X      $��Search��6/   #��[ 6@   6e   5Y        5\   
   -   5          Name$ userDataGrid��5\         AutoGenerateColumns . $��Stretch=�5]      $��Stretch=�61   $��10,100,10,10q�5^      #��[ 6)   5_      5`      