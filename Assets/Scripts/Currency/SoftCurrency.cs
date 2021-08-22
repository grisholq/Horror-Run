using UnityEngine;

public class SoftCurrency : Singleton<SoftCurrency>
{
    private int _amount;

    public int Amount 
    { 
        get => _amount; 

        set
        {
            _amount = Mathf.Clamp(value, 0, MAX_CURRENCY);
        }
    }

    private const string SAVE_KEY = "Soft Currency";
    private const int MAX_CURRENCY = 10000;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        LoadCurrencyAmount();
    }

    public void EarnCurrency(int amount)
    {
        Amount += amount;
        SaveCurrencyAmount();
    }

    public void SpendCurrency(int amount)
    {
        Amount -= amount;
    }

    private void LoadCurrencyAmount()
    {
        Amount = PlayerPrefs.GetInt(SAVE_KEY, 20);
    }

    private void SaveCurrencyAmount()
    {
        PlayerPrefs.SetInt(SAVE_KEY, Amount);
        PlayerPrefs.Save();
    }
}