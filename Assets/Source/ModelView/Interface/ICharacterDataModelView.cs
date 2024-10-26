using UnityEngine;

public interface ICharacterDataModelView
{
    Vector3 Position { get; }

    Ray Ray { get; }
}
