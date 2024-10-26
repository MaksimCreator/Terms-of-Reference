using Zenject;
using System;

public class PlayerController : IControl,IDeltaUpdateble
{
    private readonly IInputControl _inputControl;
    private readonly IInputEvents _inputEvents;
    private readonly IInputUpdateble _inputUpdateble;
    private readonly CharacterMovement _characterMovement;
    private readonly ItemProvider _itemProvider;
    private readonly CharacterPoints _characterPoints;
    private readonly Inventary _inventary;
    private readonly ItemRegistry _itemRegistry;
    private readonly CharacterConfig _characterConfig;
    private readonly Character _character;

    [Inject]
    public PlayerController(IInputEvents inputEvents,
        IInputControl inputControl,
        IInputUpdateble inputUpdateble,
        CharacterMovement characterMovement,
        ItemProvider itemProvider,
        CharacterPoints characterPoints,
        Inventary inventary,
        ItemRegistry itemRegistry,
        CharacterConfig characterConfig,
        Character character)
    {
        _characterMovement = characterMovement;
        _inputUpdateble = inputUpdateble;
        _inputControl = inputControl;
        _inputEvents = inputEvents;
        _itemProvider = itemProvider;
        _characterPoints = characterPoints;
        _inventary = inventary;
        _itemRegistry = itemRegistry;
        _characterConfig = characterConfig;
        _character = character;
    }

    public void Disable()
    {
        _inputControl.Disable();

        _inputEvents.onMove -= _characterMovement.Move;
        _inputEvents.onRotate -= _characterMovement.Rotate;
        _inputEvents.onPuckUpItem -= PuckUpItem;
        _inputEvents.onThromItem -= _inventary.ThrowItem;

        _inventary.Throw -= ThrowItem;
        _inventary.Take -= TakeItem;
        _inventary.Release -= ReleaseItem;
    }

    public void Enable()
    {
        _inputControl.Enable();

        _inputEvents.onMove += _characterMovement.Move;
        _inputEvents.onRotate += _characterMovement.Rotate;
        _inputEvents.onPuckUpItem += PuckUpItem;
        _inputEvents.onThromItem += _inventary.ThrowItem;

        _inventary.Throw += ThrowItem;
        _inventary.Take += TakeItem;
        _inventary.Release += ReleaseItem;
    }

    public void Update(float delta)
    {
        _inputUpdateble.Update(delta);
    }

    private void PuckUpItem()
    {
        if (_itemProvider.TryGetItem(out Item item))
            _inventary.SwithItem(item);
    }

    private void ThrowItem(Item item)
    {
        ItemView itemView = GetItemView(item);
        itemView.Throw(_character.Ray.direction, _characterConfig.ThrowPower);
    }

    private void TakeItem(Item item)
    {
        ItemView itemView = GetItemView(item);
        itemView.SetParent(_characterPoints.ItemPoint);
    }

    private void ReleaseItem(Item item)
    {
        ItemView itemView = GetItemView(item);
        itemView.DisableParent();
    }

    private ItemView GetItemView(Item item)
    {
        if (_itemRegistry.TryGetItemView(out ItemView itemView, item) == false)
            throw new InvalidOperationException();

        return itemView;
    }
}