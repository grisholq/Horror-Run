using UnityEngine;
using UnityEngine.Events;

public class CharactersCollisions : MonoBehaviour
{
    [SerializeField] private UnityEvent NearedMonster;
    [SerializeField] private UnityEvent<bool> EnemyNearbyStateChanged;

    private void OnTriggerEnter(Collider other)
    {
        Monster monster;
        if(other.TryGetComponent<Monster>(out monster))
        {
            NearedMonster?.Invoke();
            EnemyNearbyStateChanged?.Invoke(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Monster monster;
        if (other.TryGetComponent<Monster>(out monster))
        {
            EnemyNearbyStateChanged?.Invoke(false);
        }
    }
}