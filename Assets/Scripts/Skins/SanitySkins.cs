using System;
using UnityEngine;

public class SanitySkins : Singleton<SanitySkins>
{
    [SerializeField] private SanityItemSkinData[] _sanitySkins;
    [SerializeField] private SanityItemSkinData _defaultSkin;
    [SerializeField] private bool _reset;

    public SanityItemSkinData[] Skins => _sanitySkins;

    public event Action<SanityItemSkinData> SkinChanged;

    public SanityItemSkinData Current
    {
        get
        {
            foreach (var sanitySkin in _sanitySkins)
            {
                if (sanitySkin.ChangingData.IsChoosen == true) return sanitySkin;
            }

            return _defaultSkin;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (_reset) ResetSkins();
    }

    private void ResetSkins()
    {
        foreach (var sanitySkin in _sanitySkins)
        {
            sanitySkin.ChangingData.IsChoosen = false;
            sanitySkin.ChangingData.IsOpened = false;
        }

        _defaultSkin.ChangingData.IsChoosen = true;
        _defaultSkin.ChangingData.IsOpened = true;
    }

    public void OpenSkin(SanityItemSkinData skin)
    {
        skin.ChangingData.IsOpened = true;
    }

    public void ChooseSkin(SanityItemSkinData skin)
    {
        foreach (var sanitySkin in _sanitySkins)
        {
            sanitySkin.ChangingData.IsChoosen = false;
        }

        skin.ChangingData.IsChoosen = true;
        SkinChanged?.Invoke(skin);
    }

    public SanityItemSkinData GetSanitySkinByName(string name)
    {
        foreach (var skin in _sanitySkins)
        {
            if (skin.Name == name)
            {
                return skin;
            }
        }

        return null;
    }
}