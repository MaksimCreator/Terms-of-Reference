using UnityEngine;

public class Entity
{
    private Vector2 _way;
    private Vector2 _rotation;

    public void Move(Vector2 direction)
    => _way += direction;

    public void Rotate(Vector2 deltaRotation)
    {
        deltaRotation.y *= -1;
        _rotation += deltaRotation;
    }

    public Vector2 GetWay()
    {
        Vector2 direction = _way;
        _way = Vector2.zero;
        return direction;
    }

    public Vector2 GetRotation()
    {
        Vector2 rotation = _rotation;
        _rotation = Vector2.zero;
        return rotation;
    }
}