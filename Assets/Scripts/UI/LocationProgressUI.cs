using UnityEngine;
using UnityEngine.UI;

public class LocationProgressUI : MonoBehaviour
{
    private Slider _progressSlider;

    private void Awake()
    {
        _progressSlider = GetComponent<Slider>();
        ShowProgress();
    }

    private void ShowProgress()
    {     
        LevelData level = LevelsLoader.Instance.LoadedLevel;
        float _sliderValue = (float)level.NumberInLocation / (float)level.LevelsInLocation;
        _progressSlider.normalizedValue = _sliderValue;
    }
}