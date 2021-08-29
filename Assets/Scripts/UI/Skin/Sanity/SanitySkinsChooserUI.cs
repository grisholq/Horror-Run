using UnityEngine;

public class SanitySkinsChooserUI : MonoBehaviour
{
    [SerializeField] private SanitySkinButton _skinButton;

    private SanitySkinChanger _skinChanger;

    private void Awake()
    {
        _skinChanger = FindObjectOfType<SanitySkinChanger>();
        ShowAllSkins(SkinsStorage.Instance.SanitySkins);
    }

    private void ShowAllSkins(SanityItemSkinData[] skins)
    {
        if (skins == null || skins.Length == 0) return;

        foreach (var skin in skins)
        {
            SanitySkinButton button = InstantiateSkinButton();
            button.SetSkin(skin);
            button.SkinChoosen += ChooseSkin;
        }
    }

    private SanitySkinButton InstantiateSkinButton()
    {
        return Instantiate(_skinButton, transform);
    }

    private void ChooseSkin(SanityItemSkinData skin)
    {
        GameDataStorage.Instance.SanitySkin = skin.Name;
        _skinChanger.SetSanitySkins(skin);
    }
}