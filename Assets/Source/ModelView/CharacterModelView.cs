using UnityEngine;

public class CharacterModelView : ICharacteInitializeModelView,ICharacterDataModelView
{
    private Transform _characterTransform;
    private Camera _characterCamera;

    public Vector3 Position => _characterTransform.position;

    public Ray Ray => _characterCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

    public void Init(Transform characterTransform, Camera camera)
    {
        _characterTransform = characterTransform;
        _characterCamera = camera;
    }
}