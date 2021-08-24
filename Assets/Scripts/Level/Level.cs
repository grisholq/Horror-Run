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
        LevelsLoader.Instance.RestartLevel();
    }

    public void Win()
    {
        LevelWon?.Invoke();
    }

    public void WinWithDelay()
    {
        StartCoroutine(DelayOperation(Win, _winDelayTime));
    }

    public void Lose()
    {
        LevelLost?.Invoke();
    }

    public void LoseWithDelay()
    {
        StartCoroutine(DelayOperation(Lose, _loseDelayTime));
    }
    
    public void NextLevel()
    {
        LevelsLoader.Instance.LoadNextLevel();
    }

    private IEnumerator DelayOperation(Action operation, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        operation();
    }
}