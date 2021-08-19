using UnityEngine;

public class CharacterLightPart : MonoBehaviour
{
    [SerializeField] private float[] _ranges;

    private Light _light;

    private void Awake()
    {
        _light = GetComponent<Light>();
    }

    private void Start()
    {
        _light.range = GetRangeFromNormalizedSanity(1);
    }

    public void SetRangeBySanity(float sanity)
    {
        _light.range = GetRangeFromNormalizedSanity(sanity);
    }

    private float GetRangeFromNormalizedSanity(float sanity)
    {
        if (sanity > 0.8f) return _ranges[3];
        else if (sanity > 0.5f) return _ranges[2];
        else if (sanity > 0.25f) return _ranges[1];
        return _ranges[0];
    }
}