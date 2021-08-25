using UnityEngine;

public class CharacterCameraPositioner : MonoBehaviour
{
    [SerializeField] private Transform _followingCamera;
    [SerializeField] private float _backDistance;
    [SerializeField] private float _upDistance;

    private void Awake()
    {
        
    }

    public void PositionCamera()
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