using UnityEngine;

public class PeriodicalSanityChanger : SanityChanger
{
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _maxSanityChange;

    private void OnTriggerStay(Collider other)
    {
        CharacterSanity sanity;
        if (other.TryGetComponent<CharacterSanity>(out sanity))
        {
            float distance = Vector3.Distance(transform.position, other.transform.position);
            ChangeSanity(sanity, GetSanityChange(distance) * Time.deltaTime);
        }
    }

    private float GetSanityChange(float distance)
    {
        return (1 - GetDistancePercent(distance)) * _maxSanityChange;
    }

    private float GetDistancePercent(float distance)
    {
        return distance / _maxDistance;
    }
}