   M S B A M L   `   `   `  ����N  JMatchmakingPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:MatchmakingPlatform.BLMatchmakingPlatform.BL  5   	   (    "MatchmakingPlatform.Forms.Register   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:MatchmakingPlatform.BL     5   	     � Title$  Register��5   	   $	��900��6   $	��800��6'   ���#F3F4F6 � WindowStartupLocation$ CenterScreen=�6H    � 	Resources 5
       �� 
TargetType �� Property �� Value��%~   '��       �� 5   
   " ��6   .�5      ��  � ��$ Segoe UI)�6+   �� 5       � ��$
 20px(�6)   5      5      .��5      � $��30q�6   ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$ #FF8ACD��6   	 � Offset$	 0Q�6/   � 5      $ #D57EED��6   $		 0.3Q�6/   � 5      $ #5A3DFF��6   $		 0.6Q�6/   � 5      $ #00BFFF��6   $	 1Q�6/   5      .+�5!      �� .��5"   
   �� 
�������
 �� CornerRadius$
 15��6$    �� Padding$ 40q�66   $��Center=�6C   $��Center=�6^    J� Effect 5#      3  -System.Windows.Media.Effects.DropShadowEffect  5$         
BlurRadius$ 15Q�6#      ShadowDepth$ 10Q�63      	Direction$	 320Q�6D      Color$ #888888��6T   ._�5(      �� $��Center=�6   $��Center=�64   $
��Auto��6Q   $
��Auto��6^   .+�5*      �� $��Register��6   $��36(�6,   $
��Bold"�6:   ���#4CAF50$��Center=�5+      $��	0,20,0,40q�69   �� 5.      $��	Username:��6   
�������$��0,0,0,5q�6?   �� 5/      -   5        $��NameTextBox��5/      $
��Auto��6-   $	��350��6:   $��40��6I   ���#F8F9FA���#BDBDBD$��0,0,0,15q�6�   $��20(�6�   �� 52      $��	Password:��6   
�������$��0,0,0,5q�6?   �� 53      -   5        $��PasswordTextBox��53      $
��Auto��61   $	��350��6>   $��40��6M   ���#F8F9FA���#BDBDBD$��0,0,0,15q�6�   $��20(�6�   �� 56      $��Email:��6   
�������$��0,0,0,5q�6<   �� 57      -   5        $��EmailTextBox��57      $
��Auto��6.   $	��350��6;   $��40��6J   ���#F8F9FA���#BDBDBD$��0,0,0,15q�6�   $��20(�6�   �� 5:      $��Gender:��6   
�������$��0,0,0,5q�6=   �� 5;      -   5        $��GenderComboBox��5;      $
��Auto��61   $	��350��6>   $��40��6M   ���#F8F9FA���#BDBDBD$��0,0,0,15q�6�   $��20(�6�   .@�5<      �� $
��Male��6#   �� 5=      $��Female��6#   5>      �� 5A      $��Date of Birth:��6   
�������$��0,0,0,5q�6D   �� 5B       �� Orientation$ 
Horizontal=�6   .+�5C      (  "System.Windows.Controls.DatePicker  -   5        $��DobDatePicker��5C   !   $
��Auto��66   $	��350��6C   $��40��6R   ���#F8F9FA���#BDBDBD$��0,0,0,15q�6�   $��20(�6�   �� 5D      -   5        $��AgeTextBlock��5D       
�������$��Center=�6F   $��	10,0,0,15q�6a   $��20(�6t   5E      �� 5H      $��Phone Number:��6   
�������$��0,0,0,5q�6C   �� 5I      -   5        $��PhoneNumberTextBox��5I      $
��Auto��64   $	��350��6A   $��40��6P   ���#F8F9FA���#BDBDBD$��0,0,0,15q�6�   $��20(�6�   �� 5L      -   5        $��ErrorMessageTextBlock��5L      
���  ��$y�	Collapsed=�6J   $
��0,10q�6a   $��18(�6o   �� 5O      $ 
Horizontal=�6   $��Center=�66   $��	20,30,0,0q�6S   .+�5P      �� -	   5        $��Register��5P      $
��Auto��60   $	��150��6=   $��40��6L   $��5q�6X   ���#4CAF50
�������$
��Bold"�6�   
������ 6�   �� 5Q      -
   5        $��Sign In��5Q      $
��Auto��6/   $	��150��6<   $��40��6K   $��5q�6W   ���#2196F3
�������$
��Bold"�6�   
������ 6�   5R      5S      5T      5U      5V      5W      