   M S B A M L   `   `   `  ����D  @5.Notepad, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:_5.Notepad
_5.Notepad  5   	       _5.Notepad.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:_5.Notepad     5   	   -   5        $	��450��5   U   $	��800��6b     � Title  6	   �� *FileNameWithAsterisk+ �� UpdateSourceTrigger$ PropertyChanged=� J� InputBindings 5	      �� 5
   
    �� 	Modifiers$
 Ctrlf�65   
 �� Key$ S��6F    �� Command 6   �� *SaveCommand+6F   �� 5   
   $
 Ctrlf�68   $ N��6I    6   �� *NewFileCommand+6I   �� 5   
   $
 Ctrlf�69   $ O��6J    6   �� *OpenFileCommand+6J   .��5      ]� -   5        .+�5   
   o� $	��Top=�6   $	��Top=�6'   .@�5      m� $��Файл��6   .@�5      m� -   5        $��Новый файл��5      6/   m� 5      -   5        $��Открыть файл��5      61   m� 5      -   5        $��Сохранить��5      6.   �� 5      m� 5      -   5        $��
Выход��5      6*   5      5      �� 5   
   $��Consolas)�6    �� AcceptsReturn$
 True��6�   $ �� HorizontalScrollBarVisibility$
 Auto=�6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   ��6(   �� *CurrentFontSize+$ PropertyChanged=���6r   �� *
MainText+$ PropertyChanged=�6�   5      5      