   M S B A M L   `   `   `  ����G  CFractalTrees, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FractalTreesFractalTrees  5   	       FractalTrees.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:FractalTrees     5   	     � Title$  Fractal Tree in C#��5   	   $	��900��6$   $
��1040��61   .��5	      � .+�5
   
   �� -   5         ��Name$ txtGenerations��5
      $
��Left=�6*   $��23��6E   $��50,5,0,0q�6Q    �� TextWrapping$
 Wrap=�6c   $�� ��6w   $	��Top=�6   $��40��6�   ���#FFF2E66�   �� 5   
   -   5        $ txtAngle��5      $
��Left=�6$   $��23��6?   $��	213,5,0,0q�6K   $
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $��40��6�   ���#FFF2E66�   �� 5   
   -   5        $ 	txtLength��5      $
��Left=�6%   $��23��6@   $��	361,5,0,0q�6L   $
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $��40��6�   ���#FFF2E66�   �� 5   
   -   5        $ txtRandomness��5      $
��Left=�6)   $��23��6D   $��	515,5,0,0q�6P   $
 Wrap=�6c   $	��0.0��6w   $	��Top=�6�   $��40��6�   ���#FFF2E66�   �� 5   
   -   5         ��Name$ label0��5      $��Number of generations��6    $
��Left=�6@   $��5,22,0,0q�6[   $	��Top=�6m   $	��160��6�   �� 5   
   -   5        $ label1��5      $!��Bifurcation angle (radians)��6    $
��Left=�6F   $��
152,22,0,0q�6a   $	��Top=�6u   $	��160��6�   �� 5   
   -   5        $ label2��5      $��Length Proportion (0-1)��6    $
��Left=�6B   $��
309,22,0,0q�6]   $	��Top=�6q   $	��160��6�   �� 5   
   -   5        $ label3��5      $��Random Proportion (0-1)��6    $
��Left=�6B   $��
467,22,0,0q�6]   $	��Top=�6q   $	��160��6�   �� 5   
   -	   5         ��Name$ btnDraw��5      $��Create Fractal Tree��6"   $
��Left=�6@   $��
688,12,0,0q�6[   $	��Top=�6o   $	��120��6�   ���#FFF2E66�   �� 5   
   -
   5        $ btnReset��5      $��Reset��6#   $
��Left=�63   $��
815,12,0,0q�6N   $	��Top=�6b   $	��120��6z   ���#FFF2E66�   � 5   
   -   5        $��	drawSpace��5      $
��Left=�6    $	��800��6;   $��	15,54,0,0q�6H   $	��Top=�6[   $
��1000��6s   ���#E6FFFF6�   5      5      