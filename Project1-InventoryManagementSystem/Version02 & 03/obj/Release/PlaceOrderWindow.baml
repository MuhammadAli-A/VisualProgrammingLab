   M S B A M L   `   `   `  ����   VP 2    VP_2.PlaceOrderWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Place Order��$	��600��$	��800�� � WindowStartupLocation$ CenterScreen=� � 	Resources    PrimaryColor �� Color  SecondaryColor  AccentColor  	TextColor  BackgroundColor  ButtonStyle �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   Color   
BlurRadius	   	Direction
   ShadowDepth �� 
TargetType �� Padding �� Triggers P� Property P� Value��%U  &	        &	      &	 &     &	 9     &	 L     &	 _     7   7  '� �    7  �� $ #BDC3C7���� $ #ECF0F1���� $ #95A5A6���� $ #2C3E50���� $ #F4F6F6���� " ��.���  � ��8   ��  � ��8  ��  � ��$	 150����  � ��$ 50����  � ��$ 10q���  � ��$
 Bold"���  � ��$ 16(���  � ��
 ���� ��  �@�Cursor$
 Hand����  � ��$ Center=���  � ��$ Center=���  � ��$
 12,5q���  �@J�Effect   $ Black��$ 5Q�$		 270Q�$
 3Q���  � �� �� " ��.R��� #��z��#��z��$��1q�# z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ���  � �� �#95A5A6P�  � �� . . ���  � �� �#7F8C8D�� " �.���  � ��8   ��  �@J�Effect   $ Black��$ 15Q�$		 270Q�$
 15Q�.���  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� #��[  $ 20q�$��Stretch=�._��� $��Place Your Order��
�������$��36(�$
��Bold"�$��Center=�$��Center=�� $��1��$��20q� � ColumnDefinitions �� $
��199* ��� $
��181* �.+��� $��0��$��10,10,10,10q�.+��� $��Electronics��$��20(�$
��Bold"�$��0,0,0,10q�#��[ �� -   $��ElectronicsListView��#��[ $	��200�� �� View �� .P��� $��
Product ID�� �� Width$ 80�� �� DisplayMemberBinding �� *	ProductId+�� $��Product Name��$	 150�� �� *ProductName+�� $��Quantity��$ 60�� �� *
Quantity+�� $��Price��$ 80�� �� *Price+�� $��1��$��10,10,10,10q�.+��� $��	Furniture��$��20(�$
��Bold"�$��0,0,0,10q�#��[ �� -   $��FurnitureListView��#��[ $	��200�� �� .P��� $��
Product ID��$ 80�� �� *	ProductId+�� $��Product Name��$	 150�� �� *ProductName+�� $��Quantity��$ 60�� �� *
Quantity+�� $��Price��$ 80�� �� *Price+�� $��2��$��20q�.+���  �� Orientation$ 
Horizontal=�$	��0,5q�$
��Left=�.+��� $��Address:��$	��100��$��Center=�#��[ �� -   $��AddressTextBox��$	��200���� $ 
Horizontal=�$	��0,5q�$
��Left=�.+��� $��Email:��$	��100��$��Center=�#��[ �� -   $��EmailTextBox��$	��200���� $ 
Horizontal=�$��Right=�$��0,20,0,0q�.+��� -    ��Name$ SubmitOrderButton��$��Submit Order��#��[ $	��150���� -   $ CancelOrderButton��$��Cancel Order��#��[ $	��150��$��10,0,0,0q��� -   $ 
ExitButton��$
��Exit��#��[ $	��150��$��10,0,0,0q�