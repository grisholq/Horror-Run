using UnityEngine;
using UnityEngine.Events;

public class BossfightEnter : MonoBehaviour
{
    [SerializeField] private UnityEvent BossfightStarted;
    [SerializeField] private UnityEvent<Character> CharacterEntered;

    private void OnTriggerEnter(Collider other)
    {
        if(IsCharacter(other))
        {
            Character character = other.GetComponent<Character>();
            PrepareCharacter(character);
            BossfightStarted?.Invoke();
            CharacterEntered?.Invoke(character);
        }
    }

    private bool IsCharacter(Collider other)
    {
        return other.GetComponent<Character>() != null;
    }

    private void PrepareCharacter(Character character)
    {
        character.Sanity.IsConstantlyDecreasing = false;
        character.Mover.IsStopped = true;
        character.Mover.StopMovement();
        character.Animator.SetWalk();
    }
}