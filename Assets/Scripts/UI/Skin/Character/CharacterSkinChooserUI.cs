using UnityEngine;

public class CharacterSkinChooserUI : MonoBehaviour
{
    [SerializeField] private CharacterSkinButton _skinButton;

    private CharacterSkin _characterSkin;

    private void Awake()
    {
        _characterSkin = FindObjectOfType<CharacterSkin>();
        ShowAllSkins(SkinsStorage.Instance.CharacterSkins);
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

    private CharacterSkinButton InstantiateSkinButton()
    {
        return Instantiate(_skinButton, transform);
    }

    private void ChooseSkin(CharacterSkinData skin)
    {
        GameDataStorage.Instance.CharacterSkinName = skin.name;
        _characterSkin.SetSkin(skin);
    }
}