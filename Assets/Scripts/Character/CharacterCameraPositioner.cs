using UnityEngine;

public class CharacterCameraPositioner : MonoBehaviour
{
    [SerializeField] private Camera _followingCamera;
    [SerializeField] private float _backDistance;
    [SerializeField] private float _upDistance;

    private void Update()
    {
        PositionCamera();
        _followingCamera.transform.LookAt(transform.position + new Vector3(0, 1.5f, 0));
    }

    private void PositionCamera()
    {
        _followingCamera.transform.position = GetCameraPosition();
    }

    private Vector3 GetCameraPosition()
    {
        Vector3 back = transform.position + -transform.forward * _backDistance;
        back.y += _upDistance;
        return back;
    }
}