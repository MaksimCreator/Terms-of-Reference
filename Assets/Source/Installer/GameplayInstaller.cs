using Zenject;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private EntityViewFactory _entityViewFactory;
    [SerializeField] private ItemViewFactory _itemViewFactory;
    [SerializeField] private GameObject _rootWorld;

    private List<Vector3> _pointsSpawnItem
    => _rootWorld.GetComponentsInChildren<Transform>()
            .Where(point => point.gameObject.layer == Config.LayerItemPointMap).ToArray()
            .Select(point => point.position).ToList();

    public override void InstallBindings()
    {
        RegistryFactory();
        RegistrySpawner();
        RegistryService();
        RegistryCatalog();
        RegistryProvider();
        RegistryMovement();
        RegistryCharacter();
        RegistaryInventary();
        RegistryPlayerController();
        RegistryCharacterModelView();
    }

    private void RegistaryInventary()
    {
        Container
            .Bind<Inventary>()
            .FromNew()
            .AsSingle();
    }

    private void RegistryCatalog()
    {
        Container
            .Bind<ItemRegistry>()
            .FromNew()
            .AsSingle();
    }

    private void RegistryProvider()
    {
        Container
            .Bind<ItemProvider>()
            .FromNew()
            .AsSingle();
    }

    private void RegistrySpawner()
    {
        Container
            .Bind<ItemSpawner>()
            .FromNew()
            .AsSingle();
    }

    private void RegistryPlayerController()
    {
        Container
            .Bind<PlayerController>()
            .FromNew()
            .AsSingle();
    }

    private void RegistryCharacterModelView()
    {
        CharacterModelView characterModelView = new CharacterModelView();

        Container
            .Bind<ICharacteInitializeModelView>()
            .To<CharacterModelView>()
            .FromInstance(characterModelView)
            .AsCached();

        Container
            .Bind<ICharacterDataModelView>()
            .To<CharacterModelView>()
            .FromInstance(characterModelView)
            .AsCached();
    }

    private void RegistryCharacter()
    {
        Container
            .Bind<Character>()
            .FromNew()
            .AsSingle();
    }

    private void RegistryMovement()
    {
        Container
            .Bind<CharacterMovement>()
            .FromNew()
            .AsSingle();
    }
    
    #region Service

    private void RegistryService()
    {
        RegistryPointsItem();
        RegistryCharacterPoint();

    }

    private void RegistryPointsItem()
    {
        PointsSpawnItem pointsSpawnItem = new PointsSpawnItem(_pointsSpawnItem);

        Container
            .Bind<PointsSpawnItem>()
            .FromInstance(pointsSpawnItem)
            .AsSingle();
    }

    private void RegistryCharacterPoint()
    {
        CharacterPoints characterPoints = new CharacterPoints();

        Container
            .Bind<CharacterPoints>()
            .FromInstance(characterPoints)
            .AsSingle();
    }

    #endregion

    #region RegistaryFactory

    private void RegistryFactory()
    {
        RegistryEntityFactory();
        RegistryItemViewFactory();
    }

    private void RegistryEntityFactory()
    {
        Container
            .Bind<EntityViewFactory>()
            .FromInstance(_entityViewFactory)
            .AsSingle();
    }

    private void RegistryItemViewFactory()
    {
        Container
            .Bind<ItemViewFactory>()
            .FromInstance(_itemViewFactory)
            .AsSingle();
    }

    #endregion
}