   M S B A M L   `   `   `  ����H  D6.AudioPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:_6.AudioPlayer_6.AudioPlayer  5   	       _6.AudioPlayer.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:_6.AudioPlayer     5   	     � Title$  AudioPlayer��5   	   $	��300��6   $	��400��6*    � 
ResizeMode$ NoResize=�66   .��5	      �� $��10q�6   .+�5
   
   �� -   5        $��	songTitle��5
      $'��!Ничего не играет...��6!   $��Center=�6?   $��2q�6c   �� 5   
   -   5        $��
textStatus��5      $�� ��6"   $��Center=�6-   $��2q�6Q   �� 5   
   -   5        $��Slider��5      $	��300��6    � Minimum$ 0Q�6p    � Value 6N   �� *CurrentPosition+ � Maximum 6|   �� *CurrentMaximumPosition+� 5   
   $��Center=�6   .+�5      �� -   5        $��addToListButton��5   !   $	��➕��6   
������ $��0q�6Q   $��10(�6e   6s   �� 5      -   5        $��playPauseButton��5   "   $��⏯️��6   
������ $��0q�6R   $��20(�6f   6t   �� 5      -   5        $��
skipButton��5   "   $��⏭️��6   
������ $��0q�6M   $��20(�6a   6o   5      �� 5   
   -   5        $��
PlaylistLB��5      $��10q�6$   $��80��6Q   ��60   �� *
Playlist+��5      �� 5       �� DataType$ Track��6   .R�5      �� -   5         �� Orientation$ 
Horizontal=�5   !   .+�5      �� ��6$   �� *	TrackName+�� 5      �� 5      -	   5        $��▶️��5   !   
������ $��0q�6b   �� 5      -
   5        $	��❌��5   !   
������ $��0q�6c   5      5      5      � 5   
   $��Center=�6   .+�5      �� -   5        $)��#Сохранить плейлист��5      62   �� 5       �� 5!      -   5        $%��Открыть плейлист��5!      60   5"      5#      5$      