using System;
using UnityEngine;

public class CharacterSkins : Singleton<CharacterSkins>
{
    [SerializeField] private CharacterSkinData[] _characterSkins;
    [SerializeField] private CharacterSkinData _defaultSkin;
    [SerializeField] private bool _reset;

    public CharacterSkinData[] Skins => _characterSkins;

    public event Action<CharacterSkinData> SkinChanged;

    public CharacterSkinData Current
    {
        get
        {
            foreach (var characterSkin in _characterSkins)
            {
                if (characterSkin.ChangingData.IsChoosen == true) return characterSkin;
            }

            return _defaultSkin;
        }
    }

    public bool HasClosedSkins
    {
        get
        {
            foreach (var characterSkin in _characterSkins)
            {
                if (characterSkin.ChangingData.IsOpened == false) return true;
            }

            return false;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (_reset) ResetSkins();
    }

    private void ResetSkins()
    {
        foreach (var characterSkin in _characterSkins)
        {
            characterSkin.ChangingData.IsChoosen = false;
            characterSkin.ChangingData.IsOpened = false;
        }

        _defaultSkin.ChangingData.IsOpened = true;
        _defaultSkin.ChangingData.IsChoosen = true;
    }

    public void ChooseSkin(CharacterSkinData skin)
    {
        foreach (var characterSkin in _characterSkins)
        {
            characterSkin.ChangingData.IsChoosen = false;
        }

        skin.ChangingData.IsChoosen = true; 
        SkinChanged?.Invoke(skin);
    }

    public void OpenClosedSkin()
    {
        foreach (var characterSkin in _characterSkins)
        {
            if(characterSkin.ChangingData.IsOpened == false)
            {
                characterSkin.ChangingData.IsOpened = true;
                return;
            }
        }
    }

    public CharacterSkinData GetCharacterSkinByName(string name)
    {
        foreach (var skin in _characterSkins)
        {
            if (skin.Name == name)
            {
                return skin;
            }
        }

        return null;
    }
}