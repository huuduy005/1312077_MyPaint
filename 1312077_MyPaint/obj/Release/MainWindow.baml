   M S B A M L   `   `   `  ���� J  F1312077_MyPaint, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:_1312077_MyPaint_1312077_MyPaint  !    _1312077_MyPaint.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     X TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  :d2http://schemas.microsoft.com/expression/blend/2008  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  *localclr-namespace:_1312077_MyPaint    � Title$  My Paint��$	��350��$	��525�� � Icon$ icon.png��.��� ���	#FFE0E0E0.+��� -    ��Name$ canvasPaint��
�������$��0,61,0,0q��� -    ��Name$ strokeThick_lb��$��StrokeThick:��$
��Left=�$��31��$��
134,30,0,0q�$	��Top=�$��75���� -   $ PositionCanvas��$�� ��$
��Left=�$��0,6,0,0q�$	��Top=�$	��128��$��Center=�$��40��#  Xceed.Wpf.Toolkit.ColorPicker  -     Name$ coloPick��$��35��$��50��$��79,6,0,0q�$
��Left=�$	��Top=�$��Center=�$��21.333(�
�������   SelectedColor$ BlackX��� -    ��Name$ bt_rectangle��$��	Rectangle��$
��Left=�$��	134,6,0,0q�$	��Top=�$��75���� -   $ 
bt_ellipse��$��Ellipse��$
��Left=�$��	214,6,0,0q�$	��Top=�$��75���� -   $ bt_line��$
��Line��$
��Left=�$��	294,6,0,0q�$	��Top=�$��75���� -   $ clean_bt��$��Clean��$
��Left=�$��
374,16,0,0q�$	��Top=�$��75���� -	    ��Name$ strokeThick_cb��$
��Left=�$��
214,31,0,0q�$	��Top=�$	��155�� �� ItemStringFormat$  ��.@��� 
�������	 �� 
IsSelected	 . .���� 
 �� Orientation$
 
Horizontal=�.+��� 	 �� X1$ 0��	 �� Y1$ 9��	 �� X2$	 120��	 �� Y2$ 9��
���   �$��1���� 
���   �1�� .���� $
 
Horizontal=�.+��� $ 0��$ 9��$	 120��$ 9��
���   �$��2���� 
���   �2�� .���� $
 
Horizontal=�.+��� $ 0��$ 9��$	 120��$ 9��
���   �$��5���� 
���   �5�� .���� $
 
Horizontal=�.+��� $ 0��$ 9��$	 120��$ 9��
���   �$��10���� 
���   �10