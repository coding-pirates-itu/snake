using System.Windows;
using System.Windows.Controls;

namespace Snake.Views;


public sealed class FieldView : ItemsControl
{
    #region FieldWidth dependency property

    public static readonly DependencyProperty FieldWidthProperty = DependencyProperty.
        Register(nameof(FieldWidth), typeof(int), typeof(FieldView),
        new PropertyMetadata(20, SizeParameterChanged));


    public int FieldWidth
    {
        get => (int) GetValue(FieldWidthProperty);
        set => SetValue(FieldWidthProperty, value);
    }

    #endregion


    #region CellWidth dependency property

    public static readonly DependencyProperty CellWidthProperty = DependencyProperty.
        Register(nameof(CellWidth), typeof(int), typeof(FieldView),
        new PropertyMetadata(20));


    public int CellWidth
    {
        get => (int) GetValue(CellWidthProperty);
        set => SetValue(CellWidthProperty, value);
    }

    #endregion


    #region FieldHeight dependency property

    public static readonly DependencyProperty FieldHeightProperty = DependencyProperty.
        Register(nameof(FieldHeight), typeof(int), typeof(FieldView),
        new PropertyMetadata(20));


    public int FieldHeight
    {
        get => (int) GetValue(FieldHeightProperty);
        set => SetValue(FieldHeightProperty, value);
    }

    #endregion


    #region CellHeight dependency property

    public static readonly DependencyProperty CellHeightProperty = DependencyProperty.
        Register(nameof(CellHeight), typeof(int), typeof(FieldView),
        new PropertyMetadata(20));


    public int CellHeight
    {
        get => (int) GetValue(CellHeightProperty);
        set => SetValue(CellHeightProperty, value);
    }

    #endregion


    #region Init and clean-up

    public FieldView()
    {
        SizeParameterChanged(this, default);
    }

    #endregion


    #region Utility

    private static void SizeParameterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var self = (FieldView)d;
        self.Width = self.CellWidth * self.FieldWidth;
        self.Height = self.CellHeight * self.FieldHeight;
    }

    #endregion
}
