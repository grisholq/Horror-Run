using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _stopChaseDistance;

    public Transform Target { get; set; }
    public bool IsChasing { get; set; }

    private Vector3 _movementDirection;

    private void Awake()
    {
        IsChasing = false;
    }

    private void Update()
    {
        if(IsChasing)
        {
            MoveToTarget();
            LookAtTarget();

            if (IsNearbyTarget())
            {
                StopChasing();
            }
        }
        else
        {
            MoveInDirection();
        }
    }

    private void MoveToTarget()
    {
        transform.position = GetNextPosition();
    }

    private Vector3 GetNextPosition()
    {
        Vector3 newPosition = Vector3.MoveTowards(transform.position, Target.position, Time.deltaTime * _speed);
        newPosition.y = transform.position.y;
        return newPosition;
    }

    private void LookAtTarget()
    {
        transform.LookAt(Target);
    }

    private bool IsNearbyTarget()
    {
        return Vector3.Distance(transform.position, Target.position) <= _stopChaseDistance;
    }

    private void StopChasing()
    {
        IsChasing = false;
        _movementDirection = (Target.position - transform.position).normalized;
    }

    private void MoveInDirection()
    {
        transform.position += _movementDirection * _speed * Time.deltaTime;
    }
}