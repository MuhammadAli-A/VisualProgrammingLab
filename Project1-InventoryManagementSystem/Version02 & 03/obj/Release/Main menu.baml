   M S B A M L   `   `   `  ����   VP 2    VP_2.Main_menu   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  	Main Menu��$	��600��$	��800�� � WindowStartupLocation$ CenterScreen=����#1B1F23 � WindowStyle$
 None=� � AllowsTransparency .  � 	Resources    PrimaryColor �� Color  SecondaryColor  AccentColor  
HoverColor  	TextColor  ShadowColor3  -System.Windows.Media.Effects.DropShadowEffect  ButtonGlowShadow   Color   
BlurRadius   ShadowDepth	   	Direction  CardButtonStyle
 �� 
TargetType �� Property �� Value �� 
TargetType �� Padding �� CornerRadius �� 
BottomLeft �� BottomRight �� TopLeft �� TopRight �� Triggers P� Property P� Value �� ScaleX �� ScaleY  TitleTextStyle��%�  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     7  7  7  7  &	 =    7  �� $ #22272E���� $ #3A3F48���� $ #00FFB3���� $ #1DB954���� $ #FFFFFF���� $ #00FF00��  $ #00FFB3��$ 30Q�$ 15Q�$		 315Q��� "
 ��.���  � ��8   ��  � ��8  ��  � ��$	 200����  � ��$	 100����  � ��$ 15q���  � ��$
 Bold"���  � ��$ 22(���  � ��$ Segoe UI)���  � ��$ Center=���  � ��$ Center=���  �@�Cursor$
 Hand����  � ��
 ���� ��  � ��$ 2q���  �@J�Effect8  ��  � ��$ 20q���  � �� �� " ��.R��� #��z��#��z��#��z��# z�� �� $ 25Q�$ 25Q�$ 25Q�$ 25Q�._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ���  � ��8  ��  �@J�Effect   $ #1DB954��$ 25Q�$ 15Q���  � z� �� $	 1.1Q�$	 1.1Q��� "
 ��.���  � ��8   ��  � ��$ 50(���  � ��$
 Bold"���  � ��$ Poppins, Segoe UI)���  � ��$ Center=���  � ��$ Center=���  �@J�Effect   $ #00BFFF��$ 30Q�$ 15Q�.��� ����  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,1&�.���  � Color$ #22272E�� � Offset$	 0.0Q�� $ #3A3F48��$	 0.5Q�� $ #00FFB3��$	 1.0Q� � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� #��[  $ 20q�$��Stretch=�._��� $��Dashboard Overview��#��[ � $��1��.+�� $��20q� �� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $��* ��� $��* ��� $��* �.+��� -   $��View Inventory��#��[ $��0��$��0��$��20,15,20,15q��� -   $��Manage Users��#��[ $��0��$��1���� -   $��
Categories��#��[ $��0��$��2���� -   $��Order History��#��[ $��1��$��0���� -   $��Supplier Info��#��[ $��1��$��1���� -   $��Purchase Logs��#��[ $��1��$��2��� $��2��$��10q�.+��� -   $
��Exit��#��[ $	��200��$��Center=�