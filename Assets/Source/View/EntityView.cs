using UnityEngine;

public class EntityView : MonoBehaviour
{
    private CharacterController _characterController;
    private Entity _model;
    private Transform _camera;

    public void Init(Entity entity, CharacterController characterController,Camera camera = null)
    {
        _model = entity;
        _characterController = characterController;
        _camera = camera != null ? camera.transform : null;
    }

    private void LateUpdate()
    {
        Vector2 modelDirection = _model.GetWay();
        Vector2 modelRotation = _model.GetRotation();

        Vector3 direction = Vector3.right * modelDirection.x + Vector3.forward * modelDirection.y;

        Move(transform.TransformDirection(direction));
        Rotate(modelRotation);
    }

    private void Move(Vector3 direction)
    {
        if (direction == Vector3.zero || _characterController == null)
            return;

        _characterController.Move(direction);
    }

    private void Rotate(Vector2 rotation)
    {
        if (rotation == Vector2.zero)
            return;

        if (_camera != null)
            _camera.Rotate(Vector3.right * rotation.y);

        transform.Rotate(Vector3.up * rotation.x);
    }
}