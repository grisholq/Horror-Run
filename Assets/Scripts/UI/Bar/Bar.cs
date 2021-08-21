using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Bar : MonoBehaviour
{
    [SerializeField] private UnityEvent<float> ValueChanged;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void SetBarValueNormalized(float value)
    {
        _slider.normalizedValue = value;
        ValueChanged?.Invoke(value);
    }
}