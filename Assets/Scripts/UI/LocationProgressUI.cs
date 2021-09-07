using UnityEngine;
using UnityEngine.UI;

public class LocationProgressUI : MonoBehaviour
{
    [SerializeField] private Slider _progressSlider;
    [SerializeField] private RawImage _currentLevelImage;
    [SerializeField] private RawImage _nextLevelImage;
   
    private LevelData _level;

    private void Start()
    {
        _level = LevelsLoader.Instance.LoadedLevel;
        ShowProgressBar();
        ShowLevelPictures();
    }

    private void ShowProgressBar()
    {     
        float _sliderValue = (float)_level.NumberInLocation / (float)_level.LevelsInLocation;
        _progressSlider.normalizedValue = _sliderValue;
    }

    private void ShowLevelPictures()
    {
        _currentLevelImage.texture = _level.LocationImage;
        _nextLevelImage.texture = _level.NextLocationImage;
    }
}