   M S B A M L   `   `   `  ����B  >4.Notes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:_4.Notes_4.Notes  5   	       _4.Notes.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:_4.Notes     5   	   -   5          � Title$  Notes��5   	   $	��500��6   $	��400��6$   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��0.1* �6   �� 5      $��* �6   �� 5      $
��0.1* �6    � RowDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      $��4* �6   �� 5      $��3* �6   �� 5      $
��0.1* �6   .+�5   
   �� -   5         ��Name$ 
NoteTextTB��5      $��1��5      $��1��6    �� AcceptsReturn$
 True��5       �� TextWrapping$
 Wrap=�5      " �� VerticalScrollBarVisibility$
 Auto=�5      $ �� HorizontalScrollBarVisibility$
 Auto=�5      � 5   
   $��2��6   $��1��6    5      �� 5      �� 5      .+�5       �� $��0��6   .+�5!      �� $
��Wrap=�6   $#��Путь сохранения��60   $��5q�6G   �� 5"      -   5         ��Name$ 
FilePathTB��5"      $��[пусто]��60   $��60��6?   $��
5, 5, 5, 0q�6K   $
��Wrap=�6_   �� 5#      -   5        $��30��5#      $��Выбрать путь��6%   $��
5, 5, 5, 0q�6<   6P   5$      �� 5%      $��1��6   .+�5&      �� $��Цвет панели:��6   $��10(�6/   �� 5'      -   5        	 ��Name$	 ColorCB��5'      $��Center=�5(      $��Center=�5)      $	��150��5*      $��30��6'   $��5q�5+      
 �� DisplayMemberPath$

 Name��5-      ��5'   ,   �� *BackgroundColors+5-      �� 5.      $&�� Семейство шрифта:��6   $��10(�64   �� 5/      -   5        $	 FontFamilyCB��5/      $��Center=�50      $��Center=�51      $	��150��52      $��30��6'   $��5q�53      ��5/   1   �� *FontFamiliesList+53   &   �� 54      $ ��Размер шрифта:��6   $��10(�61   �� 55      -   5        $ 
FontSizeTB��55      $��12��6.   $��Center=�56      $��Center=�57      $��40��58      $��20��6%   $��5q�59      5:      5;      5=      5>      5?      