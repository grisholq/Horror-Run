using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "MyAssets/LevelData")]
public class LevelData : ScriptableObject
{
    public int BuildIndex;
    public int Number;

    public int MinReward;
    public int MaxReward;

    public SanityItemSkinData OpeningSkin;
    public bool IsSkinOpened;

    public int NumberInLocation;
    public int LevelsInLocation;

    public Texture LocationImage;
    public Texture NextLocationImage;
}