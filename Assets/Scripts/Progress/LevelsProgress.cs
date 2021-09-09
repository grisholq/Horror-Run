using UnityEngine;

public class LevelsProgress : Singleton<LevelsProgress>
{
    [SerializeField] private LevelsStorage _levels;
    [SerializeField] private int _defaultLevel;
    [SerializeField] private int _defaultLoop;
    [SerializeField] private bool _reset;

    public int CurrentLevel => PlayerPrefs.GetInt(LEVEL_KEY);
    public int CurrentLoop => PlayerPrefs.GetInt(LOOP_KEY);
    public bool IsLooping => PlayerPrefs.GetInt(LOOP_KEY) > 0;
    public int CurrentLevelLooped => CurrentLevel + _levels.Count * CurrentLoop;

    private const string LEVEL_KEY = "Level";
    private const string LOOP_KEY = "Loop";

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (_reset)
        {
            SetCurrentLevel(_defaultLevel);
            SetCurrentLoop(_defaultLoop);
        }

        if (PlayerPrefs.HasKey(LEVEL_KEY) == false)
        {
            SetCurrentLevel(_defaultLevel);
        }
        
        if (PlayerPrefs.HasKey(LOOP_KEY) == false)
        {
            SetCurrentLoop(_defaultLoop);
        }
    }

    public void SetCurrentLevel(int number)
    {
        PlayerPrefs.SetInt(LEVEL_KEY, number);
        PlayerPrefs.Save();
    }
    
    public void SetCurrentLoop(int loop)
    {
        PlayerPrefs.SetInt(LOOP_KEY, loop);
        PlayerPrefs.Save();
    }

    public void LevelPassed()
    {
        int level = CurrentLevel;
        level++;

        if(level > _levels.Count)
        {
            level = _defaultLevel + 1;
            IncrementLoop();
        }

        SetCurrentLevel(level);
    }

    private void IncrementLoop()
    {
        int loop = PlayerPrefs.GetInt(LOOP_KEY);
        loop++;
        SetCurrentLoop(loop);
    }
}