   M S B A M L   `   `   `  ����   VP 2    VP_2.SupplierWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Supplier Management��$	��500��$	��800�� � 	Resources    	DarkBrown �� Color  MediumBrown  
LightBrown  
LightBeige  ButtonBackground  ButtonForeground��%�   &	        &	      &	 &     &	 9     &	 L     &	 _     �� $ #3E2A47���� $ #8B5C42���� $ #F4F6F6���� $ #808080���� $ #36454F���� $ #FFF5EE��.��� $��10q�#��[  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��Supplier Management��$��20(�$
��Bold"�$��10q�$��0��#��[  &   System.Windows.Controls.DataGrid  -     Name$ SuppliersDataGrid��   AutoGenerateColumns .  $��1��$��10q�#��[ #��[    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Supplier ID��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 	   
IsReadOnly	 . 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *
SupplierId+  $ Supplier Name��$	 200 
 �� *SupplierName+  $ Contact��$	 200 
 �� *	Contact+�� $��2�� �� Orientation$ 
Horizontal=�$��Right=�$��10q�.+��� -   $��Add Supplier��$	��120��$��5q�#��[ #��[ �� -   $��Edit Supplier��$	��120��$��5q�#��[ #��[ �� -   $��Delete Supplier��$	��120��$��5q�#��[ #��[ 