using UnityEngine;

public class CharacterLight : MonoBehaviour
{
    private CharacterLightPart[] _lightParts;

    private void Awake()
    {
        _lightParts = GetComponentsInChildren<CharacterLightPart>();
    }

    public void SetRangeNormalized(float range)
    {
        foreach (var lightSoucre in _lightParts)
        {
            lightSoucre.SetRangeNormalized(range);
        }
    }
}
