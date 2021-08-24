using UnityEngine;
using TMPro;

public class SanityText : MonoBehaviour
{   
    [SerializeField] private Color _calm;
    [SerializeField] private Color _anxious;
    [SerializeField] private Color _scared;
    [SerializeField] private Color _mad;

    private TextMeshProUGUI _sanityText;

    private void Awake()
    {
        _sanityText = GetComponent<TextMeshProUGUI>();
    }

    public void SetTextBySanity(float sanity)
    {
        _sanityText.text = GetTextFromSanity(sanity);
        _sanityText.color = GetColorFromSanity(sanity);
    }

    private string GetTextFromSanity(float sanity)
    {
        if (sanity >= 0.75f) return "Calm";
        else if (sanity >= 0.5f) return "Anxious";
        else if (sanity >= 0.25f) return "Scared";
        return "Mad";
    }

    private Color GetColorFromSanity(float sanity)
    {
        if (sanity >= 0.75f) return _calm;
        else if (sanity >= 0.5f) return _anxious;
        else if (sanity >= 0.25f) return _scared;
        return _mad;
    }
}