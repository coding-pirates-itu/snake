namespace Snake.Models;


public sealed class SnakePieceVm(int x, int y, Directions head, Directions tail) : ItemVm(x, y)
{
    public Directions HeadDirection { get; } = head;

    public Directions TailDirection { get; } = tail;
}
