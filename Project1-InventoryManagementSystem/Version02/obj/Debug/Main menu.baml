   M S B A M L   `   `   `  ����?  ;VP 2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VP_2VP_2  5   	       VP_2.Main_menu   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:VP_2     5   	     � Title$  	Main Menu��5   	   $	��450��6   $	��800��6(    � WindowStartupLocation$ CenterScreen=�5	   	    � 	Resources 5         PrimaryColor �� Color  SecondaryColor  AccentColor  ButtonStyle �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   Color   
BlurRadius	   	Direction
   ShadowDepth �� 
TargetType �� CornerRadius �� Padding��%6  &	        &	 !     &	 B     &	 c     7   '� �    7  �� 5   
   $ #6F4F1F��6/   �� 5   
   $ #8B5E3C��61   �� 5   
   $ #D2B48C��6.   �� 5   
   " ��6$   .�5      ��  � ��8   6+   �� 5       � ��
 �����6+   �� 5       � ��$	 250��6&   �� 5       � ��$ 60��6'   �� 5       � ��$ 10q�6'   �� 5       � ��$
 Bold"�6+   �� 5       � ��
 ���� 6,   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��$ 16(�6)   �� 5       � ��$ Center=�6;   �� 5        � ��$ Center=�69   �� 5!       � ��$
 10,5q�6(   �� 5"       �@J�Effect 5#        5$      $ Black��6'   $ 10Q�65   $		 270Q�6E   $
 3Q�6U   5&      �� 5(       � �� 5)      �� 5*      " ��6&   .R�5+      �� #��z��6!   #��z��5,   !   $��1q�5-   !   $ 15��5.   !   # z��5/      ._�50      �� $��Center=�6/   $��Center=�51   /   52      53      55      56      �� 59   
   " �6   .�5:      ��  � ��8   6+   5;      5=      .��5?      �  � RowDefinitions 5A   
   �� 5B      $
��Auto �6   �� 5C      $��* �6   .+�5G   
   �� #��[  6   $ 20q�6<   $��Stretch=�6I   ._�5H      �� $��	Dashboard��6   
�������$��36(�6<   $
��Bold"�6J   $��Center=�6\   $��Center=�6y   5I      � 5L   
   $��1��6    J� Effect 5M        5N      .+�5Q      ��  �� Orientation$ Vertical=�6   $��Center=�60   $��Center=�6M   .+�5R      �� -   5         ��Name$ ShowProductsButton��5R      $��Show Products��65   #��[ 6M   6r   �� 5S      -   5        $ ShowUsersButton��5S      $��
Show Users��62   #��[ 6G   6l   �� 5T      -   5        $ 
ExitButton��5T      $
��Exit��6-   #��[ 6<   6a   5U      5V      5W      5X      