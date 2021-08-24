using UnityEngine;

public class BossfightMover : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private Character _character;
    private bool _allowMovement;

    private void Update()
    {
        if (_allowMovement == false) return;

        if(_character != null)
        {
            _character.transform.position = GetNextPosition();
        }
    }

    private Vector3 GetNextPosition()
    {
        return Vector3.MoveTowards(_character.transform.position, _target.position, Time.deltaTime * _speed);
    }

    public void SetCharacter(Character character)
    {
        _character = character;
    }
    
    public void StartMovement()
    {
        _allowMovement = true;
    }

    public void StopMovement()
    {
        _allowMovement = false;
    }
}