using UnityEngine;
using UnityEngine.Events;

public class MonsterBodyCollider : MonoBehaviour
{
    [SerializeField] private UnityEvent CollidedPlayer;

    private void OnCollisionEnter(Collision collision)
    {
        if (IsCharacter(collision.gameObject))
        {
            CollidedPlayer?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(IsCharacter(other.gameObject))
        {
            CollidedPlayer?.Invoke();
        }
    }

    private bool IsCharacter(GameObject gameObject)
    {
        return gameObject.GetComponent<Character>() != null;
    }
}