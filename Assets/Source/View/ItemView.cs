using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ItemView : MonoBehaviour
{
    [SerializeField] private Rigidbody _itemRb;

    private Transform _item;

    private void Awake()
    {
        _item = _itemRb.GetComponent<Transform>();
    }

    public void Throw(Vector3 direction, float force)
    {
        DisableParent();
        _itemRb.AddForce(direction * force, ForceMode.Acceleration);
    }

    public void SetParent(Transform parent)
    {
        _item.position = parent.position;
        _item.parent = parent;
        _itemRb.isKinematic = true;
    }

    public void DisableParent()
    { 
        _item.parent = null;
        _itemRb.isKinematic = false;
    }

    private void OnValidate()
    => _itemRb ??= GetComponent<Rigidbody>();
}