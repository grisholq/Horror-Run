using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;

public class Level : MonoBehaviour
{
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
        Debug.Log("Win");
    }

    public void WinWithDelay(float seconds)
    {
        StartCoroutine(DelayOperation(Win, seconds));
    }

    public void Lose()
    {
        LevelLost?.Invoke();
        Debug.Log("Lose");
    }

    public void LoseWithDelay(float seconds)
    {
        StartCoroutine(DelayOperation(Lose, seconds));
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