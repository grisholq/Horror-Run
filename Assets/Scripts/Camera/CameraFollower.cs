using UnityEngine;

public class CameraFollower : Singleton<CameraFollower>, ICameraFollower
{
    [SerializeField] private float _followSpeed;
    public ICameraFollowed Followed { get; set; }

    private void LateUpdate()
    {
        if (Followed == null) return;

        transform.position = GetNextPosition();
        transform.LookAt(Followed.Transform.position + Followed.LookOffset);
    }

    private Vector3 GetNextPosition()
    {
        return Vector3.MoveTowards(transform.position, Followed.Position, Time.deltaTime * _followSpeed);
    }
}