using UnityEngine;

public class SkinsStorage : Singleton<SkinsStorage>
{
    [SerializeField] private CharacterSkinData[] _characterSkins;
    [SerializeField] private SanityItemSkinData[] _sanitySkins;

    public CharacterSkinData[] CharacterSkins => _characterSkins;
    public SanityItemSkinData[] SanitySkins => _sanitySkins;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public CharacterSkinData GetCharacterSkinByName(string name)
    {
        foreach (var skin in _characterSkins)
        {
            if(skin.Name == name)
            {
                return skin;
            }
        }

        return null;
    }

    public SanityItemSkinData GetSanitySkinByName(string name)
    {
        foreach (var skin in _sanitySkins)
        {
            if (skin.Name == name)
            {     
                return skin;
            }
        }


        return null;
    }
}