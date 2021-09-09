using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressBarUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelNumber;
    [SerializeField] private RawImage _levelStateImage;

    public void SetLevelStateImage(Texture stateImage)
    {
        _levelStateImage.texture = stateImage;
    }

    public void SetLevelNumber(int number)
    {
        _levelNumber.text = number.ToString();
    }
}