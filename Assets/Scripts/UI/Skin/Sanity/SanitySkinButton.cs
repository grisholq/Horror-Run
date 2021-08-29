using TMPro;
using System;
using UnityEngine;

public class SanitySkinButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _skinName;

    private SanityItemSkinData _skin;

    public event Action<SanityItemSkinData> SkinChoosen;

    public void SetSkin(SanityItemSkinData skin)
    {
        _skin = skin;
        _skinName.text = skin.Name;
    }

    public void ChooseSkin()
    {
        SkinChoosen?.Invoke(_skin);
    }
}