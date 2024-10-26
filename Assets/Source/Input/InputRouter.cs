using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputRouter : IInputEvents,IInputControl,IInputUpdateble
{
    private readonly CharacterInput _inputActions = new();

    public event Action<Vector2,float> onMove;
    public event Action<Vector2,float> onRotate;
    public event Action onThromItem;
    public event Action onPuckUpItem;

    public void Disable()
    {
        _inputActions.Disable();

        _inputActions.Character.Throw.performed -= onThrow;
        _inputActions.Character.PuckUp.performed -= onPuckUp;
    }

    public void Enable()
    {
        _inputActions.Enable();

        _inputActions.Character.Throw.performed += onThrow;
        _inputActions.Character.PuckUp.performed += onPuckUp;
    }

    public void Update(float delta)
    {
        if (delta <= 0)
            throw new InvalidOperationException(nameof(delta));

        Vector2 direction = _inputActions.Character.Move.ReadValue<Vector2>();
        Vector2 rotation = _inputActions.Character.Rotation.ReadValue<Vector2>();

        if (direction != Vector2.zero)
            onMove.Invoke(direction, delta);

        if(rotation != Vector2.zero)
            onRotate.Invoke(rotation, delta);
    }

    private void onThrow(InputAction.CallbackContext obj)
    => onThromItem.Invoke();

    private void onPuckUp(InputAction.CallbackContext obj)
    => onPuckUpItem.Invoke();
}
