using UnityEngine;

public class BossCameraFollowed : MonoBehaviour, ICameraFollowed
{
    public Vector3 Position => transform.position + new Vector3(0, 2, -13);
    public Vector3 LookOffset => new Vector3(0, 3, 0);
    public Transform Transform => transform;

    public void SetAsCameraFollowed()
    {
        CameraFollower.Instance.Followed = this;
    }

    public void ResetAsCameraFollower()
    {
        CameraFollower.Instance.Followed = null;
    }
}