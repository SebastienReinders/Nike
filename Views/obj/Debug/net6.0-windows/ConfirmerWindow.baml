   M S B A M L   `   `   `  ����	  Views    Views.ConfirmerWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Confirmation Panier��5   	   $	��450��6%   $	��800��62   .��5      � $��20q�6    � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $"��Confirmation de votre panier��6   $
��Bold"�68   $��24(�6J   $��Center=�6X   $��0,0,0,20q�6u   $��0��6�   � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#    5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��Nom :��6   $��Center=�6$   $��0,0,10,0q�6?   �� 5       $��1��6   $��0,0,0,10q�6&   ��68   �� *Nom+ �� Mode$ TwoWay=��� 5"      $��	Prénom :��6   $��1��6'   $��Center=�64   $��0,0,10,0q�6O   �� 5#      $��1��6   $��1��6&   $��0,0,0,10q�63   ��6E   �� *Prenom+$ TwoWay=��� 5%      $��	Adresse :��6   $��2��6(   $��Center=�65   $��0,0,10,0q�6P   �� 5&      $��1��6   $��2��6&   $��0,0,0,10q�63   ��6E   �� *	Adresse+$ TwoWay=��� 5(      $��Age :��6   $��3��6$   $��Center=�61   $��0,0,10,0q�6L   �� 5)      $��1��6   $��3��6&   $��0,0,0,10q�63   ��6E   �� *Age+$ TwoWay=��� 5+      $��GSM :��6   $��4��6$   $��Center=�61   $��0,0,10,0q�6L   �� 5,      $��1��6   $��4��6&   $��0,0,0,10q�63   ��6E   �� *GSM+$ TwoWay=�5-      �� 50   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   $
��0,20q�6K   $��2��6Y   .+�51      �� $��Annuler��6   $	��100��6'   $��10q�63   ��6?   �� *AnnulerCommand+�� 52      $��	Confirmer��6   $	��100��6)   $��10q�65   ��6A   �� *EnvoyerCommande+53      54      55      