using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _followed;
    [SerializeField] private Vector3 _offset;

    private void LateUpdate()
    {
        if (HasTarget())
        {
            MoveToTarget();
        }
    }

    private bool HasTarget()
    {
        return _followed != null;
    }

    public void MoveToTarget()
    {
        transform.position = GetAdjustedPosition();
    }

    private Vector3 GetAdjustedPosition()
    {
        return _followed.position + _offset;
    } 
}