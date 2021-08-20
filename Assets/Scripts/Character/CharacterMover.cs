using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private bool _lookInMovementDirection;
    [SerializeField] private bool _isStopped;
   
    public bool IsStopped { get => _isStopped; set => _isStopped = value; }

    private Rigidbody _rigidbody;
    private Vector3 _movement;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (IsStopped) return;
        ResetMovement();
        CalculateMovement();
        Move();
    }

    private void CalculateMovement()
    {
        AddSidewayMovement();
        AddForwardMovement();
    }

    private void ResetMovement()
    {
        _movement = Vector3.zero;
    }

    private bool HasTouchInput()
    {
        return Input.touchCount != 0;
    }
    
    private bool HasKeyboardInput()
    {
        return Input.GetAxis("Horizontal") != 0;
    }
    
    private void AddSidewayMovement()
    {
        if(HasTouchInput()) _movement += GetSideMovementDirectionFromTouch();
        if(HasKeyboardInput()) _movement += GetSideMovementDirection();
    }

    private Vector3 GetSideMovementDirectionFromTouch()
    {
        Vector2 touchPosition = Input.GetTouch(0).position;
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        float x;

        x = (touchPosition.x / screenSize.x) * 2;

        if (x <= 1) return new Vector3(- (1 - x), 0, 0);
        if (x > 1) return new Vector3(x - 1, 0, 0);

        return Vector3.zero;
    }

    private Vector3 GetSideMovementDirection()
    {
        float axis = Input.GetAxis("Horizontal");
        return Vector3.right * axis;
    }

    private void AddForwardMovement()
    {
        _movement += Vector3.forward;
    }

    private void Move()
    {
        if (_lookInMovementDirection) LookInMovementDirection();
        Vector3 delta = _movement.normalized * _movementSpeed * Time.deltaTime;
        _rigidbody.MovePosition(transform.position + delta);  
    }

    private void LookInMovementDirection()
    {
        transform.LookAt(transform.position + _movement);
    }
}