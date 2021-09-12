using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;

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
        AppMetrica.Instance.SendEventsBuffer();
    }

    private void Start()
    {
        SendLevelStartEvent();
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
        SendLevelEndEvent(true);
    }

    public void WinWithDelay()
    {
        StartCoroutine(DelayOperation(Win, _winDelayTime));
    }

    public void Lose()
    {
        LevelEnd?.Invoke();
        LevelLost?.Invoke();
        SendLevelEndEvent(false);
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

    private void SendLevelStartEvent()
    {
        Dictionary<string, object> eventData = new Dictionary<string, object>();
        eventData.Add("level_number", LevelsProgress.Instance.CurrentLevelLooped.ToString());
        eventData.Add("level_name", LevelsProgress.Instance.CurrentLevelLooped.ToString() + "_level");
        eventData.Add("level_loop", LevelsProgress.Instance.CurrentLoop.ToString());
        eventData.Add("level_random", 0);
        eventData.Add("level_type", LevelsLoader.Instance.LoadedLevel.IsSkinOpened ? "boss" : "normal");

        AppMetrica.Instance.ReportEvent("level_start", eventData);
        AppMetrica.Instance.SendEventsBuffer();
    }

    private void SendLevelEndEvent(bool win)
    {
        Dictionary<string, object> eventData = new Dictionary<string, object>();
        eventData.Add("level_number", LevelsProgress.Instance.CurrentLevelLooped.ToString());
        eventData.Add("level_name", LevelsProgress.Instance.CurrentLevelLooped.ToString() + "_level");
        eventData.Add("level_loop", LevelsProgress.Instance.CurrentLoop.ToString());
        eventData.Add("level_random", LevelsProgress.Instance.CurrentLoop.ToString());
        eventData.Add("level_type", LevelsLoader.Instance.LoadedLevel.IsSkinOpened ? "boss" : "normal");
        eventData.Add("result", win ? "win" : "lose");
        eventData.Add("time", Time.timeSinceLevelLoad);
        eventData.Add("progress", FindObjectOfType<LevelCompletion>()?.Progress.ToString());

        AppMetrica.Instance.ReportEvent("level_finish", eventData);
        AppMetrica.Instance.SendEventsBuffer();
    }
}