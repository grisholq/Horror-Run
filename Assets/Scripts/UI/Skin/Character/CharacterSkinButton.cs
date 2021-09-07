using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSkinButton : MonoBehaviour
{ 
    public event Action<CharacterSkinData> SkinChoosen;

    private CharacterSkinData _skin;

    private CharacterSkinButtonStates _buttonEffects;

    private void Awake()
    {
        _buttonEffects = GetComponent<CharacterSkinButtonStates>();
    }

    public void SetSkin(CharacterSkinData skin)
    {
        _skin = skin;
        DrawState();
    }

    public void DrawState()
    {
        _buttonEffects.ShowSkinState(_skin);
    }

    public void ChooseSkin()
    {
        SkinChoosen?.Invoke(_skin);
    }
}