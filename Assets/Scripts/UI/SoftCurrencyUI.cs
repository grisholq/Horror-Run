using TMPro;
using UnityEngine;

public class SoftCurrencyUI : MonoBehaviour
{
    private TextMeshProUGUI _currencyAmount;

    private void Awake()
    {
        InizializeText();
    }
    
    private void InizializeText()
    {
        _currencyAmount = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        SoftCurrency.Instance.AmountChanged += ShowCurrencyAmount;
        ShowCurrencyAmount(SoftCurrency.Instance.Amount);
    }

    private void ShowCurrencyAmount(int amount)
    {
        _currencyAmount.text = amount.ToString();
    }
}