   M S B A M L   `   `   `  ����@  <Views, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ViewsViews  5      D @ViewModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:ViewModel;assembly=ViewModel	ViewModel 5          Views.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      %localclr-namespace:Views     5      @	ViewModel*clr-namespace:ViewModel;assembly=ViewModel     5        � WindowStartupLocation$  CenterScreen=�5	       � Title$ 
Nike store��5
      $	��600��6   $
��1000��6%   .��5      �� $
��Auto=�6   .��5   
   � 
�������.+�5      c� 
���   �$��60��6)   $	��Top=�65   .@�5      o� .@�5      m� $��Options��6   
���   �
���  ��$��	ExtraBold"�6T   $��35(�6k   .@�5      m� $��
Parametres��6#   
���  ��$��	ExtraBold"�6H   $��15(�6_    m� Command 6m   �� *OuvrirPoliceWindowCommand+5      5      �� 5      $��../Images/NikeLogo.png��6   $	��120��68   $��40��6D   $��10q�6P   �� 5      $5��/Bienvenue sur mon Nike Store en tant qu'invité��6   $
��25px(�6R   
�������$��Center=�6u   $��10q�6�   5      � 5      $��	0,2cm,0,0q�6    � ColumnDefinitions 5      �� 5       $
��Auto �6'   �� 5!      $��* �6'    � RowDefinitions 5#      �� 5$      $
��Auto �6$   �� 5%      $
��Auto �6$   .+�5(      �� $��0��6   $��0��6*    �� Orientation$ Vertical=�6:   $��5,5,5,5q�6Q   .+�5)      �� $��Modèle de chaussures��6    $��	ExtraBold"�6<   
���   �$��0,0,0,5q�6f   �� 5*       �� DisplayMemberPath$ Designation��6i    �� SelectedItem 6   �� *SelectedArticle+��6H   �� *
Articles+5,      5-      �� 50      -   5         ��Name$ stackPanel1��50   :   $��0��6   $��1��6*   .+�51      �� 
���   �
���   �$��1q�6D   	 �� CornerRadius$	 5��6X   $	��1cmq�6i   ._�52      �� $��Center=�6$   
���   �
���  ��$'��!Infos sur la paire sélectionnée��6e   $
��20px(�6�   $��	ExtraBold"�6�   53      �� 54      $��20(�6>   $��	1cm 0 0 0q�6L   $��	ExtraBold"�6_   ��6    �� *InfosArticle+6_   �� 55      $
��Left=�6!   $��1cm 1cm 0 0q�6<   .+�56      �� $��Ajouter au panier��6!   
���  ��$��2q�6O   $
��Bold"�6c   $��Italic$�6u   $��0 0 10 0q�6�   $��5q�6�   ��6�   �� *AjouterAuPanierCommand+57      �� 58      $	��350��6I   $	��350��6U   ��6   �� *SelectedArticle.ImagePath+6U   59      �� 5=      $��1��6   $��1��6-   $��20,0,0,0q�6:   $	��Top=�6L   .+�5>      �� 
���   �$��1q�61   $	 5��6E   $	��1cmq�6V   
���   �._�5?      �� $��
Mon panier��6$   $��	ExtraBold"�66   $��25(�6M   
���   �
���  ��$��Center=�6   $��10q�6�   5@      �� 5A      $��10q�6!   .+�5B      �� $ 
Horizontal=�6%   .+�5C      �� $��Désignation��6$   $
��Bold"�6:   $��35(�6L   $��	0,0,250,0q�6Z   �� 5D      $
��Prix��6$   $
��Bold"�63   $��35(�6E   $��	0,0,150,0q�6S   �� 5E      $��	Quantité��6$   $
��Bold"�67   $��35(�6I   $��	0,0,150,0q�6W   5F      �� 5G      ��6'   �� *ArticlesPanier+
 � 	Resources
 5H       �� 
TargetType �� Property �� Value �� Triggers �� Binding �� Value��%�   '��       �� 5I   "   " ��6(   .�5J   &   ��  � ��$ 0,10,0,0q�6?    5K   &   �� 5L   *    66   �� *Designation+ 
Air Max 906V   .a�5M   .   ��  � ��$ 
100,10,0,0q�6G   5N   +   5P   #   5Q      ��5R      �� 5S   "   .R�5T   &   �� $ 
Horizontal=�61   $
��0,10q�6J   .+�5U   *   �� $��20(�6Q   $��	0,0,360,0q�6_   ��64   �� *Designation+6_   �� 5V   *   $��20(�6J   $��	0,0,180,0q�6X   ��64   �� *Prix+6X   �� 5W   *   $��20(�6N   $��
15,0,175,0q�6\   ��64   �� *
Quantite+6\   5X   '   5Y   #   5[      �� 5\      
���   �$��1q�65   $
��0,50q�6I   �� 5]      $ 
Horizontal=�6%   $
��0,10q�6>   .+�5^      �� $��Total à payer :��6$   $
��Bold"�6>   $��35(�6P   $��	0,-6,10,0q�6^   �� 5_      $��35(�6E   $
��Bold"�6S   ��6(   �� *TotalAPayer+6S   5`      �� 5a      $ 
Horizontal=�6%   $
��0,10q�6>   .+�5b      �� $��Confirmer panier��6%   
���  ��$��2q�6R   $
��Bold"�6f   $��Italic$�6x   $��0 0 10 0q�6�   $��5q�6�   ��6�   �� *ConfirmerPanierCommand+5c      �� 5d      $ 
Horizontal=�6%   $
��0,10q�6>   .+�5e      �� $��Vider le panier��6%   
���  ��$��2q�6Q   $
��Bold"�6e   $��Italic$�6w   $��0 0 10 0q�6�   $��5q�6�   ��6�   �� *ViderPanierCommand+5f      5g      5h      5i      5j      5k      5l      