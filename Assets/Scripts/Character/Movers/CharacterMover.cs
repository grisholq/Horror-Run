using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterSideInput))]
public class CharacterMover : MonoBehaviour
{
    [SerializeField] private UnityEvent CharacterMoved;
    [SerializeField] private Transform _view;
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _sideSpeed;
    [SerializeField] private float _speedClamp;
    [SerializeField] private bool _isStopped;

    public bool IsStopped { get => _isStopped; set => _isStopped = value; }
    public float SideSpeed { get => _sideSpeed; set => _sideSpeed = value; }

    private Rigidbody _rigidbody;
    private CharacterSideInput _sideInput;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _sideInput = GetComponent<CharacterSideInput>();
    }

    private void Update()
    {
        if (IsStopped) return;

        Vector3 delta = Vector3.zero;
        delta += GetForwardDelta();
        delta += GetSideDelta();
        LookInDirection(delta);
        //_rigidbody.MovePosition(transform.position + delta);
        _rigidbody.velocity = delta;
        CharacterMoved?.Invoke();
    }

    public void Stop()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    private Vector3 GetForwardDelta()
    {
        return transform.forward * _forwardSpeed;        
    }

    private Vector3 GetSideDelta()
    {
        return transform.right * _sideInput.NormalizedValue * _sideSpeed;    
    }

    private void LookInDirection(Vector3 direction)
    {
        _view.LookAt(transform.position + direction);
    }
}