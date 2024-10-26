using UnityEngine;
using System;

public class EntityViewFactory : TranformableViewFactory<Entity>
{
    [SerializeField] private EntityView _character;

    protected override EntityView GetTemplate(Entity entity)
    {
        if (entity is Character)
            return _character;
        throw new InvalidOperationException();
    }
}