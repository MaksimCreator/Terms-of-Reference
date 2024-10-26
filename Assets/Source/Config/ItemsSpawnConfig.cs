using UnityEngine;

[CreateAssetMenu(menuName = "Conffig/ItemsSpawnConfig")]
public class ItemsSpawnConfig : ScriptableObject
{
    [SerializeField] private int _countCylinder;

    public int CountCylinder => _countCylinder;
}
