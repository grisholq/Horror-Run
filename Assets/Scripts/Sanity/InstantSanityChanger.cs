using UnityEngine;

public class InstantSanityChanger : SanityChanger
{
    [SerializeField] private float _sanityChange;
    [SerializeField] private bool _destoryOnEnter;

    private void OnTriggerEnter(Collider other)
    {
        CharacterSanity sanity;
        if(other.TryGetComponent<CharacterSanity>(out sanity))
        {
            ChangeSanity(sanity, _sanityChange);
            if (_destoryOnEnter) Destroy(gameObject);
        }
    }
}