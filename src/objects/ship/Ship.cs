using Godot;

public interface IShip
{
    void Shoot();
    
    void Move(Vector2 dir, float maxSpeed);
}

public interface IProjectile
{
    
}

public interface IProjectiles
{
    IProjectile Spawn(Vector2 position);
}

public class Ship : KinematicBody2D, IShip
{
    [Export]
    private NodePath _projectilesPath;
    private IProjectiles _projectiles;

    public override void _Ready()
    {
        _projectiles = GetNode<IProjectiles>(_projectilesPath);
    }

    public void Shoot()
    {
        _projectiles.Spawn(Position);
    }

    public void Move(Vector2 dir, float maxSpeed)
    {
        MoveAndSlide(dir * maxSpeed);
    }
}
