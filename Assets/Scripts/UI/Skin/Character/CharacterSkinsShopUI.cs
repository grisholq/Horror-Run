using UnityEngine;
using UnityEngine.UI;

public class CharacterSkinsShopUI : MonoBehaviour
{
    [SerializeField] private CharacterSkinButton _skinButton;
    [SerializeField] private CharacterOpenSkinButton _openButton;

    private void Awake()
    {
        ShowAllSkins(CharacterSkins.Instance.Skins);
    }

    private void ShowAllSkins(CharacterSkinData[] skins)
    {
        if (skins == null || skins.Length == 0) return;

        foreach (var skin in skins)
        {
            CharacterSkinButton button = InstantiateSkinButton();
            button.SetSkin(skin);
            button.SkinChoosen += ChooseSkin;
        }
    }

    public void RedrawButtons()
    {
        CharacterSkinButton[] buttons = GetComponentsInChildren<CharacterSkinButton>();

        foreach (var button in buttons)
        {
            button.DrawState();
        }

        _openButton.HandleButtonInteractability();
    }

    private CharacterSkinButton InstantiateSkinButton()
    {
        return Instantiate(_skinButton, transform);
    }

    private void ChooseSkin(CharacterSkinData skin)
    {
        CharacterSkins.Instance.ChooseSkin(skin);
        RedrawButtons();
    }
}