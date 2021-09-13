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

    private void RewardSoftCurrency()
    {
        float reward = GetRewardFromSanityNormalized();
        SoftCurrency.Instance.Earn((int)reward);
        _softCurrencyRewardUI.SetRewardAmount((int)reward);
    }

    public void RewardSanitySkins()
    {
        if(_levelData.IsSkinOpened)
        {
            SanitySkins.Instance.OpenSkin(_levelData.OpeningSkin);
        }

        if(LevelsProgress.Instance.IsLooping || _levelData.OpeningSkin == null)
        {
            HideOpeningSkin();
        }
        else
        {
            ShowOpeningSkin();
        }
    }

    private void ShowOpeningSkin()
    {
        _sanitySkinsRewardUI.gameObject.SetActive(true);

        Sprite openingSkin = _levelData.OpeningSkin.Image;
        float deltaPercent = 1 / (float)_levelData.LevelsInLocation;
        float endPercent = (float)_levelData.NumberInLocation * deltaPercent;
        float startPercent = endPercent - deltaPercent;

        _sanitySkinsRewardUI.ShowOpeningSkinProgress(openingSkin, startPercent, endPercent);
    }

    private void HideOpeningSkin()
    {
        _sanitySkinsRewardUI.gameObject.SetActive(false);
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