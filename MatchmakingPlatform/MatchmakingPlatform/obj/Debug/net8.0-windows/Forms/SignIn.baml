   M S B A M L   `   `   `  ����N  JMatchmakingPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:MatchmakingPlatform.BLMatchmakingPlatform.BL  5   	   #    MatchmakingPlatform.BL.SignIn   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:MatchmakingPlatform.BL     5   	     � Title$  Sign In��5   	   $
��1000��6   $	��800��6'   ���#F3F4F6 � WindowStartupLocation$ CenterScreen=�6H    � 	Resources 5
       �� 
TargetType �� Property �� Value��%~   '��       �� 5   
   " ��6   .�5      ��  � ��$ Segoe UI)�6+   �� 5       � ��$
 20px(�6)   5      5      .��5      � $��30q�6   ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$ #FF8ACD��6   	 � Offset$	 0Q�6/   � 5      $ #D57EED��6   $		 0.3Q�6/   � 5      $ #5A3DFF��6   $		 0.6Q�6/   � 5      $ #00BFFF��6   $	 1Q�6/   5      .+�5!   
   �� 
�������
 �� CornerRadius$
 15��6$    �� Padding$ 40q�66   $��Center=�6C   $��Center=�6^    J� Effect 5"      3  -System.Windows.Media.Effects.DropShadowEffect  5#         
BlurRadius$ 15Q�6#      ShadowDepth$ 10Q�63      	Direction$	 320Q�6D      Color$ #888888��6T   ._�5'      �� $��Center=�6   $��Center=�64   $
��Auto��6Q   $
��Auto��6^   .+�5)      �� $��Sign In��6   $��36(�6+   $
��Bold"�69   ���#2196F3$��Center=�5*      $��	0,20,0,40q�69   �� 5-      $��	Username:��6   
�������$��0,0,0,5q�6?   �� 5.      -   5        $��UsernameTextBox��5.      $
��Auto��61   $	��350��6>   $��40��6M   ���#F8F9FA���#BDBDBD$��0,0,0,15q�6�   $��20(�6�   6�   �� 51      $��	Password:��6   
�������$��0,0,0,5q�6?   G� 52      -   5        $��PasswordBox1��52      $
��Auto��62   $	��350��6?   $��40��6N   ���#F8F9FA���#BDBDBD$��0,0,0,15q�6�   $��20(�6�   �� 55      -   5        $��ErrorMessageTextBlock��55      
���  ��$y�	Collapsed=�6J   $
��0,10q�6a   $��18(�6o   �� 58       �� Orientation$ 
Horizontal=�6   $��Center=�66   $��	20,30,0,0q�6S   .+�59      �� -   5        $��Sign In��59      $
��Auto��6/   $	��150��6<   $��40��6K   $��5q�6W   ���#4CAF50
�������$
��Bold"�6�   
������ 6�   5:      �� 5=      $ 
Horizontal=�6   $��Center=�66   $��	20,10,0,0q�6S   .+�5>      �� -   5        $��Create an Account��5>      $
��Auto��69   $	��200��6F   $��40��6U   $��5q�6a   ���#2196F3
�������$
��Bold"�6�   
������ 6�   5?      5A      5B      5C      5D      