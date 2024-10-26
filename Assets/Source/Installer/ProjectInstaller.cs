using Zenject;
using UnityEngine;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private CharacterConfig _characterConfig;
    [SerializeField] private ItemsSpawnConfig _spawnConfig;

    public override void InstallBindings()
    {
        ConfigRegistry();
        InputRegistry();
    }

    public void InputRegistry()
    {
        InputRouter inputRouter = new InputRouter();

        Container
            .Bind<IInputEvents>()
            .To<InputRouter>()
            .FromInstance(inputRouter)
            .AsCached();

        Container
            .Bind<IInputControl>()
            .To<InputRouter>()
            .FromInstance(inputRouter)
            .AsCached();

        Container
           .Bind<IInputUpdateble>()
           .To<InputRouter>()
           .FromInstance(inputRouter)
           .AsCached();
    }

    # region ConfigRegistry

    private void ConfigRegistry()
    {
        CharacterConfigRegistry();
        ItemConfigRegistry();
    }

    private void CharacterConfigRegistry()
    {
        Container
            .Bind<CharacterConfig>()
            .FromInstance(_characterConfig)
            .AsSingle();
    }

    private void ItemConfigRegistry()
    {
        Container
            .Bind<ItemsSpawnConfig>()
            .FromInstance(_spawnConfig)
            .AsSingle();
    }

    #endregion
}