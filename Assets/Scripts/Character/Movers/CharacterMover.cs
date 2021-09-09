using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterSideInput))]
public class CharacterMover : MonoBehaviour
{
    [SerializeField] private Transform[] _rotatablesByMovement;
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _sideSpeed;
    [SerializeField] private bool _isStopped;

    public bool IsStopped { get => _isStopped; set => _isStopped = value; }

    private CharacterSideInput _sideInput;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _sideInput = GetComponent<CharacterSideInput>();
    }

    private void FixedUpdate()
    {
        if (IsStopped) return;

        Vector3 delta = FormDelta();
        Debug.Log(delta);
        LookInDirection(delta);
        SetMovementDirection(delta);
    }

    private Vector3 FormDelta()
    {
        return GetForwardDelta() + GetSideDelta();
    }

    private Vector3 GetForwardDelta()
    {
        return transform.forward * _forwardSpeed;        
    }

    private Vector3 GetSideDelta()
    {
        return transform.right * _sideInput.SideInput * _sideSpeed;    
    }

    private void SetMovementDirection(Vector3 direction)
    {
        _rigidbody.velocity = direction;
    }

    private void LookInDirection(Vector3 direction)
    {
        Vector3 lookPosition = transform.position + direction;

        foreach (var rotatable in _rotatablesByMovement)
        {
            rotatable.LookAt(transform.position + direction);
        }
    }

    public void StopMovement()
    {
        IsStopped = true;
        _rigidbody.velocity = Vector3.zero;
        SoundsPlayer.Instance.DisableSteps();
    }

    public void ResumeMovement()
    {  
        IsStopped = false;
        SoundsPlayer.Instance.EnableSteps();
    }
}