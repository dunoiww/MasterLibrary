   M S B A M L   `   `   `  ���� H  DMasterLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:MasterLibrary.Views.Admin.StatisticalPage)MasterLibrary.Views.Admin.StatisticalPage  U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf ?    9MasterLibrary.Views.Admin.StatisticalPage.StatisticalPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Ilocal7clr-namespace:MasterLibrary.Views.Admin.StatisticalPage     Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  _ [MaterialDesignThemes.Wpf, Version=4.7.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     N�Name$  StatisticalPageML��   MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignFont N� 
FontFamily# �    StatisticVM � DataContext# [  N� Title$ StatisticalPage�� � Triggers :�  :� RoutedEvent$ Page.Loaded��.[��� .���� .��W�  �� 
TargetName$ StatisticalPageML��	 �� TargetProperty$	 Opacity�
 W� From$
 0X�	 W� To$ 1X� g� Duration$ 0:0:0.5D�.���  � RowDefinitions �� $��* ��� $��9* �.+���  �� Orientation$ 
Horizontal=�$��0��$��	30 0 30 0q�.+��� -    ��Name$ category��$��0 20 0 0q�.+��� -    ��Name$ categoryBox��$	��200��$��20(� �� SelectedIndex$ 0�� �� SelectedItem �� *SelectedPeriod+ �� Mode$ OneWayToSource=�.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *ChangePeriodML+   CommandParameter ��  �� ElementName$ categoryBox��  $ SelectionChanged��.    �� *ChangePeriodML+ �� $ categoryBox��.@��� $��	Theo năm���� $��Theo tháng���� -   $
 time��$��30, 20, 0, 0q�.+��� -   $ TimeBox��$	��170��$��20(� �� *SelectedTime+$ OneWayToSource=�   $ Loaded��.    �� *ChangePeriodML+ �� $ TimeBox��  $ SelectionChanged��.    �� *ChangePeriodML+ �� $ TimeBox��� $��1�� � ColumnDefinitions �� $��3* ��� $��7* �.+�� $��0�� �� $
��3.3* ��� $
��3.3* ��� $
��3.3* �.+�� $��0��.+��� $��1q� �� CornerRadius$ 5��$��30 0 0 5q�._�#  MaterialDesignThemes.Wpf.Card  $
��auto�����	#FFE7E889.���  �� �� .+�� $��0�� �� $
��1.5* ��� $��1* �.+�� $��0��.+��� $��
Tổng thu��$��30(�$��Center=�$��10 0 0 0q� � ToolTip$@ :Tiền bán sách, tiền hỏng sách, tiền trễ hạn��� $��1��$��40��$��40������  �� ImageSource$" /Resources/Images/Income.png��� $��1��.+��� $��25(�$��Center=�$��10 0 0 0q� �� Padding$ 5q�$
��Bold"����	#FF393922���� *	TotalIn+� $��1��.+��� $��1q�$ 5��$��30 0 0 5q�._�  $
��auto�����	#FFF19874.���  �� �� .+�� $��0�� �� $
��1.5* ��� $��1* �.+�� $��0��.+��� $��
Tổng chi��$��30(�$��Center=�$��10 0 0 0q�$0 *Tiền nhập sách, chi phí sửa chữa��� $��1��$��40��$��40������ $5 //Resources/Images/image_2022-12-06_11-23-02.png��� $��1��.+��� $��25(�$��Center=�$��10 0 0 0q�$ 5q�$
��Bold"����	#FF393922���� *
TotalOut+� $��2��.+��� $��1q�$ 5��$��30 0 0 5q�._�  $
��auto�����	#FFA8E8E3.���  �� �� .+�� $��0�� �� $
��1.5* ��� $��1* �.+�� $��0��.+��� $��Lợi nhuận��$��30(�$��Center=�$��10 0 0 0q�� $��1��$��40��$��40������ $$ /Resources/Images/interest.png��� $��1��.+��� $��25(�$��Center=�$��10 0 0 0q�$ 5q�$
��Bold"����	#FF393922���� *
TrueIncome+�� $��1��.+�  
�������$	��800��$	��496��$	��top=�   UniformCornerRadius$ 5Q�.��#  LiveCharts.Wpf.CartesianChart  &   LiveCharts.Wpf.Charts.Base.Chart    LegendLocation$  Bottom=�!   Series! �� *
IncomeData+$ TwoWay=�" �� UpdateSourceTrigger$" PropertyChanged=�#   AxisX# #	  LiveCharts.Wpf.AxesCollection	  
  LiveCharts.Wpf.Axis
  $ 
  MinValue$$ 1Q�% 
  MaxValue% �� *LabelMaxValue+& 
  	Separator&   LiveCharts.Wpf.Separator  '   Step$' 1Q�(   AxisY( 
  ) 
  Title$) Triệu đồng��* 
  
FontFamily$* arial)�$$ 0Q�