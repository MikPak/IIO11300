   M S B A M L   `   `   `  ����   WinLotto    WinLotto.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     �Name$  WinLotto�� � Title$ 
MainWindow��$��552.6��$��281.8��.��� $��0,0,12.2,3.4q� � RowDefinitions �� $	��37* ��� $
��360* � � ColumnDefinitions �� $	��63* ��� $
��200* �.+��� $��Choose the game��$
��Left=�$��	10,29,0,0q�$	��Top=�$��34��$	��105��$��2��$��2���� -    ��Name$ DropDownMenu��$
��Left=�$��69.8,29,0,0q�$	��Top=�$	��120��{�.  $��1��$��2��.@��� $��Suomi�� �� 
IsSelected . �� $��Number of drawns��$
��Left=�$��	10,31,0,0q�$	��Top=�$	��105��$��2��$��1���� -    ��Name$
 Draw��$
��Draw��$
��Left=�$��38��$��	10,88,0,0q�$	��Top=�$	��118��$��2��$��1���� -   $ Clear��$��Clear��$
��Left=�$��38��$��69.8,88,0,0q�$	��Top=�$	��120��$��1��$��1���� -   $
��Left=�$��22��$��69.8,35,0,0q� �� TextWrapping$
 Wrap=�$��1��$	��Top=�$��41��{�.  $��1��$��1���� $��Randomly drawn numbers:��$
��Left=�$��
10,150,0,0q�$	��Top=�$	��164��$��2��$��1���� -   $ CloseButton��$��Close��$
��Left=�$��31��$��71.8,350.2,0,0q�$	��Top=�$	��118��$��1��$��1���� -    ��Name$ DrawnNumbers��$
��Left=�$��95��$��
10,181,0,0q�$
 Wrap=�$	��Top=�$	��243��$��2��$��1���� -   $ 	Draw_Copy��$
��Draw��$
��Left=�$��38��$��	10,88,0,0q�$	��Top=�$	��118��$��2��$��1���� -	   $ 
SaveButton��$
��Save��$
��Left=�$��31��$��10,283.2,0,0q�$	��Top=�$	��118��$��2��$��1���� -
   $ OpenFileButton��$
��Open��$��Right=�$��31��$��0,283.2,10.2,0q�$	��Top=�$	��118��$��1��$��1���� -   $ checkButton��$��Check��$
��Left=�$��31��$��10,350.2,0,0q�$	��Top=�$	��118��$��2��$��1���� -   $ correctNumbers��$��2��$
��Left=�$��10,319.2,0,126q�$��1��$
 Wrap=�$	��243��