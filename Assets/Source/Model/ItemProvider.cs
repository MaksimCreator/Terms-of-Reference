using UnityEngine;
using Zenject;

public class ItemProvider
{
    private readonly Character _character;
    private readonly CharacterConfig _config;
    private readonly ItemRegistry _registry;

    [Inject]
    public ItemProvider(Character character, CharacterConfig config,ItemRegistry itemRegistry)
    {
        _character = character;
        _config = config;
        _registry = itemRegistry;
    }

    public bool TryGetItem(out Item item)
    {
        item = null;

        if (Physics.Raycast(_character.Ray, out RaycastHit hit, _config.LengchRaycast))
        {
            if(hit.collider.gameObject.TryGetComponent(out ItemView itemView))
                _registry.TryGetItem(out item,itemView);
        }

        if (item == null)
            return false;
        else
            return true;
    }
}