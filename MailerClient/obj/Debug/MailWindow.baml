   M S B A M L   `   `   `  ����G  CMailerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MailerClientMailerClient  5   	       MailerClient.Window1   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MailerClient     5   	     � Title$  Window1��5   	   $	��450��6   $	��800��6&    � 	Resources 5	       �� 
TargetType �� Property �� Value��%�   '��       �� 5
   
   " ��6   .�5      ��  � ��$ 	20 8 20 8q�6'   �� 5       � ��$	 100��6&   �� 5       � ��$ 30��6'   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� -   5        $��0��5      $	��New��6!   6H   �� 5   
   -   5        $��1��5      $��Refresh��6!   6J   �� 5   
   -   5        $��2��5      $��Logout��6!   6K   �� 5!   
   -   5        $��mailList��5!   5   $��1��6   $��10,10,10,10q�6    .@�5"      �� Входящие6"   �� 5#      Исходящие6#   5$      �� 5&   
   -   5        $��
helloLabel��5&      $��1��6"   $��2��6/   &   System.Windows.Controls.DataGrid  5(   
   -   5          Name$ messagesGrid��5(   /      AutoGenerateColumns .  $��2��6E   $��3��6R    5)      )  #System.Windows.Controls.DataGridRow��%E   '        �� 5*      "  6   .�5+      -   5        5,      5-      	   Columns	 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Message name��6F      Width5  /System.Windows.Controls.DataGridLengthConverter$	 125 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *message_name+6\     50      $
 Sender��6@   $ 80 6P    6%   �� *sender+6P     51      $

 Date��6K   $ 80 6Y    6%   �� *registration_date+6Y   53      54      55      