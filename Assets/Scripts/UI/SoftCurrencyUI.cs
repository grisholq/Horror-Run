using TMPro;
using UnityEngine;

public class SoftCurrencyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currencyAmount;

    private void Start()
    {
        ShowCurrencyAmount();
    }

    private void ShowCurrencyAmount()
    {
        _currencyAmount.text = GetCurrencyAmount().ToString();
    }

    private int GetCurrencyAmount()
    {
        return SoftCurrency.Instance.Amount;
    }
}