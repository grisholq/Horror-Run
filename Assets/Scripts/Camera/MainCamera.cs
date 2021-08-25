using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Transform _character;
    [SerializeField] private Vector3 _characterLookOffset;

    [SerializeField] private Transform _boss;
    [SerializeField] private Vector3 _bossLookOffset;

    private Camera _camera;
    public Camera Camera => _camera;

    private Transform _lookTarget;
    private Vector3 _lookOffset;

    private void Awake()
    {
        _camera = GetComponent<Camera>();

        LookAtCharacter();
    }

    private void LateUpdate()
    {
        if (_lookTarget == null) return;
        transform.LookAt(_lookTarget.position + _lookOffset);
    }

    public void LookAtCharacter()
    {
        _lookTarget = _character;
        _lookOffset = _characterLookOffset;
    }

    public void LookAtBoss()
    {
        _lookTarget = _boss;
        _lookOffset = _bossLookOffset;
    }
}