using UnityEngine;

public class SkinsStorage : Singleton<SkinsStorage>
{
    [SerializeField] private CharacterSkin[] _skins;

    public CharacterSkin[] Skins => _skins;
    public CharacterSkin Current { get; set; }

    private const string _characterSkinKey = "Character Skin";


    private string LoadSkinName()
    {
        return PlayerPrefs.GetString(_characterSkinKey, _skins[0].Name);
    }

    private void SaveSkinName(string name)
    {
        PlayerPrefs.SetString(_characterSkinKey, name);
        PlayerPrefs.Save();
    }
}
