using UnityEngine;

public class CharacterCameraFollowed : MonoBehaviour, ICameraFollowed
{
    [SerializeField] private float _backDistance;
    [SerializeField] private float _upDistance;

    public Vector3 Position => GetCameraPosition();
    public Vector3 LookOffset => new Vector3(0, 1.5f, 0);
    public Transform Transform => transform;

    private Vector3 GetCameraPosition()
    {
        Vector3 back = transform.position + -transform.forward * _backDistance;
        back.y += _upDistance;
        return back;
    }

    public void SetAsCameraFollowed()
    {
        CameraFollower.Instance.Followed = this;
    }
}