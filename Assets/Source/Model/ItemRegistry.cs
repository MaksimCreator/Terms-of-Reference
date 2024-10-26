using System.Collections.Generic;

public class ItemRegistry
{
    private readonly Dictionary<Item,ItemView> _pairItemItemView = new Dictionary<Item, ItemView> ();
    private readonly Dictionary<ItemView, Item> _pairItemViewItem = new Dictionary<ItemView, Item>();

    public void AddPair(ItemView gameObject,Item item)
    {
        _pairItemViewItem.Add(gameObject, item);
        _pairItemItemView.Add(item, gameObject);
    }

    public bool TryGetItem(out Item item, ItemView itemView)
    {
        item = null;

        if (_pairItemViewItem.ContainsKey(itemView))
        {
            item = _pairItemViewItem[itemView];
            return true;
        }

        return false;
    }

    public bool TryGetItemView(out ItemView itemView,Item item)
    {
        itemView = null;

        if (_pairItemItemView.ContainsKey(item))
        {
            itemView = _pairItemItemView[item];
            return true;
        }

        return false;
    }
}