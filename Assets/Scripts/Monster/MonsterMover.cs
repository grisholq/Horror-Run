using UnityEngine;

public class MonsterMover : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }
}