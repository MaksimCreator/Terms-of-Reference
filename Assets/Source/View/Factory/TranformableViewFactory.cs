using System.Linq;
using UnityEngine;
using Zenject;
using System;

public abstract class TranformableViewFactory<T> : MonoBehaviour where T : Entity
{
    private ICharacteInitializeModelView _characterModelView;
    private CharacterPoints _characterPoints;

    [Inject]
    private void Construct(ICharacteInitializeModelView modelView,CharacterPoints characterPoints)
    {
        _characterModelView = modelView;
        _characterPoints = characterPoints;
    }

    public void Create(T entity,Vector3 startPosition,Vector3 rotation)
    {
        EntityView view = Instantiate(GetTemplate(entity), startPosition, Quaternion.Euler(rotation));

        if (view.gameObject.TryGetComponent(out CharacterController characterController))
        {
            if (entity is Character)
            {
                Camera characterCamera = view.gameObject.GetComponentInChildren<Camera>();
                Transform pointSpawnItem = view.gameObject.GetComponentsInChildren<Transform>()
                    .First(transform => transform.gameObject.layer == Config.LayerItemPointCharacter);

                view.Init(entity, characterController, characterCamera);
                _characterModelView.Init(characterController.transform,characterCamera);
                _characterPoints.Init(pointSpawnItem);
            }
            else
            {
                view.Init(entity, characterController);
            }
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    protected abstract EntityView GetTemplate(T entity);
}