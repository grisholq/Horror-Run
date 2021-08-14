using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private bool _lookInMovementDirection;

    private Vector3 _movement;

    private void Update()
    {
        ResetMovement();
        CalculateMovement();
        Move();
    }

    private void CalculateMovement()
    {
        if (IsMovingSideway())
        {
            AddSidewayMovement();
        }           
        AddForwardMovement();
    }

    private void ResetMovement()
    {
        _movement = Vector3.zero;
    }

    private bool IsMovingSideway()
    {
        return Input.GetAxis("Horizontal") != 0;
    }

    private void AddSidewayMovement()
    {
        _movement += GetSideMovementDirection();
    }

    private Vector3 GetSideMovementDirection()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        return Vector3.right * horizontalAxis;
    }

    private void AddForwardMovement()
    {
        _movement += Vector3.forward;
    }

    private void Move()
    {
        if (_lookInMovementDirection) LookInMovementDirection();
        transform.position += _movement.normalized * _movementSpeed * Time.deltaTime;     
    }

    private void LookInMovementDirection()
    {
        transform.LookAt(transform.position + _movement);
    }
}