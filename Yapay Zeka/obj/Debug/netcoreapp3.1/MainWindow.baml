   M S B A M L   `   `   `  ����E  AYapay Zeka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Yapay_Zeka
Yapay_Zeka  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	       Yapay_Zeka.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Yapay_Zeka     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	   -   5          � Title$  
Kök Bulma��5	   	   $	��468��6   $
��1047��6(   .��5      �� $
��Auto=�6   $
��Auto=�68   .��5   
   ��  �� Orientation$ Vertical=�6   .+�5      �� $ 
Horizontal=�6   $��Center=�62   .+�5      �� $��1q�6   ���	#FFA0A0A0$��5q�6E   ._�5      �� $ Vertical=�6!   $��Center=�68   .+�5      	� -   5        $��F1��5   �   $��f (x) = e sin(x)��6&   $��10,10,10,10q�6A    d� 	IsChecked$
 TrueY�6V   $��18(�6g   $
��Bold"�6u   $��Italic$�6�   $��Cambria)�6�   6�   	� 5      -   5        $��F2��5   �   $(��"f (x) = ln( x - 1 ) + sin( x - 3 )��6&   $��10,10,10,10q�6S   $��18(�6h   $
��Bold"�6v   $��Italic$�6�   $��Cambria)�6�   6�   	� 5      -   5        $��F3��5   �   $-��'f (x) = ( e^x - e^-x ) / ( e^x + e^-x )��6&   $��10,10,10,10q�6X   $��18(�6m   $
��Bold"�6{   $��Italic$�6�   $��Cambria)�6�   6�   	� 5      -   5        $��F4��5   �   $(��"f (x) = -x^2 ( x^2 - 4 ) ( x - 5 )��6&   $��10,10,10,10q�6S   $��18(�6h   $
��Bold"�6v   $��Italic$�6�   $��Cambria)�6�   6�   	� 5      -   5        $��F5��5   �   $-��'f (x) = 150e^(-x/2) ( cos(x) - sin(x) )��6&   $��10,10,10,10q�6X   $��18(�6m   $
��Bold"�6{   $��Italic$�6�   $��Cambria)�6�   6�   	� 5      -   5        $��F6��5   �   $,��&Altı Kamburlu Deve Sırtı Fonksiyonu��6&   $��10,10,10,10q�6T   $��18(�6i   $
��Bold"�6w   $��Italic$�6�   $��Cambria)�6�   6�   5      5      �� 5      $��1q�6   ���	#FFA0A0A0$��5q�6E   ._�5      �� $ Vertical=�6!   $��	10,10,5,5q�68   .+�5      �� -   5        $��chcGA��5      $��Genetik Algoritma��6#   $
��Bold"�6?   $��Center=�6Q   $
 TrueY�6n   6   �� 5      $��5q�6$   �� 5      $ ��Popülasyon Büyüklüğü��6$   $
��Bold"�6@   $��Center=�6R   �� 5      -	   5        $��txtGAPopulasyonBuyuklugu��5   Z   $��8��6"   $��5q�6+   $��Center=�66   6Z   �� 5      $��5q�6$   �� 5      $��Maksimum İterasyon��6$   $
��Bold"�6>   $��Center=�6P   �� 5       -
   5        $��txtGAiterasyon��5    \   $	��100��6"   $��5q�6-   $��Center=�68   6\   �� 5!      $��5q�6$   �� 5"      $��Mutasyon Oranı��6$   $
��Bold"�6:   $��Center=�6L   �� 5#      -   5        $��txtGAMutasyon��5#   \   $	��0,1��6"   $��5q�6-   $��Center=�68   6\   �� 5$      $��5q�6$   �� 5%      $��Çaprazlama Oranı��6$   $
��Bold"�6<   $��Center=�6N   �� 5&      -   5        $��txtGACaprazlama��5&   \   $	��0,5��6"   $��5q�6-   $��Center=�68   6\   5'      5(      �� 5)      $��1q�6   ���	#FFA0A0A0$��5q�6E   ._�5*      �� $ Vertical=�6!   $��	10,10,5,5q�68   .+�5+      �� -   5        $��chcPSO��5+   �   $$��Parçacık Sürü Algoritması��6#   $
��Bold"�6G   $��Center=�6Y   $
 TrueY�6v   6�   �� 5,      $��5q�6$   �� 5-      $ ��Popülasyon Büyüklüğü��6$   $
��Bold"�6@   $��Center=�6R   �� 5.      -   5        $��txtPSOPopulasyonBuyuklugu��5.   [   $��20��6"   $��5q�6,   $��Center=�67   6[   �� 5/      $��5q�6$   �� 50      $��Maksimum İterasyon��6$   $
��Bold"�6>   $��Center=�6P   �� 51      -   5        $��txtPSOiterasyon��51   \   $	��100��6"   $��5q�6-   $��Center=�68   6\   �� 52      $��5q�6$   �� 53      $��
c1 değeri��6$   $
��Bold"�65   $��Center=�6G   �� 54      -   5        $��txtC1��54   Z   $��2��6"   $��5q�6+   $��Center=�66   6Z   �� 55      $��5q�6$   �� 56      $��
c2 değeri��6$   $
��Bold"�65   $��Center=�6G   �� 57      -   5        $��txtC2��57   \   $	��2,1��6"   $��5q�6-   $��Center=�68   6\   58      59      �� 5:      $��1q�6   ���	#FFA0A0A0$��5q�6E   ._�5;      �� $ Vertical=�6!   $��	10,10,5,5q�68   .+�5<      �� $��Fonksiyon Aralığı��6$   $
��Bold"�6=   $��Center=�6O   �� 5=      $��5q�6$   �� 5>      $��Minimum Değer��6$   $
��Bold"�69   $��Center=�6K   �� 5?      -   5        $��
txtMinimum��5?   m   $��-2��6"   $��5q�6,   $��Center=�67   ${�False��6[   6m   �� 5@      $��5q�6$   �� 5A      $��Maksimum Değer��6$   $
��Bold"�6:   $��Center=�6L   �� 5B      -   5        $��txtMaksimum��5B   l   $��3��6"   $��5q�6+   $��Center=�66   ${�False��6Z   6l   �� 5C      $��5q�6$   �� 5D      $��
Hassasiyet��6$   $
��Bold"�66   $��Center=�6H   �� 5E      -   5        $��txtHassasiyet��5E   Z   $��5��6"   $��5q�6+   $��Center=�66   6Z   �� 5F      $��5q�6$   �� 5G      -   5        $��	chcGrafik��5G   =   $��Grafik Çizilsin��6#   $
 TrueY�6N   5H      5I      5J      �� 5K      -   5        $��
btnHesapla��5K   =   $��Hesaplamaya Başla��6   $��10q�61   6O   �� 5L      $ 
Horizontal=�6   .+�5N      #  LiveCharts.Wpf.CartesianChart  -   5        $��Tablo1��5N   a   &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=�6J      Series 6%   �� *SeriesCollection1+   AxisY 5P        LiveCharts.Wpf.Axis     Title$ Değişken Konumu��6#      LabelFormatter 6;   �� *YFormatter1+6d      AxisX 5S        $ 
İterasyon��6#   	   Labels	 65   �� *	Labels1+6R   5U        5W      -   5        $��Tablo2��5W   a   $ Right=�6J    6%   �� *SeriesCollection2+ 5Y        $ Amaç Fonksiyonu��6#    6;   �� *YFormatter2+6d    5\        $ 
İterasyon��6#   	 65   �� *	Labels2+6R   5^      5_      5`      5a      5b      