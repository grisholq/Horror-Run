using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SanitySkinRewardUI : MonoBehaviour
{
    [SerializeField] private Image _openingSkinImage;
    [SerializeField] private TextMeshProUGUI _openingPercentText;
    [SerializeField] private RawImage _mask;
    [SerializeField] private float _maxMaskBottom;
    [SerializeField] private float _percentPerSecond;

    private float _openingPercent;
    private Coroutine _maskRisingProcess;

    public void ShowOpeningSkinProgress(Sprite _skinImage, float startPercent, float endPercent)
    {
        _openingSkinImage.sprite = _skinImage;

        if (_maskRisingProcess != null) StopCoroutine(_maskRisingProcess);
        _openingPercent = startPercent;
        _mask.rectTransform.offsetMin += new Vector2(0, _maxMaskBottom) * startPercent;
        _maskRisingProcess = StartCoroutine(RiseMask(endPercent));
    }

    private IEnumerator RiseMask(float targetPercent)
    {
        while(_openingPercent < targetPercent)
        {
            _openingPercent += Time.unscaledDeltaTime * _percentPerSecond;
            SetMaskPercent(_openingPercent);
            SetTextPercent(_openingPercent);
            yield return null;
        }
    }

    private void SetMaskPercent(float percent)
    {
        Vector2 offsetMin = _mask.rectTransform.offsetMin;
        offsetMin.y = percent * _maxMaskBottom;
        _mask.rectTransform.offsetMin = offsetMin;
    }
    
    private void SetTextPercent(float percent)
    {
        percent *= 100;
        _openingPercentText.text = ((int)percent).ToString() + '%';
    }
}