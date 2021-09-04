using TMPro;
using UnityEngine;

public class SoftCurrencyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currencyAmount;

    private void Start()
    {
        SoftCurrency.Instance.AmountChanged += ShowCurrencyAmount;
        ShowCurrencyAmount(GetCurrencyAmount());
    }

    private void ShowCurrencyAmount(int amount)
    {
        _currencyAmount.text = amount.ToString();
    }

    private int GetCurrencyAmount()
    {
        return SoftCurrency.Instance.Amount;
    }
}