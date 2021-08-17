using UnityEngine;
using UnityEngine.Events;

public class CharacterSanity : MonoBehaviour
{
    [SerializeField] private float _maxSanity;

    [SerializeField] private UnityEvent HaveGoneMad;
    [SerializeField] private UnityEvent<float> SanityChangedNormalized;

    private float _sanity;

    private void Awake()
    {
        _sanity = _maxSanity;
    }

    public void LoseSanity(float sanity)
    {
        _sanity = Mathf.Max(_sanity - sanity, 0);
        SanityChangedNormalized?.Invoke(GetNormalizedSanity());
        if (_sanity <= 0) HaveGoneMad?.Invoke();
    }

    public void ReturnSanity(float sanity)
    {
        _sanity = Mathf.Min(_sanity + sanity, _maxSanity);
        SanityChangedNormalized?.Invoke(GetNormalizedSanity());
    }

    private float GetNormalizedSanity()
    {
        return _sanity / _maxSanity;
    }
}