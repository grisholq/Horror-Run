using UnityEngine;

public class GameDataStorage : Singleton<GameDataStorage>
{
    private const string _characterSkinKey = "Character Skin";
    private const string _defaultCharacterSkin = "Guy";

    private const string _sanitySkinKey = "SanitySkins";
    private const string _defaultSanitySkin = "SkullPopIt";

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
    
    public string SanitySkin
    {
        get
        {
            return PlayerPrefs.GetString(_sanitySkinKey, _defaultSanitySkin);
        }

        set
        {
            PlayerPrefs.SetString(_sanitySkinKey, value);
            PlayerPrefs.Save();
        }
    }
}