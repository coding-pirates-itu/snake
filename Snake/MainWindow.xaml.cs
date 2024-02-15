using System.Windows;
using Snake.Models;
using Snake.Views;

namespace Snake;


/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    #region Model dependency property

    public static readonly DependencyProperty ModelProperty = DependencyProperty.
        Register(nameof(Model), typeof(FieldVm), typeof(FieldView),
        new PropertyMetadata(null));


    public FieldVm Model
    {
        get => (FieldVm) GetValue(ModelProperty);
        set => SetValue(ModelProperty, value);
    }

    #endregion


    public MainWindow()
    {
        Model = new FieldVm();
        InitializeComponent();
        Model.NewGame();
    }


    private void NewGameButtonClick(object sender, RoutedEventArgs e)
    {
        Model.NewGame();
    }
}
