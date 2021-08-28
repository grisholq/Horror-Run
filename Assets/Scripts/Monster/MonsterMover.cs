using UnityEngine;

public class MonsterMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _reachDistance;

    private MonsterWaypoints _waypoints;

    private void Awake()
    {
        _waypoints = GetComponentInChildren<MonsterWaypoints>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _waypoints.Current, Time.deltaTime * _speed);
        transform.LookAt(_waypoints.Current, Vector3.up);

        if(ReachedWaypoint())
        {
            _waypoints.NextWaypoint();
        }
    }

    private bool ReachedWaypoint()
    {
        return Vector3.Distance(transform.position, _waypoints.Current) <= _reachDistance;
    }
}