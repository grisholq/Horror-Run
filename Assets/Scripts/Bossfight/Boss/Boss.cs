using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Boss : MonoBehaviour
{
    [SerializeField] private float _deathDelay;
    [SerializeField] private UnityEvent Died;

    private void Start()
    {
        SoundsPlayer.Instance.EnableBossScreams();
    }

    public void Die()
    {
        Died?.Invoke();
        SoundsPlayer.Instance.DisableBossScreams();
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