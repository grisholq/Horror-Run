using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSkinButton : MonoBehaviour
{
    [SerializeField] private RawImage _skinImage;

    private CharacterSkinData _skin;

    public event Action<CharacterSkinData> SkinChoosen;

    public void SetSkin(CharacterSkinData skin)
    {
        _skin = skin;
        _skinImage.texture = skin.Image;     
    }

    public void ChooseSkin()
    {
        SkinChoosen?.Invoke(_skin);
    }
}