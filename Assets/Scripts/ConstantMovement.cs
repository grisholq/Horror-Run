using UnityEngine;

public class ConstantMovement : MonoBehaviour
{
    [SerializeField] private Vector3 _movement;

    private void Update()
    {
        transform.position += _movement * Time.deltaTime;
    }
}