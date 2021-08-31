using UnityEngine;
using UnityEngine.Events;

public class CharacterSanity : MonoBehaviour
{
    [SerializeField] private float _maxSanity;
    [SerializeField] private float _startingSanity;
    [SerializeField] private float _maxDecreasePerSecond;
    [SerializeField] private float _autoDecreaseThereshold;

    [SerializeField] private UnityEvent HaveGoneMad;
    [SerializeField] private UnityEvent<float> SanityLevelChanged;

    public bool IsConstantlyDecreasing { get; set; }
    public bool IsMad { get; set; }

    private float _sanity;

    public float Sanity 
    {
        get => _sanity;

        private set
        {
            _sanity = Mathf.Clamp(value, 0, _maxSanity);
            SanityLevelChanged?.Invoke(GetNormalizedSanity());
        }
    }

    private void Start()
    {
        IsMad = false;
        IsConstantlyDecreasing = true;
        SetSanity(_startingSanity);
    }

    private void Update()
    {   
        if(IsConstantlyDecreasing && Sanity >= _autoDecreaseThereshold)
        {
            float lostSanity = (Sanity / _maxSanity) * _maxDecreasePerSecond;
            LoseSanity(lostSanity * Time.deltaTime);
        }  
    }

    public void LoseSanity(float sanity)
    {
        if (IsMad) return;

        Sanity -= sanity;

        if (Sanity <= 0)
        {
            GetMad();
        }
    }

    public void ReturnSanity(float sanity)
    {
        if (IsMad) return;
        Sanity += sanity;      
    }

    public void SetSanity(float sanity)
    {
        if (IsMad) return;
        Sanity = sanity;
    }

    private float GetNormalizedSanity()
    {
        return Sanity / _maxSanity;
    }

    private void GetMad()
    {
        IsMad = true;
        HaveGoneMad?.Invoke();
    }
}