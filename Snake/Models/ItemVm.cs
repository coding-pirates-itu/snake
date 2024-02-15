using System.Collections.ObjectModel;
using System.Windows;

namespace Snake.Models;


public abstract class ItemVm : DependencyObject
{
    #region Coordinates dependency property

    public static readonly DependencyProperty CoordinatesProperty = DependencyProperty.Register(
        nameof(Coordinates), typeof(ObservableCollection<Coordinate>), typeof(ItemVm),
        new PropertyMetadata(null));


    public ObservableCollection<Coordinate> Coordinates
    {
        get => (ObservableCollection<Coordinate>) GetValue(CoordinatesProperty);
        set => SetValue(CoordinatesProperty, value);
    }

    #endregion


    #region Init and clean-up

    public ItemVm(int x, int y)
    {
        Coordinates = [];
        Coordinates.Add(new Coordinate(x, y));
    }

    #endregion


    #region API

    /// <summary>
    /// Check whether the given coordinate is "inside" the object.
    /// </summary>
    public bool Overlaps(int x, int y) => Coordinates.Contains(new Coordinate(x, y));

    #endregion
}
