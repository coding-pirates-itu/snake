using System.Collections.ObjectModel;
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
        Register(nameof(Items), typeof(ObservableCollection<ItemVm>), typeof(FieldVm),
        new PropertyMetadata(null));


    public ObservableCollection<ItemVm> Items
    {
        get => (ObservableCollection<ItemVm>) GetValue(ItemsProperty);
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

        var dir = (Directions) Random.Shared.Next(1, 5);
        Snake = new SnakeVm(Width / 2, Height / 2, InitialLength, dir);

        Items.Clear();
        MergeSnake(SetupSnake());

        for (var i = 0; i < Width; i++)
        {
            int x, y;

            do
            {
                x = Random.Shared.Next(0, Width);
                y = Random.Shared.Next(0, Height);
            }
            while (Snake.Overlaps(x, y));

            Items.Add(new FoodItemVm(x, y));
        }
    }

    #endregion


    #region Utility

    private List<SnakePieceVm> SetupSnake()
    {
        var pieces = new List<SnakePieceVm>();

        for (var pieceIdx = 0; pieceIdx < Snake.Coordinates.Count; pieceIdx++)
        {
            var coord = Snake.Coordinates[pieceIdx];

            var headDir = Directions.End;

            if (pieceIdx < Snake.Coordinates.Count - 1)
            {
                var next = Snake.Coordinates[pieceIdx + 1];
                headDir = Math.Sign(coord.Y - next.Y) * 4 + Math.Sign(coord.X - next.X) switch
                {
                    4 => Directions.North,
                    -4 => Directions.South,
                    -1 => Directions.West,
                    1 => Directions.East,
                    _ => Directions.End
                };
            }

            var tailDir = Directions.End;

            if (pieceIdx > 0)
            {
                var prev = Snake.Coordinates[pieceIdx - 1];
                tailDir = Math.Sign(coord.Y - prev.Y) * 4 + Math.Sign(coord.X - prev.X) switch
                {
                    4 => Directions.North,
                    -4 => Directions.South,
                    -1 => Directions.West,
                    1 => Directions.East,
                    _ => Directions.End
                };
            }

            pieces.Add(new SnakePieceVm(coord.X, coord.Y, headDir, tailDir));
        }

        return pieces;
    }


    private void MergeSnake(List<SnakePieceVm> snake)
    {
        var field = Items.OfType<SnakePieceVm>().ToList();

        // Delete gone pieces
        foreach (var onField in field)
        {
            var inSnake = snake.Any(
                p => p.Point == onField.Point &&
                     p.HeadDirection == onField.HeadDirection &&
                     p.TailDirection == onField.TailDirection);
            
            if (!inSnake)
            {
                Items.Remove(onField);
            }
        }

        // Add new pieces
        foreach (var onSnake in snake)
        {
            var onField = field.Any(
                p => p.Point == onSnake.Point &&
                     p.HeadDirection == onSnake.HeadDirection &&
                     p.TailDirection == onSnake.TailDirection);
            
            if (!onField)
            {
                Items.Add(onSnake);
            }
        }
    }

    #endregion
}
