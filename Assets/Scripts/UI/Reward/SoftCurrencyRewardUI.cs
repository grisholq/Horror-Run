using TMPro;
using UnityEngine;

public class SoftCurrencyRewardUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _rewardAmount;

    public void SetRewardAmount(int amount)
    {
        _rewardAmount.text = amount.ToString();
    }
}