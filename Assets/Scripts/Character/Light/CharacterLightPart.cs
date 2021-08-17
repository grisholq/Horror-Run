using UnityEngine;

public class CharacterLightPart : MonoBehaviour
{
    [SerializeField] private float _maxRange;
    [SerializeField] private float _minRange;

    private Light _light;

    private void Awake()
    {
        _light = GetComponent<Light>();
    }

    private void Start()
    {
        _light.range = _maxRange;
    }

    public void SetRangeNormalized(float range)
    {
        _light.range = (_maxRange - _minRange) * range + _minRange;
    }
}