using UnityEngine;
using UnityEngine.Events;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private UnityEvent LevelEndEnter;

    private void OnTriggerEnter(Collider other)
    {
        if(IsCharacter(other.gameObject))
        {
            SetCharacter(other.GetComponent<Character>());
            LevelEndEnter?.Invoke();
        }
    }

    private bool IsCharacter(GameObject collided)
    {
        return collided.GetComponent<Character>() != null;
    }

    private void SetCharacter(Character character)
    {
        character.Mover.IsStopped = true;
        character.Animator.SetDance();
    }
}