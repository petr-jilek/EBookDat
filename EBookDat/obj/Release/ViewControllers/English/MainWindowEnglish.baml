   M S B A M L   `   `   `  ���� C  ?EBookDat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:EBookDatEBookDat       EBookDat.MainWindowEnglish   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     (localclr-namespace:EBookDat       � Title$  MainWindowEnglish��$	��540��$	��950��.��� $��0,0,0,10q� � RowDefinitions �� $��18 ��� $��36 ��� $��* � � ColumnDefinitions �� $��5* ��� $��3* ��� $��2* ��� $��10 ��� $��6* �.+�]� $��0��$��0��$��5��.+�o� $	��Top=�$��Verdana)�.@�m� $
��File��.@�m� $	��New�� m� Icon �� $=��7/Assets/Icons/baseline_create_new_folder_black_18dp.png��m� $
��Open�� �� $7��1/Assets/Icons/baseline_folder_open_black_18dp.png��m� $
��Save�� �� $0��*/Assets/Icons/baseline_save_black_18dp.png��m� $��Save as�� �� $0��*/Assets/Icons/baseline_save_black_18dp.png��m� $
��Join�� �� $6��0/Assets/Icons/baseline_attachment_black_18dp.png��m� $
��Data��.@�m� -   $��Export excel (.csv)�� �� $8��2/Assets/Icons/baseline_cloud_upload_black_18dp.png��m� -   $��Import excel (.csv)�� �� $:��4/Assets/Icons/baseline_cloud_download_black_18dp.png��m� -   $��Import new excel (.csv)�� �� $:��4/Assets/Icons/baseline_cloud_download_black_18dp.png��m� $��Editions��.@�m� -   $��Edition manager�� �� $5��//Assets/Icons/baseline_dashboard_black_18dp.png��m� $��Genres��.@�m� -   $��Genre manager�� �� $5��//Assets/Icons/baseline_dashboard_black_18dp.png��m� $��Settings��.@�m� $��Language�� �� $4��./Assets/Icons/baseline_language_black_18dp.png��.@�m� -   $��Czech�� �� $��/Assets/Images/CZflag.png��m� $��English�� �� $��/Assets/Images/GBflag.png���� $��1��$��0��$��3�� �� Orientation$ 
Horizontal=�$
��Left=�$��Bottom=�$��10,0,0,5q�.+��� $��
Books list��$��14(�$��Verdana)�$
��Bold"� �� TextAlignment$ Center=��� $��Books count��$��10(�$��Verdana)�$ Center=�$��Bottom=�$��10,0,0,1q��� $��10(�$��Verdana)�$ Center=�$��Bottom=�$��5,0,0,1q����� *
BooksCount+�� $��1��$��1��$ Vertical=�$��Bottom=�$��0,0,0,5q�.+��� $��Search��$��Verdana)�$��8(��� -   $��searchTextBox��$��Verdana)��� $��1��$��2��$ Vertical=�$��Bottom=�$��5,0,0,5q�.+��� $��By��$��Verdana)�$��8(��� -   $��searchComboBox��$��Verdana)�$��10(�$��18��.@���  �� 
IsSelected . $��Title���� $��Author���� $��Edition���� $��Genre���� $��Publish year���� $��Publish location���� $��	Publisher���� $
��ISBN���� $��Pages number���� $
��Note���� $��1��$��4��$��1��$ 
Horizontal=�$
��Left=�$��Bottom=�$��0,0,0,5q�.+��� $��Book details��$��Verdana)�$��14(�$
��Bold"��� -	   $��booksListBox��$��2��$��0��$��3��$��Verdana)�$��10,0,0,0q����� *SourceCollection+ �� View �� .P���  �� DisplayMemberBinding �� *Title+.���� -
   $��Title����  �� *Author+.���� -   $��Author����  �� *EnglishEdition+.���� -   $��Edition����  �� *EnglishGenre+.���� -   $��Genre����  �� *Note+.���� -   $
��Note���� $��2��$��4��	 �� CornerRadius$	 14��
�������
�������$��1q�
 �� Padding$
 8q�$��0,0,10,0q�._��� $��1��$��4��$��10,0,0,0q�{�.   � DataContext ��  �� ElementName$ booksListBox�� �� Path$ SelectedItem�.+��� $ Vertical=�.+��� $��Title:��$��Verdana)��� $��Verdana)�$
��Bold"�$
��Wrap=�$��10,2,0,0q����� *Title+�� $ Vertical=�$��0,7,0,0q�.+��� $��Author:��$��Verdana)��� $��Verdana)�$
��Bold"�$
��Wrap=�$��10,2,0,0q����� *Author+�� $ Vertical=�$��0,7,0,0q�.+��� $��Edition:��$��Verdana)��� $��Verdana)�$
��Bold"�$
��Wrap=�$��10,2,0,0q����� *EnglishEdition+�� $ Vertical=�$��0,7,0,0q�.+��� $��Genre:��$��Verdana)��� $��Verdana)�$
��Bold"�$
��Wrap=�$��10,2,0,0q����� *EnglishGenre+�� $ Vertical=�$��0,7,0,0q�.+��� $��Publish year:��$��Verdana)��� $��Verdana)�$
��Wrap=�$��10,2,0,0q����� *PublishYear+�� $ Vertical=�$��0,7,0,0q�.+��� $��Publish location:��$��Verdana)��� $��Verdana)�$
��Wrap=�$��10,2,0,0q����� *PublishLocation+�� $ Vertical=�$��0,7,0,0q�.+��� $��
Publisher:��$��Verdana)��� $��Verdana)�$
��Wrap=�$��10,2,0,0q����� *	Publisher+�� $ Vertical=�$��0,7,0,0q�.+��� $��ISBN:��$��Verdana)��� $��Verdana)�$
��Wrap=�$��10,2,0,0q����� *Isbn+�� $ Vertical=�$��0,7,0,0q�.+��� $��Pages number:��$��Verdana)��� $��Verdana)�$
��Wrap=�$��10,2,0,0q����� *PagesNumber+�� $ Vertical=�$��0,7,0,0q�.+��� $��Note:��$��Verdana)��� $��Verdana)�$
��Wrap=�$��10,2,0,0q����� *Note+�� $��2��$��4��$ 
Horizontal=�$��Center=�$��Bottom=�$��30��$��0,0,0,10q�.+��� -   $��Delete��$��Verdana)�$��70��$��30��$��0,0,10,0q��� -   $
��Edit��$��Verdana)�$��70��$��30��$��	10,0,10,0q��� -   $	��Add��$��Verdana)�$��70��$��30��$��10,0,0,0q�