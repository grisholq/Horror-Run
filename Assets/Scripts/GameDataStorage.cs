using UnityEngine;

public class GameDataStorage : Singleton<GameDataStorage>
{
    private const string _characterSkinKey = "Character Skin";
    private const string _defaultCharacterSkin = "Guy";

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public string CharacterSkinName
    {
        get
        {
            return PlayerPrefs.GetString(_characterSkinKey, _defaultCharacterSkin);
        }

        set
        {
            PlayerPrefs.SetString(_characterSkinKey, value);
            PlayerPrefs.Save();
        }
    }
}