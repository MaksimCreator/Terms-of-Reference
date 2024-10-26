using UnityEngine;

[CreateAssetMenu(menuName = "Conffig/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private float _sensitivity;
    [SerializeField] private float _throwPower;
    [SerializeField] private float _rotation;
    [SerializeField] private float _lengchRaycast;

    public float Speed => _speed;

    public float ThrowPower => _throwPower;

    public float Sensitivity => _sensitivity;

    public float Rotation => _rotation;

    public float LengchRaycast => _lengchRaycast;
}