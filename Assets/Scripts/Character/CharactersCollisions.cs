using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class CharactersCollisions : MonoBehaviour
{
    [SerializeField] private float _checkTime;

    [SerializeField] private UnityEvent NearedMonster;
    [SerializeField] private UnityEvent PassedMonster;

    private Coroutine _checkCoroutine;

    private bool _hasMonster;

    private void OnEnable()
    {
        _checkCoroutine = StartCoroutine(CheckCollidersProcess());
    }

    private void OnDisable()
    {
        StopCoroutine(_checkCoroutine);
    }

    private IEnumerator CheckCollidersProcess()
    {
        while(true)
        {
            yield return new WaitForSeconds(_checkTime);
           
            bool hasMonster = HasMonstersAround();

            if(_hasMonster != hasMonster)
            {
                if(hasMonster)
                {
                    NearedMonster?.Invoke();
                }
                else
                {
                    PassedMonster?.Invoke();
                }

                _hasMonster = hasMonster;
            }
        }
    }

    private bool HasMonstersAround()
    {
        Collider[] colliders = GetCollidersNearby();

        foreach (var collider in colliders)
        {
            if (collider.GetComponent<Monster>() != null) return true;
        }

        return false;
    }

    private Collider[] GetCollidersNearby()
    {
        return Physics.OverlapBox(transform.position, Vector3.one * 3);
    }
}