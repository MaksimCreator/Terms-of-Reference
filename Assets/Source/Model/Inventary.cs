using System;

public class Inventary
{
    private Item _item;

    public event Action<Item> Throw;
    public event Action<Item> Take;
    public event Action<Item> Release;

    public void SwithItem(Item item)
    {
        if (_item != null)
            Release.Invoke(_item);

        Take.Invoke(item);
        _item = item;
    }

    public void ThrowItem()
    {
        Throw.Invoke(_item);
        _item = null;
    }
}
