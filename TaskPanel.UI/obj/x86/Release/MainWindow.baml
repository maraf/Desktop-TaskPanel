   M S B A M L   `   `   `  ���� K  GTaskPanel.UI, Version=1.0.2.41669, Culture=neutral, PublicKeyToken=null=#clr-namespace:TaskPanel.UI.ControlsTaskPanel.UI.Controls  P LDesktopCore.Resources, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullH8clr-namespace:DesktopCore;assembly=DesktopCore.ResourcesDesktopCore     TaskPanel.UI.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2ui#clr-namespace:TaskPanel.UI.Controls     Fc8clr-namespace:DesktopCore;assembly=DesktopCore.Resources     -     � Title$  	TaskPanel��$	��500��$	��700�� � Icon$+ %/TaskPanel.UI;component/TaskPanel.ico�� � ShowInTaskbar �� *Configuration.ShowInTaskbar+ � WindowStyle �� * Configuration.ShowInWindowList+   boolToWindowStyle �� 	Converter# [   J� InputBindings �� 
 �� Key$ S�� �� 	Modifiers$ Controlf� �� Command$ ApplicationCommands.Save���� $ Z��$ Controlf�$$ ApplicationCommands.Properties��	 J� CommandBindings	 )  #System.Windows.Input.CommandBinding  -   
   Command$
 ApplicationCommands.Save��  -   $$
 ApplicationCommands.Properties��.����   windowBorder#��[ ._�� .+�� $��10q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� �� $
��Auto � � ColumnDefinitions �� �� $	��150 �.+�� $��1��{��� *ControlsEnabled+.+���  �� Orientation$ 
Horizontal=�.+��� -    ��Name$ btnCreateTask�� 
 button#��[ $��0,0,5,0q�.���� $ 
Horizontal=�.+��� $,��&/TaskPanel.UI;component/Images/Add.png��$��16���� $��_Create��$��5,0,0,0q�$��0q� �� Target �� *btnCreateTask+y��� *Configuration.ShowButtonsText+  boolToVisibility# [ �� $ 
Horizontal=�$��Right=�.+��� -   $ btnEditTask��#��[ .���� $ 
Horizontal=�.+��� $-��'/TaskPanel.UI;component/Images/Edit.png��$��16���� $��_Edit��$��5,0,0,0q�$��0q� �� *btnEditTask+y��� *Configuration.ShowButtonsText+# [ �� -   $ btnDeleteTask��#��[ $��5,0,0,0q�.���� $ 
Horizontal=�.+��� $/��)/TaskPanel.UI;component/Images/Delete.png��$��16���� $��_DELETE��$��5,0,0,0q�$��0q� �� *btnDeleteTask+y��� *Configuration.ShowButtonsText+# [ � $��1��$��1��.+��� $ 
Horizontal=�$��Right=�{��� *ControlsEnabled+.+��� -   $ btnSave��#��[ $��5,0,0,0q�.���� $ 
Horizontal=�.+��� $-��'/TaskPanel.UI;component/Images/Save.png��$��16���� -   $ 
btnRefresh��#��[ $��5,0,0,0q�{�.  .���� $ 
Horizontal=�.+��� $0��*/TaskPanel.UI;component/Images/Refresh.png��$��16���� -	   $ btnSettings��#��[ $��5,0,0,0q�.���� $ 
Horizontal=�.+��� $/��)/TaskPanel.UI;component/Images/Config.png��$��16����  
 border#��[ $��0,5,0,0q�$��2��._�]� .+��� $	��Top=����� *Sorts+y��� *ControlsEnabled+# [ ���� .R��� $ 
Horizontal=�$��Center=�$	��4,2q����� .R��� -
     
sortButton#��[ 
 � Tag �� .���� $ 
Horizontal=�.+��� $��0,0,1,0q����� *	Caption+�� $2��,/TaskPanel.UI;component/Images/ArrowDown.png��$��7��$��4��y��� *SortedAscending+# [ �� $0��*/TaskPanel.UI;component/Images/ArrowUp.png��$��7��$��4��y��� *SortedDescending+# [ � $��2q�$��Bottom=�y��� *ControlsEnabled+# [  �� �� $	��100 �.+���   priority#��[ $��1�� � Value �� *Configuration.MinimumPriority+� .+��� -    ��Name$ lvwTasks��  	taskPanel#��[   taskItem#��[ $��5q����� *Tasks+���� .R��� $ 
Horizontal=�.+��� $ btnCompleteTask��-    � ToolTip$ Complete�� 	 plainButton#��[	  �� .���� $��20��$	��Top=����� *State.Image+� $��5,0,0,0q�����  �� ElementName$ lvwTasks�� �� Path$ ActualWidth� 
 taskPanelWrap# [
 .+��� $��WrapWithOverflow=����� *	Content+&    TaskPanel.UI.Controls.TaskDetail  -     Name$ 	tskDetail��&    TaskPanel.UI.Controls.TaskDetail   	SaveClick$ btnSaveTask_Click��   
CloseClick$ btnCloseTask_Click��$y�Hidden=�   Task �� *
EditedTask+   
TaskStates �� *
TaskStates+   Groups �� *Groups+]� $��1��$��2��{��� *ControlsEnabled+.+�d� -    d�Name$ btnAllTasks��  groupButton#��[ $��0,10,0,0q�$	��Top=� d� 	IsChecked �� *SelectedGroup+  iNullToBool# [  �� Mode$ OneWay=�y��� *Configuration.ShowGroupAll+# [ .���� $ 
Horizontal=�$	��0,2q�.+��� $1��+/TaskPanel.UI;component/Images/TaskList.png��$��5,0,0,0q�$��16����  �� *btnCreateTask+��  DesktopCore.Resource  *	Group.All+�� -   $ 	lvwGroups��$	��150��  	groupMenu#��[   	groupItem#��[ $��0,5,0,0q�
������ ���� *Groups+ �� SelectedItem �� *SelectedGroup+���� .R���   �� CornerRadius$  0,5,5,0��._��� $ 
Horizontal=�$	��0,2q�.+��� $��5,0,0,0q�$��16������ *Image+�� ���� *Name+� $��3��$��2��.+��� -   ! ��Name$! 	lvwStates��  baseListView#��[ $��0,5,0,0q����� *CheckableTaskStates+{��� *ControlsEnabled+���� .R��� " ��Name$" cbxSelectState��-     checkBoxButton#��[  �� *	IsChecked+.���� # ��Name$
# Icon��$��20������ *
Data.Image+���� .R�� �� -   $ ��Name$$ 
lblMessage��$��Message ...��$��Right=�$y�Hidden=�
�������� -   % �Name$% grdLogin�����	#66ffffff$y�	Collapsed=�.+��� $	��400��$	��188�� 	 popup#��[ ._��� $��15q�.+�]� .+��� $
��Bold"�$��Login to TaskPanel��$��5q��  �� $��80 ���  �� �� �� �� .+��� $��File:��$��Center=�$��0��$��0���� $��	Username:��$��Center=�$��0��$��1���� $��	Password:��$��Center=�$��0��$��2��'   !TaskPanel.UI.Controls.FileTextBox  &   CheckFileExists& .  $	��0,4q�$��1��$��0��'   FileName' �� *UserInfo.File+�� $	��0,4q�$��1��$��1������ *UserInfo.UserName+G� '   !TaskPanel.UI.Controls.PasswordBox(   Bind( . $	��0,4q�$��1��$��2��)   Password) �� *UserInfo.Password+$ TwoWay=�* �� UpdateSourceTrigger$* PropertyChanged=�]� $��1��$��3��.+��� $ 
Horizontal=�$	��0,4q�$��Right=�.+��� -   $ btnLogin��$��Login��$	��0,5q�$	��5,2q��� -   $ btnRegister��$��Register new file��$��5,5,0,5q�$	��5,2q��� $	��0,4q�.+��� $��
Auto login�� �� *UserInfo.AutoLogin+�� $��Save password�� �� *UserInfo.SavePassword+