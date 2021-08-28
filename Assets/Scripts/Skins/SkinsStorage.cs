using System;
using UnityEngine;

public class SkinsStorage : Singleton<SkinsStorage>
{
    private CharacterSkin[] _skins;
    public CharacterSkin[] Skins => _skins;
    public CharacterSkin Current { get; private set; }

    public event Action<CharacterSkin> SkinChanged;

    private const string _characterSkinKey = "Character Skin";

    private void Awake()
    {
        Inizialize();
    }

    private void Inizialize()
    {
        DontDestroyOnLoad(this);
        //Current = FindSkinByName(LoadSkinName());
        _skins = Resources.FindObjectsOfTypeAll<CharacterSkin>();
    }

    private CharacterSkin FindSkinByName(string name)
    {
        foreach (var skin in _skins)
        {
            if(skin.Name == name)
            {
                return skin;
            }
        }

        return null;
    }

    private string LoadSkinName()
    {
        return PlayerPrefs.GetString(_characterSkinKey, _skins[1].Name);
    }

    private void SaveSkinName(string name)
    {
        PlayerPrefs.SetString(_characterSkinKey, name);
        PlayerPrefs.Save();
    }

    public void SetCurrentSkin(CharacterSkin skin)
    {
        if (skin == Current) return;       
        Current = skin;
        SaveSkinName(skin.Name); 
        SkinChanged?.Invoke(skin);
    }
}