using UnityEngine;

public class CharacterLight : MonoBehaviour
{
    private CharacterLightPart[] _lightParts;

    private void Awake()
    {
        _lightParts = GetComponentsInChildren<CharacterLightPart>();
    }

    public void SetRangeBySanity(float sanity)
    {
        foreach (var lightPart in _lightParts)
        {
            lightPart.SetRangeBySanity(sanity);
        }
    }
}