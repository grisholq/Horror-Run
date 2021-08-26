using System;
using UnityEngine;
using UnityEngine.UI;

public class SkinButton : MonoBehaviour
{
    [SerializeField] private RawImage _skinImage;

    private CharacterSkin _skin;

    public event Action<CharacterSkin> SkinChoosen;

    private void Awake()
    {
        _skinImage = GetComponent<RawImage>();
    }

    public void SetSkin(CharacterSkin skin)
    {
        _skin = skin;
        _skinImage.texture = skin.Image;     
    }

    public void ChooseSkin()
    {
        SkinChoosen?.Invoke(_skin);
    }
}