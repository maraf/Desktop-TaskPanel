   M S B A M L   `   `   `  ���� F  BDesktopCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullH3clr-namespace:DesktopCore.Data;assembly=DesktopCoreDesktopCore.Data  P LDesktopCore.Resources, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullH8clr-namespace:DesktopCore;assembly=DesktopCore.ResourcesDesktopCore  TaskPanel.UI&    TaskPanel.UI.Controls.TaskDetail   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Bdd3clr-namespace:DesktopCore.Data;assembly=DesktopCore     Fc8clr-namespace:DesktopCore;assembly=DesktopCore.Resources     -     >�Name$
  root�� � 	Resources .   (DesktopCore.Data.DateTimeFormatConverter   dateTimeFormat 	 label �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker  textbox��%�  &	        &	      '�� �     '  �     &	 %      �� " ��.���  � ��$
 Bold"���  � �� �#6C6C6C��  � �� �#F0F0F0��  � ��$	 4,2q���  � ��$ 0,4,0,0q��� " ��.���  � ��$ 3q���  � �� �#6C6C6C�� "  .���  � ��$ 3q���  � �� �#6C6C6C��  � ��$ 0q��� " ��.���  � ��$	 4,2q���  � ��$ 0,4,0,0q���  � ��$ 3q���  � �� �#6C6C6C.��� $��5q�
������� � RowDefinitions �� $
��Auto ��� $��2* ��� $
��Auto ��� �� $
��Auto ��� $
��Auto �.+�� $��0�� � ColumnDefinitions �� $
��Auto ��� �� $
��Auto ��� �� $
��Auto ��� .+��� #��[ $��0����  DesktopCore.Resource  *Label.Created+y��� *	Task.ID+ �� ElementName$
 root��  notZeroToVisibility �� 	Converter# [ �� #��[ $��0q�$��1������ *Task.Created+$
 root��# [  y��� *	Task.ID+$
 root��# [ �� #��[ $��2����  *Label.Modified+y��� *	Task.ID+$
 root��# [ �� #��[ $��0q�$��3������ *Task.Modified+$
 root��# [  y��� *	Task.ID+$
 root��# [ �� #��[ $��4����  *Label.Deadline+�� 	 �� Orientation$	 
Horizontal=�$��5��.+��� -   
 ��Name$
 cbxDeadline��$��Center=�$	��2,0q� d� 	IsChecked �� *Task.Deadline+$
 root�� �� Mode$ OneWay=�  
nullToBool# [      SelectedDate �� *Task.Deadline+$
 root��{��� *	IsChecked+$ cbxDeadline��]� $��1��.+��� #��[ $	��Top=���  *Label.Content+ �� Target �� $ 
tbxContent���� -    ��Name$ 
tbxContent�� �� AcceptsReturn .  �� TextWrapping$
 Wrap=����� *Task.Content+$
 root���� $��5��$��Center=�$��Stretch=�
������ $��2��$��0��]� $��3��.+��� #��[ $	��Top=���  *Label.Solution+ �� $ tbxSolution���� -   $ tbxSolution�� . $
 Wrap=����� *Task.Solution+$
 root��� $��0,5,0,0q�$��4�� �� $	��100 ��� �� $
��Auto ��� $
��Auto �.+�]� $��0,0,2,0q�.+��� #��[ $	��Top=���  *
Task.State+ �� $ coxTaskStates���� -    ��Name$ coxTaskStates�� �� SelectedItem �� *
Task.State+$
 root������ *
TaskStates+$
 root������ .R��� $	 
Horizontal=�$	��0,2q�.+��� $��16������ *Image+�� $��0q�$��5,0,0,0q����� *Name+]� $��2,0,0,0q�$��1��.+��� #��[ $	��Top=���  *
Task.Group+ �� $ coxTaskGroups���� -   $ coxTaskGroups�� �� *
Task.Group+$
 root������ *Groups+$
 root������ .R��� $	 
Horizontal=�$	��0,2q�.+��� $��16������ *Image+�� $��0q�$��5,0,0,0q����� *Name+�� $��2,0,0,0q�$��2��.+��� #��[ ��  *Label.Priority+��   priority#��[  � Value �� *Task.Priority+$
 root���� $	 
Horizontal=�$��Right=�$��4,4,0,4q�$��3��.+��� -    ��Name$ btnSaveTask��$��60��$��Right=���  *Button.Save+�� -   $ btnCloseTask��$��60��$��Right=�$��5,0,0,0q���  *Button.Close+