using TMPro;
using System;
using UnityEngine;

public class SanitySkinButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _skinName;

    public event Action<SanityItemSkinData> SkinChoosen;

    private SanityItemSkinData _skin;
    private Animator _animator;

    public void SetSkin(SanityItemSkinData skin)
    {
        _skin = skin;
        _skinName.text = skin.Name;
    }

    private void Highlight()
    {
        _animator.SetTrigger("Highlight");
    }

    public void ChooseSkin()
    {
        SkinChoosen?.Invoke(_skin);
    }
}