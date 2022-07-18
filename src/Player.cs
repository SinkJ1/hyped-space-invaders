using Godot;

public class Player : Node2D
{
    [Export]
    private NodePath _shipPath;
    private IShip _ship;

    public override void _Ready()
    {
        _ship = GetNode<IShip>(_shipPath);
    }

    public override void _Process(float delta)
    {
        if (Input.IsActionPressed("ui_left"))
        {
            _ship.Move(Vector2.Left, 100);
        }

        if (Input.IsActionPressed("ui_space"))
        {
            _ship.Shoot();
        }
    }
}
