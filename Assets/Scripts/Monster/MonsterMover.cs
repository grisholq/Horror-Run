using UnityEngine;

public class MonsterMover : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
    }
}