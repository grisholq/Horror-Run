using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [SerializeField] private UnityEvent Died;

    private CharacterMover _mover;
    private CharacterSanity _sanity;
    private CharacterAnimator _animator;

    public CharacterMover Mover => _mover;
    public CharacterSanity Sanity => _sanity;
    public CharacterAnimator Animator => _animator;

    private void Awake()
    {
        InizializeComponents();   
    }

    private void InizializeComponents()
    {
        _mover = GetComponent<CharacterMover>();
        _sanity = GetComponent<CharacterSanity>();
        _animator = GetComponentInChildren<CharacterAnimator>();
    }

    public void Die()
    {
        Died?.Invoke();
    }
}