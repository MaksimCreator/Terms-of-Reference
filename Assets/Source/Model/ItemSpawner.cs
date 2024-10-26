using Zenject;

public class ItemSpawner
{
    private readonly int _countCylinder;
    private readonly ItemViewFactory _factory;

    [Inject]
    public ItemSpawner(ItemsSpawnConfig itemsConfig,ItemViewFactory itemViewFactory)
    {
        _countCylinder = itemsConfig.CountCylinder;
        _factory = itemViewFactory;
    }

    public void CreatAll()
    {
        for (int i = 0; i < _countCylinder; i++)
            _factory.Creat(new Item());
    }
}
