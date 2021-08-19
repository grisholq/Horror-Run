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
        foreach (var lightSoucre in _lightParts)
        {
            lightSoucre.SetRangeBySanity(sanity);
        }
    }
}
