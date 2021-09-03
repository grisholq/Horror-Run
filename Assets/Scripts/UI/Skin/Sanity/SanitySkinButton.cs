using TMPro;
using System;
using UnityEngine;

public class SanitySkinButton : MonoBehaviour
{
    public event Action<SanityItemSkinData> SkinChoosen;

    private SanityItemSkinData _skin;
    private SanitySkinButtonState _buttonStates;
    private Animator _animator;

    private void Awake()
    {
        _buttonStates = GetComponent<SanitySkinButtonState>();
    }

    public void SetSkin(SanityItemSkinData skin)
    {
        _skin = skin;
        _buttonStates.ShowSkinState(skin);
    }

    public void Redraw()
    {
        _buttonStates.ShowSkinState(_skin);
    }

    public void ChooseSkin()
    {
        SkinChoosen?.Invoke(_skin);
    }
}