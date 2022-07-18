using Godot;

public interface IShip
{
    void Shoot();
    
    void Move(Vector2 dir, float maxSpeed);
}

public class Ship : KinematicBody2D, IShip
{
    public void Shoot()
    {
        throw new System.NotImplementedException();
    }

    public void Move(Vector2 dir, float maxSpeed)
    {
        MoveAndSlide(dir * maxSpeed);
    }
}
