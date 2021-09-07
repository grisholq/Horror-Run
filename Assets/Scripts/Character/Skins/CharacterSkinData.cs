using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSkin", menuName = "MyAssets/CharacterSkin")]
public class CharacterSkinData : ScriptableObject
{
    public string Name;
    public Transform Prefab;
    public Sprite Image;
    public Avatar Avatar;
    public SkinChangingData ChangingData;
}