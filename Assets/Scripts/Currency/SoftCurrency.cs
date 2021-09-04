using System;
using UnityEngine;

public class SoftCurrency : Singleton<SoftCurrency>
{
    [SerializeField] private bool _reset;

    private int _amount;

    public event Action<int> AmountChanged;

    public int Amount 
    { 
        get => _amount; 

        set
        {
            _amount = Mathf.Clamp(value, 0, MAX_CURRENCY);
            AmountChanged?.Invoke(_amount);
        }
    }

    private const string SAVE_KEY = "Soft Currency";
    private const int MAX_CURRENCY = 100000;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (_reset) ResetCurrency();
        Load();
    }

    private void ResetCurrency()
    {
        Amount = 0;
        Save();
    }

    public void Earn(int amount)
    {
        Amount += amount;
        Save();
    }

    public void Spend(int amount)
    {
        Amount -= amount;
        Save();
    }

    private void Load()
    {
        Amount = PlayerPrefs.GetInt(SAVE_KEY, 0);
    }

    private void Save()
    {
        PlayerPrefs.SetInt(SAVE_KEY, Amount);
        PlayerPrefs.Save();
    }
}