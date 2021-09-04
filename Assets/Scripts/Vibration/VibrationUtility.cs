using UnityEngine;

public class VibrationUtility : Singleton<VibrationUtility>
{
    [SerializeField] private bool _enabled;

    public bool Enabled { get => _enabled; set => _enabled = value; }

    private void Awake()
    {
        DontDestroyOnLoad(this);
        Vibration.Init();
    }

    public void VibrateSmall()
    {
        if (Enabled == false) return;
        Vibration.Vibrate(20);
    }

    public void VibrateMedium()
    {
        if (Enabled == false) return;
        Vibration.Vibrate(100);
    }
}   