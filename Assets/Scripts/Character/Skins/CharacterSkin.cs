using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSkin", menuName = "MyAssets/CharacterSkin")]
public class CharacterSkin : ScriptableObject
{
    public Transform Prefab;
    public Texture Image;
    public Avatar Avatar;
}