
namespace Snake.Models;


public sealed class SnakeVm : ItemVm
{
    public SnakeVm(int x, int y, int length, Directions dir) : base(x, y)
    {
        while (length > 1)
        {
            switch (dir)
            {
                case Directions.North: y--; break;
                case Directions.South: y++; break;
                case Directions.West: x--; break;
                case Directions.East: x++; break;
                default: throw new ArgumentException($"Wrong direction {dir}.");
            }

            Coordinates.Add(new Coordinate(x, y));
            length--;
        }
    }
}
