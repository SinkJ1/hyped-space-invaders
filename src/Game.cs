using Godot;

public interface IShip
{
    void Shoot();

    Vector2 Moved(Vector2 velocity);
}


public interface IBullets
{
    void Spawn(Vector2 position, Vector2 speed);
}

public class Ship : IShip
{
    private readonly KinematicBody2D _kinematicBody;
    private readonly IBullets _bullets;

    public Ship(KinematicBody2D kinematicBody, IBullets bullets)
    {
        _kinematicBody = kinematicBody;
        _bullets = bullets;
    }

    public void Shoot()
    {
        _bullets.Spawn(_kinematicBody.Position, Vector2.Down * 100);
    }

    public Vector2 Moved(Vector2 velocity)
    {
        return _kinematicBody.MoveAndSlide(velocity);
    }
}


public class Bullets : IBullets
{
    private readonly Node _bullets;

    public Bullets(Node bullets)
    {
        _bullets = bullets;
    }

    public void Spawn(Vector2 position, Vector2 speed)
    {
        throw new System.NotImplementedException();
    }
}


public interface IPlayer
{
    void UpdateControls(float delta);
}

public class Player : IPlayer
{
    private readonly IShip _ship;

    public Player(IShip ship)
    {
        _ship = ship;
    }

    public void UpdateControls(float delta)
    {
        var velocity = new Vector2();
        
        if (Input.IsActionPressed("ui_left"))
        {
            velocity += Vector2.Left;
        }
        if (Input.IsActionPressed("ui_right"))
        {
            velocity += Vector2.Right;
        }

        _ship.Moved(velocity * 300);
    }
}

public class Game : Node2D
{
    private IShip _ship;
    private IPlayer _player;

    public override void _Ready()
    {
        _ship = new Ship(
            GetNode<KinematicBody2D>("Ship"),
            new Bullets(GetNode<Node>("Bullets"))
        );

        _player = new Player(_ship);
    }

    public override void _Process(float delta)
    {
        _player.UpdateControls(delta);
    }
}