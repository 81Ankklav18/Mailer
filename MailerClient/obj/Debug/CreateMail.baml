   M S B A M L   `   `   `  ����G  CMailerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MailerClientMailerClient  5   	       MailerClient.CreateMail   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MailerClient     5   	     � Title$  
CreateMail��5   	   $	��450��6   $	��800��6)    � 	Resources 5	       �� 
TargetType �� Property �� Value��%�   '��       �� 5
   
   " ��6   .�5      ��  � ��$ 	20 8 20 8q�6'   �� 5       � ��$	 100��6&   �� 5       � ��$ 30��6'   5      5      .��5      �� .+�5   
   �� '%Заголовок сообщения6)   �� 5   
   -   5        $��message_name��5      �� 5   
   Адресат6   �� 5   
   -   5        $��	addressee��5      �� 5   
   
Тэги6   �� 5   
   -   5        $
��tags��5      �� 5   
   Сообщение6   �� 5   
   -   5        $��message��5      $	��250��6!   �� 5   
   -   5        $��Отправить��5      6%   5      5      