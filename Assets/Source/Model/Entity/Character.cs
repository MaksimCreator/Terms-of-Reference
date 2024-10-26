using UnityEngine;
using Zenject;

public class Character : Entity
{
    private ICharacterDataModelView _characterDataModelView;

    [Inject]
    public Character(ICharacterDataModelView characterDataModelView)
    {
        _characterDataModelView = characterDataModelView;
    }

    public Vector3 Position => _characterDataModelView.Position;

    public Ray Ray => _characterDataModelView.Ray;
}
