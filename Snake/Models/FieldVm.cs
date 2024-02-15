using System.ComponentModel;
using System.Windows;

namespace Snake.Models;


public sealed class FieldVm : DependencyObject
{
    #region Width dependency property

    public static readonly DependencyProperty WidthProperty = DependencyProperty.
        Register(nameof(Width), typeof(int), typeof(FieldVm),
        new PropertyMetadata(20));


    public int Width
    {
        get => (int) GetValue(WidthProperty);
        set => SetValue(WidthProperty, value);
    }

    #endregion


    #region Height dependency property

    public static readonly DependencyProperty HeightProperty = DependencyProperty.
        Register(nameof(Height), typeof(int), typeof(FieldVm),
        new PropertyMetadata(20));


    public int Height
    {
        get => (int) GetValue(HeightProperty);
        set => SetValue(HeightProperty, value);
    }

    #endregion


    #region InitialLength dependency property

    public static readonly DependencyProperty InitialLengthProperty = DependencyProperty.
        Register(nameof(InitialLength), typeof(int), typeof(FieldVm),
        new PropertyMetadata(3));


    public int InitialLength
    {
        get => (int) GetValue(InitialLengthProperty);
        set => SetValue(InitialLengthProperty, value);
    }

    #endregion


    #region Items dependency property

    public static readonly DependencyProperty ItemsProperty = DependencyProperty.
        Register(nameof(Items), typeof(BindingList<ItemVm>), typeof(FieldVm),
        new PropertyMetadata(null));


    public BindingList<ItemVm> Items
    {
        get => (BindingList<ItemVm>) GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }

    #endregion


    #region Snake dependency property

    public static readonly DependencyProperty SnakeProperty = DependencyProperty.
        Register(nameof(Snake), typeof(SnakeVm), typeof(FieldVm),
        new PropertyMetadata(null));


    public SnakeVm Snake
    {
        get => (SnakeVm) GetValue(SnakeProperty);
        set => SetValue(SnakeProperty, value);
    }

    #endregion


    #region Points dependency property

    public static readonly DependencyProperty PointsProperty = DependencyProperty.
        Register(nameof(Points), typeof(int), typeof(FieldVm),
        new PropertyMetadata(0));


    public int Points
    {
        get => (int) GetValue(PointsProperty);
        set => SetValue(PointsProperty, value);
    }

    #endregion


    #region Init and clean-up

    public FieldVm()
    {
        Items = [];
    }

    #endregion


    #region API

    /// <summary>
    /// Start a new game.
    /// </summary>
    public void NewGame()
    {
        Points = 0;

        var dir = (Directions) Random.Shared.Next(0, 4);
        Snake = new SnakeVm(Width / 2, Height / 2, InitialLength, dir);

        Items.Clear();
        Items.Add(Snake);

        for (var i = 0; i < Width; i++)
        {
            int x, y;

            do
            {
                x = Random.Shared.Next(0, Width);
                y = Random.Shared.Next(0, Height);
            }
            while (Snake.Overlaps(x, y));

            Items.Add(new FoodItem(x, y));
        }
    }

    #endregion
}
