   M S B A M L   `   `   `  ����?  ;VP 2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VP_2VP_2  5   	       VP_2.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:VP_2     5   	     � Title$  Login��5   	   $	��350��6   $	��400��6$   ���	#FF3E2723 � WindowStartupLocation$ CenterScreen=�5	        � WindowStyle$
 None=�6E    � AllowsTransparency .  � 	Resources 5
      3  -System.Windows.Media.Effects.DropShadowEffect   ShadowEffect   ShadowDepth   
BlurRadius   Color  WoodBackground �� 
StartPoint	 �� EndPoint
 � Color � Offset  WoodButtonBackground �� Color  WoodTextColor��%@  &	        &	 >     &	 �     &	 �       5   
   $ 5Q�60   $ 10Q�6@   $ 	#FF000000��6P   �� 5   
   $	 0,0&�65   $		 1,1&�6F   .��5      � $
 #D99170��6   $	 0.0Q�6+   � 5      $
 #8F5B3B��6   $	 1.0Q�6+   5      �� 5   
   $ #C6784A��67   �� 5   
   $ #F0E0C9��60   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� #��[ 6    �� CornerRadius$ 10��6>    �� Padding$ 20q�6P   $��20q�6]    J� Effect# [  6i   $��0��6�   ._�5      �� $��Center=�6   $��Center=�66   .+�5!      �� $��Login��6   $��24(�6)   #��[ 67   $��Center=�6c   $
��Bold"�5"      $��	0,10,0,20q�6.   �� 5%      $��0,5,0,5q�6   .+�5&      �� $��Username��6    ���#E8D0A9$��14(�6E   �� 5'      -   5         ��Name$ usernameTextBox��5'      $	��250��67   $��35��6C   $��14(�6O   ���#6A3E29���	#FFF4F4F9���#A5734D$��5q�5)      $��1q�6*   5*      �� 5-      $��0,5,0,5q�6   .+�5.      �� $��Password��6    ���#E8D0A9$��14(�6E   G� 5/      -   5         G�Name$ passwordBox��5/   "   $	��250��67   $��35��6C   $��14(�6O   ���#6A3E29���	#FFF4F4F9���#A5734D$��5q�51   "   $��1q�6.   52      53      54      �� 57   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��	0,10,0,20q�6K   $��1��6^   .+�59      �� -   5        $��Login��59      $	��120��6%   $��40��61   $��16(�6=   $
��Bold"�6K   #��[ 5:      
�������$��0q�6[   $��0,0,10,0q�5;      $��Center=�6A   �� 5>      -   5        $��Close��5>      $	��120��6%   $��40��61   $��16(�6=   $
��Bold"�6K   #��[ 5?      
�������$��0q�6[   $��Center=�5@   /   5A      5B      5C      