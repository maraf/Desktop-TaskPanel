   M S B A M L   `   `   `  ����F  BDesktopCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullH3clr-namespace:DesktopCore.Data;assembly=DesktopCoreDesktopCore.Data  5      P LDesktopCore.Resources, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullH8clr-namespace:DesktopCore;assembly=DesktopCore.ResourcesDesktopCore 5       TaskPanel.UI&    TaskPanel.UI.Controls.TaskDetail   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Bdd3clr-namespace:DesktopCore.Data;assembly=DesktopCore     5      Fc8clr-namespace:DesktopCore;assembly=DesktopCore.Resources     5      -   5          >�Name$
  root��5	       � 	Resources 5
      .   (DesktopCore.Data.DateTimeFormatConverter   dateTimeFormat 	 label �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker  textbox��%�  &	        &	      '�� �     '  p    &	       5   
   6%   �� 5   
   " ��6   .�5      ��  � ��$
 Bold"�6+   �� 5       � �� �#6C6C6C6+   �� 5       � �� �#F0F0F06+   �� 5       � ��$	 4,2q�6(   �� 5       � ��$ 0,4,0,0q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$ 3q�60   �� 5       � �� �#6C6C6C6,   5      �� 5   
   "  6   .�5      ��  � ��$ 3q�60   �� 5       � �� �#6C6C6C6,   �� 5       � ��$ 0q�6(   5      �� 5   
   " ��6    .�5      ��  � ��$	 4,2q�6(   �� 5       � ��$ 0,4,0,0q�6'   �� 5        � ��$ 3q�60   �� 5!       � �� �#6C6C6C6,   5"      5#      .��5$      � $��5q�6   
������� � RowDefinitions 5%   
   �� 5&      $
��Auto �6   �� 5'      $��2* �6   �� 5(      $
��Auto �6   �� 5)      �� 5*      $
��Auto �6   �� 5+      $
��Auto �6   .+�5.   
   � $��0��6    � ColumnDefinitions 5/      �� 50      $
��Auto �6#   �� 51      �� 52      $
��Auto �6#   �� 53      �� 54      $
��Auto �6#   �� 55      .+�58      �� #��[ 69   $��0��6�   ��6     DesktopCore.Resource  *Label.Created+y�6X   �� *	Task.ID+ �� ElementName$
 root��  notZeroToVisibility �� 	Converter# [ 6�   �� 59      #��[ 6r   $��0q�5:   o   $��1��6�   ��59      �� *Task.Created+$
 root��# [  y�5:      �� *	Task.ID+$
 root��# [ 6�   �� 5<      #��[ 6:   $��2��6�   ��6     *Label.Modified+y�6Y   �� *	Task.ID+$
 root��# [ 6�   �� 5=      #��[ 6s   $��0q�5>   o   $��3��6�   ��5=      �� *Task.Modified+$
 root��# [  y�5>      �� *	Task.ID+$
 root��# [ 6�   �� 5@      #��[ 6:   $��4��6Y   ��6     *Label.Deadline+6Y   �� 5A      	 �� Orientation$	 
Horizontal=�6   $��5��62   .+�5B      �� -   5        
 ��Name$
 cbxDeadline��5B      $��Center=�60   $	��2,0q�6�    d� 	IsChecked 6K   �� *Task.Deadline+$
 root�� �� Mode$ OneWay=�  
nullToBool# [ 6�     5C         SelectedDate 6   �� *Task.Deadline+$
 root��{�6V   �� *	IsChecked+$ cbxDeadline��5D      5E      ]� 5F   
   $��1��6   .+�5G      �� #��[ 6c   $	��Top=�6�   ��6     *Label.Content+ �� Target 69   �� $ 
tbxContent��6�   �� 5H      -   5         ��Name$ 
tbxContent��5H       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6o   ��6*   �� *Task.Content+$
 root��6o   5I      �� 5J   
   $��5��6   $��Center=�6"   $��Stretch=�6=   
������ $��2��6t   $��0��6�   ]� 5K   
   $��3��6   .+�5L      �� #��[ 6e   $	��Top=�6�   ��6     *Label.Solution+ 6:   �� $ tbxSolution��6�   �� 5M      -   5        $ tbxSolution��5M       . $
 Wrap=�6q   ��6+   �� *Task.Solution+$
 root��6q   5N      � 5O   
   $��0,5,0,0q�6   $��4��6     5P      �� 5Q      $	��100 �6#   �� 5R      �� 5S      $
��Auto �6#   �� 5T      $
��Auto �6#   .+�5V      ]� $��0,0,2,0q�6   .+�5W      �� #��[ 6g   $	��Top=�6�   ��6     *
Task.State+ 6:   �� $ coxTaskStates��6�   �� 5X      -   5         ��Name$ coxTaskStates��5X       �� SelectedItem 62   �� *
Task.State+$
 root����6h   �� *
TaskStates+$
 root����5Y      �� 5Z      .R�5[      �� $	 
Horizontal=�6)   $	��0,2q�6B   .+�5\   "   �� $��16��6A   ��6(   �� *Image+6A   �� 5]   "   $��0q�6A   $��5,0,0,0q�6M   ��6(   �� *Name+6M   5^      5_      5a      5b      ]� 5c      $��2,0,0,0q�6   $��1��6)   .+�5d      �� #��[ 6g   $	��Top=�6�   ��6     *
Task.Group+ 6:   �� $ coxTaskGroups��6�   �� 5e      -   5        $ coxTaskGroups��5e       62   �� *
Task.Group+$
 root����6h   �� *Groups+$
 root����5f      �� 5g      .R�5h      �� $	 
Horizontal=�6)   $	��0,2q�6B   .+�5i   "   �� $��16��6A   ��6(   �� *Image+6A   �� 5j   "   $��0q�6A   $��5,0,0,0q�6M   ��6(   �� *Name+6M   5k      5l      5n      5o      �� 5p      $��2,0,0,0q�6   $��2��6*   .+�5q      �� #��[ 6>   ��6     *Label.Priority+6>   �� 5r        priority#��[ 6K    � Value 6   �� *Task.Priority+$
 root��6K   5s      �� 5t      $	 
Horizontal=�6   $��Right=�62   $��4,4,0,4q�6N   $��3��6_   .+�5u      �� -   5         ��Name$ btnSaveTask��5u      $��60��6.   $��Right=�6v   ��69     *Button.Save+6v   �� 5v      -   5        $ btnCloseTask��5v      $��60��6/   $��Right=�6y   $��5,0,0,0q�6�   ��6:     *Button.Close+6�   5w      5x      5y      5z      