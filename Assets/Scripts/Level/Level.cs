using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;

public class Level : MonoBehaviour
{
    [SerializeField] private float _winDelayTime;
    [SerializeField] private float _loseDelayTime;

    [SerializeField] private UnityEvent LevelWon;
    [SerializeField] private UnityEvent LevelLost;
    [SerializeField] private UnityEvent LevelEnd;

    private void Awake()
    {     
        InizializeLevel();
    }

    private void InizializeLevel()
    {
        Application.targetFrameRate = 60;
    }

    public void Restart()
    {
        int level = LevelsProgress.Instance.CurrentLevel;
        LevelsLoader.Instance.LoadLevel(level);
    }

    public void NextLevel()
    {
        LevelsProgress.Instance.LevelPassed();
        int level = LevelsProgress.Instance.CurrentLevel;
        LevelsLoader.Instance.LoadLevel(level);
    }

    public void Win()
    {
        LevelEnd?.Invoke();
        LevelWon?.Invoke();
    }

    public void WinWithDelay()
    {
        StartCoroutine(DelayOperation(Win, _winDelayTime));
    }

    public void Lose()
    {
        LevelEnd?.Invoke();
        LevelLost?.Invoke();
    }

    public void LoseWithDelay()
    {
        StartCoroutine(DelayOperation(Lose, _loseDelayTime));
    }

    private IEnumerator DelayOperation(Action operation, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        operation();
    }
}