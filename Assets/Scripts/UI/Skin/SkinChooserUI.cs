using UnityEngine;

public class SkinChooserUI : MonoBehaviour
{
    [SerializeField] private SkinButton _skinButton;

    private CharacterSkin _characterSkin;

    private void OnEnable()
    {
        _characterSkin = FindObjectOfType<CharacterSkin>();
        ShowAllSkins(SkinsStorage.Instance.Skins);
    }

    private void ShowAllSkins(CharacterSkinData[] skins)
    {
        if (skins == null || skins.Length == 0) return;

        foreach (var skin in skins)
        {
            SkinButton button = InstantiateSkinButton();
            button.SetSkin(skin);
            button.SkinChoosen += ChooseSkin;
        }
    }

    private SkinButton InstantiateSkinButton()
    {
        return Instantiate(_skinButton, transform);
    }

    private void ChooseSkin(CharacterSkinData skin)
    {
        GameDataStorage.Instance.CharacterSkinName = skin.name;
        _characterSkin.SetSkin(skin);
    }
}