using UnityEngine;

public class CharacterPoints
{
    public Transform ItemPoint { get; private set; }

    public void Init(Transform itemPoint)
    {
        ItemPoint = itemPoint;
    }
}