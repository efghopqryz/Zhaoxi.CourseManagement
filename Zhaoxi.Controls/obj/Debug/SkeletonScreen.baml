   M S B A M L   `   `   `  ????J  FZhaoxi.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Zhaoxi.ControlsZhaoxi.Controls  5      $    Zhaoxi.Controls.SkeletonScreen   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Zhaoxi.Controls     5        ? Triggers  5	      :? 5
   
    :? RoutedEvent$ UserControl.Loaded??6   .[?5      ?? .??5      ?? .??5      ??  g? Duration$ 0:0:1D?6%   	 ?? To$ #f7f9faX?66    ?? TargetProperty$* $(Background).(SolidColorBrush.Color)?6C    ?? 
TargetName$ imgBlock??6?    g? RepeatBehavior$ Forever??6?    g? AutoReverse . 6?   W? 5      $ 0:0:1.5D?6&   	 W? To$ 1X?69   $ border1??6@   $( "Background.GradientStops[1].Offset?6`   $ Forever??6?    . 6?   W? 5      $ 0:0:2D?6&   $ 1X?67   $ border2??6>   $( "Background.GradientStops[1].Offset?6^   $ Forever??6?    . 6?   W? 5      $ 0:0:1.3D?6&   $ 1X?69   $ border3??6@   $( "Background.GradientStops[1].Offset?6`   $ Forever??6?    . 6?   5      5      5      .??5      ? $	??0,8q?6   	 ? ColumnDefinitions	 5   
   ?? 5      $	??160 ?6   ?? 5      .+?5   
   ?? -   5        $??imgBlock??5   L   ???#ddd$??80??6#   $??65??6.   
 ?? CornerRadius$
 10??6:   6L   ?? 5   
   $??1??6   $??Center=?6%   .+?5      ?? }?. ._?5      ?? -   5        $??border1??5   M   $??16??6   $	??680??6%   $
??Left=?62   $??-200,0q?6\   ??5      ?? 5        ?? EndPoint$ 1,0.5&?6.    ?? 
StartPoint$ 0,0.5&?6?   .??5!      ?  ? Color$
 #ddd??6+    ? Offset$ 0Q?68   ? 5"      $ #f7f9fa??6+   $ 0Q?6;   ? 5#      $
 #ddd??6+   $ 1Q?68   5$      5&      5'      ?? 5(      }?. ._?5*      ?? -   5        $??border2??5*   5   $??16??6   $??-200,6q?6%   ??5+      ?? 5,      $ 1,0.5&?6.   $ 0,0.5&?6?   .??5-      ? $
 #ddd??6+   $ 0Q?68   ? 5.      $ #f7f9fa??6+   $ 0Q?6;   ? 5/      $
 #ddd??6+   $ 1Q?68   50      52      53      ?? 54      }?. ._?56      ?? -   5        $??border3??56   ]   $??16??6   $	??580??6%   $??-200,0q?61   $
??Left=?6B   ??57      ?? 58      $ 1,0.5&?6.   $ 0,0.5&?6?   .??59      ? $
 #ddd??6+   $ 0Q?68   ? 5:      $ #f7f9fa??6+   $ 0Q?6;   ? 5;      $
 #ddd??6+   $ 1Q?68   5<      5>      5?      5@      5A      5B      