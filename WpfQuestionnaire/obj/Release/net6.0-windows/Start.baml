   M S B A M L   `   `   `  ���� K  GWpfQuestionnaire, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WpfQuestionnaireWpfQuestionnaire      WpfQuestionnaire.Start   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:WpfQuestionnaire       � Title$  QuizApp welcome��$	��800��$	��600�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � 	Resources    BackgroundBrush � Offset � Color  BorderBrush��%�   &	        &	 @     �� .��� $ 0Q�$ #3D348B��� $	 1.2Q�$ #000000���� .��� $ 0Q�$ #FFFF��� $	 0.5Q�$ #000000��.��� #���      TransparentBrush �� Color �� Opacity �� 
TargetType  Text	 �� Property
 �� Value��%�   &	       &	      �� $ #E0E2DB��$	 0.1Q��� " ��.��� 	 � ��$
 30(��� 	 � ��
 �#E0E2DB�� 	 �@��Padding$
 	30 0 30 0q��� 	 � ��$

 Bold"��� 	 �@��TextAlignment$
 Center=� � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��$��2��$��Center=�$��Center=�$��90(�$��	ExtraBold"����#E0E2DB.��
Quiz App��  �� CornerRadius$ 40��#��[ 
������ $��2��$��	40 0 40 0q� �� Padding$ 30q�._��� .+��� $��Welcome��#��[ �� $��to my Quiz App.��#��[ �� $��Press start to play.��#��[ �� $"��After you finished the quiz.��#��[ �� $��You will be able to see ��#��[ �� $��the scoreboard. ��#��[ �� $ ��And how well you preformed��#��[ �� $��Good luck !!!��#��[ �� -   $��3��$��About��$��Center=�$��Center=�$��	0,0,10,10q�$��75���� -    ��Name$ 	StartQuiz��$��4��$��2��$��Start�����#E6AF2E$
��auto��$
��Bold"�$��50(�$��
20 0 20 30q�#���  $��2q� ��%:   '��       �� " ��.��� 	 �@��CornerRadius$
 20��