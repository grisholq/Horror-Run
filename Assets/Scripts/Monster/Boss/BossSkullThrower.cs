using UnityEngine;

public class BossSkullThrower : MonoBehaviour
{
    [SerializeField] private Transform _skullPrefab;


    public Transform GetSkull()
    {
        return Instantiate(_skullPrefab);
    }
}