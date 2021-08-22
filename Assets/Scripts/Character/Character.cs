using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [SerializeField] private UnityEvent Died;

    public CharacterMover Mover => GetComponent<CharacterMover>();
    public CharacterSanity Sanity => GetComponent<CharacterSanity>();
    public CharacterAnimator Animator => GetComponentInChildren<CharacterAnimator>();

    public void Die()
    {
        Died?.Invoke();
    }
}