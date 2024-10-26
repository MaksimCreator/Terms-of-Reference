using UnityEngine;
using Zenject;

public class ItemViewFactory : MonoBehaviour
{
    [SerializeField] private ItemView _item;

    private PointsSpawnItem _itemPoints;
    private ItemRegistry _itemRegistry;

    [Inject]
    private void Construct(PointsSpawnItem pointsSpawnItem, ItemRegistry itemRegistry)
    {
        _itemPoints = pointsSpawnItem;
        _itemRegistry = itemRegistry;
    }

    public void Creat(Item item)
    {
        ItemView model = Instantiate(_item, _itemPoints.GetRandomPosition(), Quaternion.identity);
        _itemRegistry.AddPair(model, item);
    }
}