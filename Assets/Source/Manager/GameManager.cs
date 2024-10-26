using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    private IControl _control;
    private IDeltaUpdateble _deltaUpdateble;

    [Inject]
    private void Construct(PlayerController playerController)
    {
        _control = playerController;
        _deltaUpdateble = playerController;
    }

    private void Update()
    => _deltaUpdateble.Update(Time.deltaTime);

    private void OnEnable()
    => _control.Enable();

    private void OnDisable()
    => _control.Disable();
}
