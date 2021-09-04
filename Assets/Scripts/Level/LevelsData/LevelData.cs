using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "MyAssets/LevelData")]
public class LevelData : ScriptableObject
{
    public int BuildIndex;
    public int Number;

    public int MinReward;
    public int MaxReward;

    public SanityItemSkinData OpeningSkin;
    public float StartOpenPercent;
    public float EndOpenPercent;
    public bool IsSkinOpened;
}