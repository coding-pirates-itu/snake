namespace Snake.Models;


public sealed class SnakeVm : ItemVm
{
    public List<Coordinate> Coordinates = [];


    public SnakeVm(int x, int y, int length, Directions dir) : base(x, y)
    {
        while (length > 0)
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


    /// <summary>
    /// Check whether the given coordinate is "inside" the object.
    /// </summary>
    public bool Overlaps(int x, int y) => Coordinates.Contains(new Coordinate(x, y));
}
