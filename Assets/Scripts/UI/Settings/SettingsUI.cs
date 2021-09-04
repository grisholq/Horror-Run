using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private Toggle _vibrationToggle;
    [SerializeField] private Toggle _musicToggle;
    [SerializeField] private Toggle _soundsToggle;

    private void OnEnable()
    {
        SetCheckboxesStates();
    }

    private void SetCheckboxesStates()
    {
        _vibrationToggle.isOn = VibrationUtility.Instance.Enabled;
        _musicToggle.isOn = SoundsPlayer.Instance.MusicOn;
        _soundsToggle.isOn = SoundsPlayer.Instance.SoundsOn;
    }

    public void ChangeVibrationState(bool state)
    {
        VibrationUtility.Instance.Enabled = state;
    }

    public void ChangeMusicState(bool state)
    {
        SoundsPlayer.Instance.MusicOn = state;
    }

    public void ChangeSoundsState(bool state)
    {
        SoundsPlayer.Instance.SoundsOn = state;
    }
}