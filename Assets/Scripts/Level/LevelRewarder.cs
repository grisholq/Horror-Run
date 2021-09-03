using UnityEngine;

public class LevelRewarder : MonoBehaviour
{
    [SerializeField] private SoftCurrencyRewardUI _softCurrencyRewardUI;
    [SerializeField] private SanitySkinRewardUI _sanitySkinsRewardUI;

    private LevelData _levelData;
    private CharacterSanity _sanity;

    private void Awake()
    {
        _sanity = FindObjectOfType<CharacterSanity>();
        _levelData = LevelsLoader.Instance.LoadedLevel;
    }

    public void Reward()
    {
        RewardSoftCurrency();
        RewardSanitySkins();
    }

    public void RewardSanitySkins()
    {
        if(_levelData.IsSkinOpened)
        {
            SanitySkins.Instance.OpenSkin(_levelData.OpeningSkin);
        }

        _sanitySkinsRewardUI.ShowOpeningSkinProgress(_levelData.OpeningSkin.Image, _levelData.SkinOpeningPercentage);
    }

    private void RewardSoftCurrency()
    {
        float reward = GetRewardFromSanityNormalized();
        SoftCurrency.Instance.Earn((int)reward);
        _softCurrencyRewardUI.SetRewardAmount((int)reward);
    }

    private float GetRewardFromSanityNormalized()
    {
        return _sanity.NormalizedSanity * GetRewardsDelta() + _levelData.MinReward;
    }

    private float GetRewardsDelta()
    {
        return _levelData.MaxReward - _levelData.MinReward;
    }
}