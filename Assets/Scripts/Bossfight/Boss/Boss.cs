using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Boss : MonoBehaviour
{
    [SerializeField] private float _deathDelay;
    [SerializeField] private UnityEvent Died;

    public void Die()
    {
        Died?.Invoke();
        Destroy(gameObject);
    }
    
    public void DieWithDelay()
    {
        StartCoroutine(DelayedDeath(_deathDelay));
    }

    private IEnumerator DelayedDeath(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Die();
    }
}