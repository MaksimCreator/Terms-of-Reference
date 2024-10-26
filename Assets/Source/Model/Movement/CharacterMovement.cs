using System;
using Zenject;
using UnityEngine;

public class CharacterMovement
{
    private readonly CharacterConfig _config;
    private readonly Character _character;

    [Inject]
    public CharacterMovement(CharacterConfig config, Character character)
    {
        _config = config;
        _character = character;
    }

    public void Move(Vector2 direction,float delta)
    {
        if (delta <= 0)
            throw new InvalidOperationException(nameof(delta));

        if (direction == Vector2.zero)
            return;

        _character.Move(direction * delta * _config.Speed);
    }

    public void Rotate(Vector2 direction, float delta)
    {
        if (delta <= 0)
            throw new InvalidOperationException(nameof(delta));

        if (direction == Vector2.zero)
            return;

        _character.Rotate(direction * delta * _config.Sensitivity);
    }
}