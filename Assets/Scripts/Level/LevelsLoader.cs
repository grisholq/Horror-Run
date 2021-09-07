using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsLoader : Singleton<LevelsLoader>
{
    [SerializeField] private LevelsProgress _progress;
    [SerializeField] private LevelsStorage _levels;

    public LevelData LoadedLevel { get; set; }

    private void Start()
    {
        DontDestroyOnLoad(this);
        LoadProgressLevel();           
    }

    private void LoadProgressLevel()
    {
        LoadLevel(_progress.CurrentLevel);
    }

    public void LoadLevel(int number)
    {
        LevelData level = _levels.GetLevel(number);
        LoadedLevel = level;
        SceneManager.LoadSceneAsync(level.BuildIndex);        
    }
}