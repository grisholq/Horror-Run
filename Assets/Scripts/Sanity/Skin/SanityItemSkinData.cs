using UnityEngine;

[CreateAssetMenu(fileName = "SanityItemSkin", menuName = "MyAssets/SanityItemSkin")]
public class SanityItemSkinData : ScriptableObject  
{
    public string Name;
    public Transform PositiveView;
    public Transform NegativeView;
    public Texture Image;
}