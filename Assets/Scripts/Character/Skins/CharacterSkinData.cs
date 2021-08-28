using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSkin", menuName = "MyAssets/CharacterSkin")]
public class CharacterSkinData : ScriptableObject
{
    public string Name;
    public Transform Prefab;
    public Texture Image;
    public Avatar Avatar;
}