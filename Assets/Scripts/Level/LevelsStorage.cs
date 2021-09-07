using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelsStorage : MonoBehaviour
{
    [SerializeField] private List<LevelData> _levels;

    public int Count => _levels.Count;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public LevelData GetLevel(int number)
    {
        foreach (var level in _levels)
        {
            if (level.Number == number)
            {
                return level;
            }
        }
        return null;
    }
}