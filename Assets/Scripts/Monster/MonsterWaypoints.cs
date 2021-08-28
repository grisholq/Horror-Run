using UnityEngine;

public class MonsterWaypoints : MonoBehaviour
{
    [SerializeField] private Transform[] _waypointsTransforms;
    [SerializeField] private bool _loop;
    public Vector3 Current => _waypoints[_waypointIndex];

    private Vector3[] _waypoints;
    private int _waypointIndex;

    private void Awake()
    {
        InizializeWaypoints();       
    }

    private void InizializeWaypoints()
    {
        _waypointIndex = 0;
        _waypoints = new Vector3[_waypointsTransforms.Length];

        for (int i = 0; i < _waypoints.Length; i++)
        {
            _waypoints[i] = _waypointsTransforms[i].position;
        }
    }

    public void NextWaypoint()
    {
        _waypointIndex++;

        if (_waypoints.Length <= _waypointIndex)
        {
            if (_loop) _waypointIndex = 0;
            else _waypointIndex--;
        }
    }
}