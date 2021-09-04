using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SanitySkinRewardUI : MonoBehaviour
{
    [SerializeField] private RawImage _openingSkinImage;
    [SerializeField] private RawImage _mask;
    [SerializeField] private float _maxMaskBottom;
    [SerializeField] private float _riseSpeed;

    private Coroutine _maskRisingProcess;

    public void ShowOpeningSkinProgress(Texture _skinImage, float startPercent, float endPercent)
    {
        _openingSkinImage.texture = _skinImage;
        if (_maskRisingProcess != null) StopCoroutine(_maskRisingProcess);
        _mask.rectTransform.offsetMin += new Vector2(0, _maxMaskBottom) * startPercent;
        _maskRisingProcess = StartCoroutine(RiseMask(endPercent));
    }

    private IEnumerator RiseMask(float percent)
    {
        while(IsMaskRised(percent) == false)
        {
            Vector2 offsetMin = _mask.rectTransform.offsetMin;          
            offsetMin.y += _riseSpeed * Time.unscaledDeltaTime;
            _mask.rectTransform.offsetMin = offsetMin;
            yield return null;
        }
    }

    private bool IsMaskRised(float percentage)
    {
        return _mask.rectTransform.offsetMin.y >= _maxMaskBottom * percentage;
    }
}