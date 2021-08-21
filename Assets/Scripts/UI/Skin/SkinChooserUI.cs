using UnityEngine;
using UnityEngine.Events;

public class SkinChooserUI : MonoBehaviour
{
    [SerializeField] private SkinButton _skinButton;
    [SerializeField] private UnityEvent<CharacterSkin> SkinChoosen;

    private void Start()
    {
        ShowAllSkins();
    }

    private void ShowAllSkins()
    {
        CharacterSkin[] skins = GetSkinsFromResources();

        Debug.Log(skins.Length);

        if (skins == null || skins.Length == 0) return;

        foreach (var skin in skins)
        {
            SkinButton button = InstantiateSkinButton();
            button.SetSkin(skin);
            button.SkinChoosen += ChooseSkin;
        }
    }

    private CharacterSkin[] GetSkinsFromResources()
    {
        return Resources.FindObjectsOfTypeAll<CharacterSkin>();
    }

    private SkinButton InstantiateSkinButton()
    {
        return Instantiate(_skinButton, transform);
    }

    private void ChooseSkin(CharacterSkin skin)
    {
        SkinChoosen?.Invoke(skin);
    }
}