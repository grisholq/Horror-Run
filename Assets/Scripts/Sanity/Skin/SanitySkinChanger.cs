using UnityEngine;

public class SanitySkinChanger : MonoBehaviour
{
    private SanityItemSkin[] _positiveSkins;
    private SanityItemSkin[] _negativeSkins;

    private void Awake()
    {
        InizializeSkins();
        LoadSkins();
    }

    private void InizializeSkins()
    {
        InizializePositiveSkins();
        InizializeNegativeSkins();
    } 
    
    private void InizializePositiveSkins()
    {
        SanityIncreaser[] increasers = GetComponentsInChildren<SanityIncreaser>();
        _positiveSkins = new SanityItemSkin[increasers.Length];

        for (int i = 0; i < _positiveSkins.Length; i++)
        {
            _positiveSkins[i] = increasers[i].Skin;
        }
    } 
    
    private void InizializeNegativeSkins()
    {
        SanityDecreaser[] decreasers = GetComponentsInChildren<SanityDecreaser>();
        _negativeSkins = new SanityItemSkin[decreasers.Length];

        for (int i = 0; i < _negativeSkins.Length; i++)
        {
            _negativeSkins[i] = decreasers[i].Skin;
        }
    }

    private void LoadSkins()
    {
        string skinName = GameDataStorage.Instance.SanitySkin;
        SanityItemSkinData skins = SkinsStorage.Instance.GetSanitySkinByName(skinName);
        SetSanitySkins(skins);
    }


    public void SetSanitySkins(SanityItemSkinData skin)
    {
        foreach (var positiveSkin in _positiveSkins)
        {
            positiveSkin.SetView(skin.PositiveView);
        }

        foreach (var negativeSkin in _negativeSkins)
        {
            negativeSkin.SetView(skin.NegativeView);
        }
    }
}