using System.Windows;
using System.Windows.Controls;
using Snake.Models;

namespace Snake.Views;


public sealed class FieldItemTemplateSelector : DataTemplateSelector
{
    public DataTemplate? Food { get; set; }

    public DataTemplate? Wall { get; set; }

    public DataTemplate? Snake { get; set; }


    public override DataTemplate? SelectTemplate(object item, DependencyObject container) => item switch
    {
        FoodItemVm => Food,
        WallItemVm => Wall,
        SnakePieceVm => Snake,
        _ => null,
    };
}
