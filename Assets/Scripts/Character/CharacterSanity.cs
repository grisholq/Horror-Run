using UnityEngine;
using UnityEngine.Events;

public class CharacterSanity : MonoBehaviour
{
    [SerializeField] private float _maxSanity;

    [SerializeField] private UnityEvent HaveGoneMad;
    [SerializeField] private UnityEvent<float> SanityLevelChanged;

    public bool IsMad { get; set; }

    private float _sanity;

    private void Awake()
    {
        IsMad = false;
        _sanity = _maxSanity;
    }

    public void LoseSanity(float sanity)
    {
        if (IsMad) return;

        _sanity = Mathf.Max(_sanity - sanity, 0);
        SanityLevelChanged?.Invoke(GetNormalizedSanity());

        if (_sanity <= 0)
        {
            GetMad();
        }
    }

    public void ReturnSanity(float sanity)
    {
        if (IsMad) return;

        _sanity = Mathf.Min(_sanity + sanity, _maxSanity);
        SanityLevelChanged?.Invoke(GetNormalizedSanity());
    }

    private float GetNormalizedSanity()
    {
        return _sanity / _maxSanity;
    }

    private void GetMad()
    {
        IsMad = true;
        HaveGoneMad?.Invoke();
    }
}