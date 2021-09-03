using TMPro;
using UnityEngine;

public class SoftCurrencyRewardUI : MonoBehaviour
{
    private TextMeshProUGUI _rewardAmount;

    private void Awake()
    {
        _rewardAmount = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetRewardAmount(int amount)
    {
        _rewardAmount.text = amount.ToString();
    }
}