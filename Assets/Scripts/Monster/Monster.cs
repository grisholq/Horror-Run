using UnityEngine;
using UnityEngine.Events;

public class Monster : MonoBehaviour
{
    [SerializeField] private UnityEvent Died;

    public void Die()
    {
        Died?.Invoke();
        Destroy(gameObject);
    }
}