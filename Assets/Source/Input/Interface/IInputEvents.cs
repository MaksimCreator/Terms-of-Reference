using System;
using UnityEngine;

public interface IInputEvents
{
    event Action<Vector2,float> onMove;
    event Action<Vector2,float> onRotate;
    event Action onThromItem;
    event Action onPuckUpItem;
}
