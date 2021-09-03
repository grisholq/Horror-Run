using UnityEngine;

public static class LevelsProgress
{
    private const string LEVEL_KEY = "Level";
    private const int RESET_LEVEL = 1;

    public static bool Empty => PlayerPrefs.HasKey(LEVEL_KEY) == false;

    public static void SetCurrentLevelNumber(int number)
    {
        PlayerPrefs.SetInt(LEVEL_KEY, number);
        PlayerPrefs.Save();
    }

    public static int GetCurrentLevelNumber()
    {
        return PlayerPrefs.GetInt(LEVEL_KEY);
    }

    public static void Reset()
    {
        SetCurrentLevelNumber(RESET_LEVEL);
    }
}