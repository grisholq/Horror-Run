using UnityEngine;
using UnityEngine.UI;

public class BarColor : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Gradient _gradient;

    private void Awake()
    {
        SetColorFromValue(1);
    }

    public void SetColorFromValue(float value)
    {
        _image.color = _gradient.Evaluate(value);
    }
}