   M S B A M L   `   `   `  ���� C  ?EBookDat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:EBookDatEBookDat  (    "EBookDat.EditionManagerWindowCzech   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     (localclr-namespace:EBookDat       � Title$  EditionManagerWindowCzech��$	��400��$	��750��.��� $��0,0,0,10q� � RowDefinitions �� $��30 ��� $��* ��� $	��140 � � ColumnDefinitions �� $��5* ��� $��3* ��� $��2* ��� $��10 ��� $��6* �.+��� $��0��$��0��$��3�� �� Orientation$ 
Horizontal=�$
��Left=�$��Bottom=�$��10,0,0,5q�.+��� $��Seznam edic��$��14(�$��Verdana)�$
��Bold"� �� TextAlignment$ Center=��� $��Počet edic��$��10(�$��Verdana)�$ Center=�$��Bottom=�$��10,0,0,1q��� $��10(�$��Verdana)�$ Center=�$��Bottom=�$��5,0,0,1q����� *EditionsCount+�� $��0��$��1��$��2��$ Vertical=�$��Bottom=�$��0,0,0,5q�.+��� $��Hledat��$��Verdana)�$��8(��� -   $��searchTextBox��$��Verdana)��� $��0��$��4��$��1��$ 
Horizontal=�$
��Left=�$��Bottom=�$��0,0,0,5q�.+��� $��Podrobnosti o edici��$��Verdana)�$��14(�$
��Bold"��� -   $��editionListBox��$��1��$��0��$��3��$��2��$��Verdana)�$��10,0,0,0q����� *SourceCollection+ �� View �� .P���  �� DisplayMemberBinding �� *	CzechName+.���� -   $��Název���� $��1��$��4�� �� CornerRadius$ 14��
�������
�������$��1q� �� Padding$ 8q�$��0,0,10,0q�._��� $��1��$��4��$��10,0,0,0q�{�.  	 � DataContext	 �� 
 �� ElementName$
 editionListBox�� �� Path$ SelectedItem�.+��� $ Vertical=�.+��� $��Český název:��$��Verdana)��� $��Verdana)�$
��Bold"�$
��Wrap=�$��10,2,0,0q����� *	CzechName+�� $ Vertical=�$��0,16,0,0q�.+��� $��Anglický název:��$��Verdana)��� $��Verdana)�$
��Bold"�$
��Wrap=�$��10,2,0,0q����� *EnglishName+�� $��1��$��4��$ 
Horizontal=�$��Center=�$��Bottom=�$��30��$��0,0,0,10q�.+��� -   $��	Odstranit��$��Verdana)�$��70��$��30��$��	20,0,10,0q��� -   $��Upravit��$��Verdana)�$��70��$��30��$��	10,0,10,0q��� -   $��upDownStackPanel��$ Vertical=�$��20��$��5,0,0,0q�.+��� -   $��15��
������ 
������ .���� .+��� $=��7/Assets/Icons/baseline_keyboard_arrow_up_black_18dp.png��$��15���� -   $��15��
������ 
������ .���� .+��� $?��9/Assets/Icons/baseline_keyboard_arrow_down_black_18dp.png��$��15���� $��2��$��4��$ Vertical=�$	��Top=�$��0,5,10,0q�.+��� $��Český název:��$��Verdana)�$
��Bold"�$��0,10,0,0q��� -	   $��czechNameTextBox��$��Verdana)�$��0,4,0,0q��� $��Anglický název:��$��Verdana)�$
��Bold"�$��0,8,0,0q��� -
   $��englishNameTextBox��$��Verdana)�$��0,4,0,0q��� $��2��$��4��$ 
Horizontal=�$��Center=�$��Bottom=�$��30��$��0,0,0,0q�.+��� -   $��Pridat��$��Verdana)�$��70��$��30��$��0,0,0,0q�