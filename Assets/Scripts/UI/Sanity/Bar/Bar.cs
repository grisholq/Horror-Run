using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void SetBarValueNormalized(float value)
    {
        _slider.normalizedValue = value;
    }
}