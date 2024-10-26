using UnityEngine;
using Zenject;

public class GameplayEntryPoint : MonoBehaviour
{
    [SerializeField] private Transform _pointSpawnCharacter;
    [SerializeField] private Transform _characterTransform;

    private Character _character;
    private EntityViewFactory _entityViewFactory;
    private ItemSpawner _spawner;

    private float _startRotation;

    [Inject]
    private void Construct(Character character,EntityViewFactory entityViewFactory,CharacterConfig characterConfig,ItemSpawner itemSpawner)
    {
        _character = character;
        _entityViewFactory = entityViewFactory;
        _spawner = itemSpawner;

        _startRotation = characterConfig.Rotation;
    }

    private Vector3 _position
    => new Vector3(_pointSpawnCharacter.position.x, _pointSpawnCharacter.position.y
        + _characterTransform.localScale.y / 2, _pointSpawnCharacter.position.z);

    private Vector3 _rotation
    => new Vector3(0, _startRotation, 0);

    private void Awake()
    {
        _entityViewFactory.Create(_character,_position,_rotation);
        _spawner.CreatAll();
    }
}
