using UnityEngine;

public class SanitySkinsShopUI : MonoBehaviour
{
    [SerializeField] private SanitySkinButton _skinButton;

    private void Awake()
    {
        ShowAllSkins(SanitySkins.Instance.Skins);
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
        SanitySkins.Instance.ChooseSkin(skin);
    }
}