   M S B A M L   `   `   `  ���� K  GTaskPanel.UI, Version=1.0.2.41669, Culture=neutral, PublicKeyToken=null=#clr-namespace:TaskPanel.UI.ControlsTaskPanel.UI.Controls  P LDesktopCore.Resources, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullH8clr-namespace:DesktopCore;assembly=DesktopCore.ResourcesDesktopCore &     TaskPanel.UI.ConfigurationWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     2ui#clr-namespace:TaskPanel.UI.Controls     Fc8clr-namespace:DesktopCore;assembly=DesktopCore.Resources     $	��500��$	��700��  � Icon$+  %/TaskPanel.UI;component/TaskPanel.ico�� � ShowInTaskbar .   � WindowStartupLocation$ CenterScreen=� � Title   DesktopCore.Resource  *
Conf.Title+ � 	Resources  �� 
TargetType �� Property �� Value J� SnapsToDevicePixels-  'System.Windows.Input.KeyboardNavigation	   TabNavigation
 � ColumnDefinitions �Name � RowDefinitions �� CornerRadius �� Padding K� IsItemsHost   TabIndex K� ZIndex   DirectionalNavigation �� SelectedContent �� SelectedContentTemplate" �� SelectedContentStringFormat �� ContentStringFormat �� 
TargetType ��Name ��Name � Cursor �� Triggers P� 
SourceName P� Property P� Value �� 
TargetName��%Q  '��       '�� %     '�� J     '�� �    �� " ��.���  � ��
 ������� " ��.���  � ��
 ������� " ��.���  � ��
 ���� ��  � ��$ 0q���  � �� �� .R�� }�.  . $	 Local=�
 �� $ ColumnDefinition0���� $ ColumnDefinition1��$��0 � �� $ RowDefinition0��$
��Auto ��� $ RowDefinition1��$��* �.+��� $ 5�����#585858$��2q����#2E2E2E$ 3q�._��� $��HeaderPanel�� . $��2,2,2,0q�$ 1��$ 1��$��0��$��0���� $��ContentPanel��#��z��#��z��#��z��$ 2��$	 Local=�$ 	Contained=�$��0��$��1��._��� $��PART_SelectedContentHost��#��z #��z # z $��SelectedContent��#��z��# z �� " ��.���  � �� �#444444��  � �� �� " ��.R��� $ Border��$��1q����#444444$ 2��$��0,0,4,0q�._��� $ Content��#��z��
�������$	��8,2q�$
 Hand�� P� $ Content�� �@J�IsMouseOver . . ��� $ Border�� � ��
 �����P�  �@��
IsSelected . . ��� $ Border�� � �� �#aaaaaa�� $ Content�� � ��
 �   �.����    windowBorder#��[  ._�]� $��10q�.+��� ���#cccccc$
��Bold"�$��15(�$
��10,5q�$	��Top=����� *SelectedItem.ToolTip+  �� ElementName$  tbcSections���� -   ! ��Name$! tbcSections��.@��� ��  *Conf.Visuals+" � ToolTip"   *Conf.VisualsToolTip+.��� 
 �� $	��120 ���  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0����  *Conf.Language+�� $��0��$��1����  *Conf.WindowBehavior+�� $��0��$��2����  *Conf.TaskDetail+�� $��0��$��3����  *Conf.GroupsSort+�� $��0��$��4����  *Conf.ConfFile+�� -   # ��Name$# coxLanguages��$ �� DisplayMemberPath$$ DisplayName��$	��200��$
��Left=�$	��0,2q�$��1��$��0��% �� SelectedItem% �� *Configuration.Locale+�� $	��0,2q�$��1��$��1��.+��� $��5q�& d� 	IsChecked& �� *Configuration.ShowInTaskbar+��  *Conf.ShowInTaskBar+�� $��5q�& �� * Configuration.ShowInWindowList+��  *Conf.ShowInWindowList+�� $��5q�& �� *Configuration.ShowInTray+��  *Conf.ShowInTray+�� $��5q�& �� *Configuration.ShowButtonsText+��  *Conf.ShowButtonsText+�� $	��0,2q�$��1��$��2��.+��� $��5q�& �� *#!Configuration.ShowTaskInNewWindow+��  *Conf.ShowTaskInNewWindow+�� $	��0,2q�$��1��$��3��.+��� ' �� Orientation$' 
Horizontal=�.+��� -   $# coxGroupsSort��$
$ Name��( �� SelectedValuePath$( Value��$	��200��) �� SelectedValue) �� *Configuration.GroupsSort+�� -   $# coxGroupsSortDirection��$
$ Name��$( Value��$	��100��$��2,0,0,0q�) �� *#!Configuration.GroupsSortDirection+�� $��5q�& �� *Configuration.ShowGroupAll+��  *Conf.ShowGroupAll+�� $	��0,2q�$��1��$��4��.+��� $��0,0,0,4q�$' 
Horizontal=�.+��� -   * ��Name$* btnCopyConfig����  *Conf.CopyConfFile+�� ���#dddddd��  *Conf.CopyConfFileHint+�� $��0,0,0,4q�$' 
Horizontal=�.+��� -   $* btnDeleteConfig����  *Conf.DeleteConfFile+�� ���#dddddd��  *Conf.DeleteConfFileHint+�� -   + ��Name$+ tbxConfigFile��, �� 
IsReadOnly, .  - �� IsReadOnlyCaretVisible- . �� ��  *Conf.Groups+"   *Conf.GroupsToolTip+.��� $��10q�
 �� $	��160 ��� $
��Auto ���  �� $
��Auto ��� .+�� $��3��.+��� $��0,0,0,5q�$' 
Horizontal=�.+��� -   $* btnGroupCreate��$	��5,0q���  *Button.Create+�� -	   $* btnGroupDelete��$	��5,0q�$��5,0,0,0q���  *Button.Delete+{��� *SelectedItem+$  	lvwGroups��  
nullToBool. �� 	Converter#. [ �� -
   / ��Name$/ 	lvwGroups��
������ $��0q�$��0��$��1������ *Groups+% �� *SelectedGroup+���� .R�]� .+��� $��24��$	��5,0q�$
��Left=����� *Image+�� .+��� $��0q����� *Name+�� $' 
Horizontal=�.+��� $��0q���  *Label.Priority+�� $��0q�$��5,0,0,0q�$
��Bold"����� *
Priority+�� $��2��$��Stretch=�$��Center=����	#33ffffff$��1��$��1��� $��2��$��1��{��� *SelectedItem+$  	lvwGroups��#. [ 
 �� $��60 ���  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� .+��� $��0��$��0����  *
Label.Name+0 �� Target0 �� $  tbxGroupName���� $��0��$��1����  *Label.Priority+0 �� $  sldGroupPriority���� $��0��$��2����  *
Label.Flag+�� $��0��$��3����  *Label.Image+�� -   $+ tbxGroupName��$��2q�$��1��$��0������ *SelectedGroup.Name+�� -   1 ��Name$1 sldGroupPriority��  priority#��[ $��2q�$��1��$��1��2 � Value2 �� *SelectedGroup.Priority+�� -   $# coxGroupFlag��$$ Value��$	( Key��$	��150��$��2q�$
��Left=�$��1��$��2��) �� *SelectedGroup.Flag+'   !TaskPanel.UI.Controls.FileTextBox  $��2q�$��1��$��3��3   FileName3 �� *SelectedGroup.ImagePath+�� -   $/ lvwGroupIcons��
������ $��0q�$��0,5,0,0q�$��Disabled=�$��1��$��4������ *
GroupIcons+���� .R�� 4 � Orientation$4 
Horizontal=����� .R��� $��32��$��32������ *Image+�� ��  *Conf.States+"   *Conf.StatesToolTip+.��� $��10q�
 �� $	��160 ��� $
��Auto ���  �� $
��Auto ��� .+�� $��3��.+��� $��0,0,0,5q�$' 
Horizontal=�.+��� -   $* btnStateCreate��$	��5,0q���  *Button.Create+�� -   $* btnStateDelete��$	��5,0q�$��5,0,0,0q���  *Button.Delete+{��� *SelectedItem+$  lvwState��#. [ �� -   $/ 	lvwStates��
������ $��0q�$��0��$��1������ *
TaskStates+% �� *SelectedTaskState+���� .R�]� .+��� $��24��$	��5,0q�$
��Left=����� *Image+�� .+��� $��0q����� *Name+�� $' 
Horizontal=�.+��� $��0q���  *Label.Priority+�� $��0q�$��5,0,0,0q�$
��Bold"����� *
Priority+�� $��2��$��Stretch=�$��Center=����	#33ffffff$��1��$��1��� $��2��$��1��{��� *SelectedItem+$  	lvwStates��#. [ 
 �� $��60 ���  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� .+��� $��0��$��0����  *
Label.Name+0 �� $  tbxStateName���� $��0��$��1����  *Label.Priority+0 �� $  sldStatePriority���� $��0��$��2����  *
Label.Flag+�� $��0��$��3����  *Label.Image+�� -   $+ tbxStateName��$��2q�$��1��$��0������ *SelectedTaskState.Name+�� -   $1 sldStatePriority��#��[ $��2q�$��1��$��1��2 �� *SelectedTaskState.Priority+�� -   $# coxStateFlag��$$ Value��$	( Key��$	��150��$��2q�$
��Left=�$��1��$��2��) �� *SelectedTaskState.Flag+  $��2q�$��1��$��3��3 �� *SelectedTaskState.ImagePath+�� -   $/ lvwStateIcons��
������ $��0q�$��0,5,0,0q�$��Disabled=�$��1��$��4������ *TaskStateIcons+���� .R�� $4 
Horizontal=����� .R��� $��32��$��32������ *Image+�� ��  *
Conf.About+"   *Conf.AboutToolTip+.���� .+��� $4��.Author: Marek Fišera (people.neptuo.com/mara)���� $(��"Home: code.google.com/p/task-panel���� -   $ 
lblVersion��