using UnityEngine;

public class CameraStartPoint : MonoBehaviour, ICameraFollowed
{
    public Vector3 Position => transform.position;
    public Vector3 LookOffset => new Vector3(0, 1.5f, 0);
    public Transform Transform => _character;

    private Transform _character;

    private void Awake()
    {
        _character = FindObjectOfType<Character>().transform;
        SetAsCameraFollowed();
    }

    public void SetAsCameraFollowed()
    {
        CameraFollower.Instance.Followed = this;
    }
}