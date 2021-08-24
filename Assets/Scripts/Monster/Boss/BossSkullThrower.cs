using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class BossSkullThrower : MonoBehaviour
{
    [SerializeField] private float _throwPeriod;

    [SerializeField] private Transform _character;
    [SerializeField] private Transform _startingPosition;
    [SerializeField] private Transform _skullPrefab;

    [SerializeField] private UnityEvent SkullThrowed;

    private Coroutine _skullThrowingProcess;

    private void OnEnable()
    {
        _skullThrowingProcess = StartCoroutine(ThrowSkullOverPeriod(_throwPeriod));
    }

    private void OnDisable()
    {
        StopCoroutine(_skullThrowingProcess);
    }

    private IEnumerator ThrowSkullOverPeriod(float period)
    {
        while(true)
        {
            yield return new WaitForSeconds(period);
            ThrowSkull();
        }
    }

    public void ThrowSkull()
    {
        BossProjectile skull = GetSkull().GetComponent<BossProjectile>();
        skull.Target = _character;
        skull.IsChasing = true;
        skull.transform.position = GetThrowPositionStart();
        SkullThrowed?.Invoke();
    }

    private Vector3 GetThrowPositionStart()
    {
        Vector3 start = _startingPosition.position;
        start.x += Random.Range(-3, 3);
        return start;
    }

    private Transform GetSkull()
    {
        return Instantiate(_skullPrefab);
    }
}