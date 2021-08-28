using System;
using UnityEngine;

public class SkinsStorage : Singleton<SkinsStorage>
{
    [SerializeField] private CharacterSkinData[] _skins;

    public CharacterSkinData[] Skins => _skins;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public CharacterSkinData GetSkinByName(string name)
    {
        foreach (var skin in Skins)
        {
            if(skin.Name == name)
            {
                return skin;
            }
        }

        return null;
    }
}