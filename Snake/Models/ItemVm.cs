using System.Collections.ObjectModel;
using System.Windows;

namespace Snake.Models;


public abstract class ItemVm : DependencyObject
{
    #region Point dependency property

    public static readonly DependencyProperty PointProperty = DependencyProperty.Register(
        nameof(Point), typeof(Coordinate), typeof(ItemVm),
        new PropertyMetadata(default(Coordinate)));


    public Coordinate Point
    {
        get => (Coordinate) GetValue(PointProperty);
        set => SetValue(PointProperty, value);
    }

    #endregion


    #region Init and clean-up

    public ItemVm(int x, int y)
    {
        Point = new Coordinate(x, y);
    }

    #endregion
}
