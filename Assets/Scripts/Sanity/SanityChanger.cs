using UnityEngine;

public abstract class SanityChanger : MonoBehaviour
{
    [SerializeField] private SanityChangerType changerType;

    protected void ChangeSanity(CharacterSanity sanity, float sanityChange)
    {
        sanityChange = Mathf.Abs(sanityChange);

        switch (changerType)
        {
            case SanityChangerType.Increaser:
                sanity.ReturnSanity(Mathf.Abs(sanityChange));
                break;

            case SanityChangerType.Decreaser:
                sanity.LoseSanity(Mathf.Abs(sanityChange));
                break;
        }
    }
}