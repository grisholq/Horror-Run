using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    [SerializeField] private CharacterSkinChanger _changer;
    [SerializeField] private CharacterSkin _skin;

    private void Start()
    {
        _changer.SetSkin(_skin);
    }
}
