using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LocationProgressUI : MonoBehaviour
{
    [SerializeField] private Transform _levelProgressBarParent;
    [SerializeField] private LevelProgressBarUI _levelProgressBarUI;

    [SerializeField] private Texture _levelPassedImage;
    [SerializeField] private Texture _levelNotPassedImage;
   
    [SerializeField] private RawImage _currentLevelImage;
    [SerializeField] private RawImage _nextLevelImage;
   
    private LevelData _level;

    private void Start()
    {
        _level = LevelsLoader.Instance.LoadedLevel;
        ShowProgressBars();
        ShowLevelPictures();
    }

    private void ShowProgressBars()
    {
        int passedBarsCount = _level.NumberInLocation;
        int emptyBarsCount = _level.LevelsInLocation - _level.NumberInLocation;

        List<LevelProgressBarUI> bars = new List<LevelProgressBarUI>();

        for (int i = 0; i < passedBarsCount; i++)
        {
            LevelProgressBarUI bar = InstantiateLevelBar();
            bar.SetLevelStateImage(_levelPassedImage);
            bar.transform.SetParent(_levelProgressBarParent);
            bars.Add(bar);
        }
        
        for (int i = 0; i < emptyBarsCount; i++)
        {
            LevelProgressBarUI bar = InstantiateLevelBar();
            bar.SetLevelStateImage(_levelNotPassedImage);
            bar.transform.SetParent(_levelProgressBarParent);
            bars.Add(bar);
        }

        SetBarsLevelNumbers(bars);
    }

    private LevelProgressBarUI InstantiateLevelBar()
    {
        return Instantiate(_levelProgressBarUI, _levelProgressBarParent);     
    }

    private void SetBarsLevelNumbers(List<LevelProgressBarUI> bars)
    {
        int knownIndex = _level.NumberInLocation - 1;
        int knownIndexNumber =  LevelsProgress.Instance.CurrentLevel;

        if(LevelsProgress.Instance.IsLooping)
        {
            knownIndexNumber = LevelsProgress.Instance.CurrentLevelLooped;
        }

        for (int i = 0; i < bars.Count; i++)
        {
            int difference = knownIndex - i;
            bars[i].SetLevelNumber(knownIndexNumber - difference);
        }
    }

    private void ShowLevelPictures()
    {
        _currentLevelImage.texture = _level.LocationImage;
        _nextLevelImage.texture = _level.NextLocationImage;
    }
}