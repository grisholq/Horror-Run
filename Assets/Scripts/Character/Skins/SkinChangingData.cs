using System;
using UnityEngine;

[Serializable]
public class SkinChangingData
{
    public bool DefaultChoosenState;
    public bool DefaultOpenedState;

    public string OpenedKey;
    public string ChoosenKey;

    public bool IsOpened
    {
        get
        {
            if(PlayerPrefs.HasKey(OpenedKey))
            {
                int data = PlayerPrefs.GetInt(OpenedKey);
                return data == 0 ? false : true;
            }

            IsOpened = DefaultChoosenState;
            return IsOpened;
        }

        set
        {
            int data = value ? 1 : 0;
            PlayerPrefs.SetInt(OpenedKey, data);
            PlayerPrefs.Save();
        }
    }

    public bool IsChoosen
    {
        get
        {
            if (PlayerPrefs.HasKey(ChoosenKey))
            {
                int data = PlayerPrefs.GetInt(ChoosenKey);
                return data == 0 ? false : true;
            }

            IsChoosen = DefaultChoosenState;
            return IsChoosen;
        }

        set
        {
            int data = value ? 1 : 0;
            PlayerPrefs.SetInt(ChoosenKey, data);
            PlayerPrefs.Save();
        }
    }
}