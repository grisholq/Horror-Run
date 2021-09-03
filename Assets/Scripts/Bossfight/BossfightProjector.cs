using UnityEngine;
using UnityEngine.Events;

public class BossfightProjector : MonoBehaviour
{
    [SerializeField] private Transform _projector;
    [SerializeField] private UnityEvent CharacterEntered;
    [SerializeField] private UnityEvent TurnedToBoss;
    [SerializeField] private bool _enabled;

    private void OnTriggerEnter(Collider other)
    {
        if (IsCharacter(other))
        {
            Character character = other.GetComponent<Character>();
            PrepareCharacter(character);
            CharacterEntered?.Invoke();
        }
    }

    private bool IsCharacter(Collider other)
    {
        return other.GetComponent<Character>() != null;
    }

    private void PrepareCharacter(Character character)
    {
        character.Animator.SetProjector();
    }

    private void Update()
    {
        if (_enabled == false) return;

        if (_projector.eulerAngles.y <= 0.7f)
        {
            _enabled = false;
            TurnedToBoss?.Invoke();
        }
    }
}