   M S B A M L   `   `   `  ���� F  BDesktopCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullH3clr-namespace:DesktopCore.Data;assembly=DesktopCoreDesktopCore.Data  K GTaskPanel.UI, Version=1.0.2.41669, Culture=neutral, PublicKeyToken=null+clr-namespace:TaskPanel.UITaskPanel.UI    TaskPanel.UI.App   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Bdd3clr-namespace:DesktopCore.Data;assembly=DesktopCore     ,localclr-namespace:TaskPanel.UI       �� 	Resources  0   *DesktopCore.Data.NullToVisibilityConverter   nullToVisibility*   $DesktopCore.Data.NullToBoolConverter  
nullToBool2   ,DesktopCore.Data.InversedNullToBoolConverter  iNullToBool8   2DesktopCore.Data.InversedBoolToVisibilityConverter  iBoolToVisibility  boolToVisibility6  0TaskPanel.UI.GroupFlagInboxToVisibilityConverter  inboxToVisibility)  #TaskPanel.UI.TaskPanelWrapConverter  taskPanelWrap/  )TaskPanel.UI.NotZeroToVisibilityConverter  notZeroToVisibility-  'TaskPanel.UI.BoolToWindowStyleConverter  boolToWindowStyle 
	 border �� 
TargetType �� Property �� Value 	
 popup �� BasedOn3	  -System.Windows.Media.Effects.DropShadowEffect 	  ShadowDepth 	  Opacity 	  	Direction 	  
BlurRadius  plainButton  link	 �� Padding
 �� Triggers P� Property P� Value  baseListView  windowBorder  	groupMenu �� 
TargetType J� SnapsToDevicePixels  	groupItem ��Name �� CornerRadius �� Triggers �� 
TargetName  groupButton  
sortButton  	taskPanel  taskItem 
 button ��Name  message  checkBoxButton  
baseSlider �� RelativeSource  priority��%c  &	        &	      &	 
     &	      &	      &	      &	      &	 #     &	 (     &		 -     &	
 �     7 	 &	 P    &	 �    &	 �    &	 �    7 	 &	 �    7  &	 v    &	 �    &	 �    &	 �    7  &	 �    &	 �    &	 �    &	 �    7 	 &	 
    '�� �
    7  &	 �
    7          ��         �� " ��.���  � ��
 �������  � ��$ 0q���  � ��
 �������  �@��CornerRadius$ 5����  � ��$ 0q��� " ��8   .���  � ��$ 2q���  � �� �#444444��  � ��
 �������  �@J�Effect 	  $ 0Q�$ .7Q�$ 0Q�$ 20Q��� .���  � �� �� .R��� #��z����  �@�Cursor$
 Hand���� " ��.���  � ��
 ��  ���  �@�Cursor$
 Hand����  � �� �� .R��� $��Center=�$��Center=�$��0,0,0,1q�#��z��#	 z��#��z��._��� #��z��#��z��
 P�  �@J�IsMouseOver . . ���  � ��
 �  ���� " ��.���  � ��
 ���� ��  � ��$ 0q��� " ��8   .���  � �� �#444444�� " ��8   .���  � �� �� " ��.R��� #��z��#��z��#��z��$	 0q� . ._��� |�.  #��z��.���� # z �� " ��.���  �@�Cursor$
 Hand����  � �� �� " ��.R��� $ 	RowBorder�����#6C6C6C$ 0,5,5,0��$	��0,4q�._���  P�  �@J�IsMouseOver . . ��� $ 	RowBorder�� � �� �#9B9B9BP�  �@��
IsSelected . . ��� $ 	RowBorder�� � ��
 ������� " d�.���  �@�Cursor$
 Hand����  � �� �� " d�.R��� $ 	RowBorder�����#6C6C6C$ 0,5,5,0��$	��0,4q�._���  P�  �@J�IsMouseOver . . ��� $ 	RowBorder�� � �� �#9B9B9BP�  �@d�	IsChecked$
 trueY�. ��� $ 	RowBorder�� � ��
 ������� " ��.���  �@�Cursor$
 Hand����  � �� �� " ��.R��� $ 	RowBorder�����#F1F5FB$ 5��$	��2,0q�._��� #��z��$	��4,2q� P�  �@J�IsMouseOver . . ��� $ 	RowBorder�� � ��
 � �����  � ��
 ������� " ��8   .���  � ��
 ������� " ��.���  � �� �� " ��.R��� $ 	RowBorder��$ 5��$��0,0,0,1q�$		 4,2q�._���  P�  �@��
IsSelected . . ��� $ 	RowBorder��# Z	� � ��P�  �@J�IsMouseOver . . ��� $ 	RowBorder��# Z� � ���� " ��.���  �@�Cursor$
 Hand����  � �� �� " ��.R��� $ 
IconBorder�����#6C6C6C$ 5��._��� $ Content��$	��7,5q���.  P�  �@J�IsMouseOver . . ��� $ 
IconBorder�� � ��
 ������� " ���� " ��.���  �@�Cursor$
 Hand����  � �� �� " ��.R��� $ 
IconBorder��8��  $��0,0,5,0q����#6C6C6C._��� $��2q� P�  �@J�IsMouseOver . . ��� $ 
IconBorder�� � �� �#9B9B9BP�  �@d�	IsChecked$
 trueY�. ��� $ 
IconBorder�� � ��
 ������� " ��.���  �@��TickPlacement$ BottomRight=���  �@��IsSnapToTickEnabled . ��  �@�ToolTip �� *Value+ �� *Self+�� " ��8   �� " ��8   .���  �@�Minimum$ 1Q���  �@�Maximum$ 5Q���  �@��TickFrequency$ .5Q�