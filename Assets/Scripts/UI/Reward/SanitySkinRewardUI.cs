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

    private void Awake()
    {
        ShowOpeningSkinProgress(null, 0.5f);
    }

    public void ShowOpeningSkinProgress(Texture _skinImage, float percentage)
    {
        _openingSkinImage.texture = _skinImage;
        if (_maskRisingProcess != null) StopCoroutine(_maskRisingProcess);
        _maskRisingProcess = StartCoroutine(RiseMask(percentage));
    }

    private IEnumerator RiseMask(float percentage)
    {
        while(IsMaskRised(percentage) == false)
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