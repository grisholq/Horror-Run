using UnityEngine;
using UnityEngine.UI;

public class CharacterSkinButtonStates : MonoBehaviour
{
    [SerializeField] private Image _skinImage;
    [SerializeField] private Sprite _closedSkin;
    [SerializeField] private Color _normalColor;
    [SerializeField] private Color _choosenColor;

    private Button _button;
    private Animator _animator;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _animator = GetComponent<Animator>();
    }

    public void ShowSkinState(CharacterSkinData skin)
    {
        SkinChangingData changingData = skin.ChangingData;

        if(changingData.IsOpened == false)
        {
            ShowClosedState(skin);
        }

        if(changingData.IsOpened && changingData.IsChoosen == false)
        {
            ShowOpenedState(skin);
        }

        if(changingData.IsChoosen)
        {
            ShowChoosenState(skin);
        }
    }

    private void ShowClosedState(CharacterSkinData skin)
    {
        _skinImage.sprite = _closedSkin;
        _skinImage.color = _normalColor;
        _button.interactable = false;

    }

    private void ShowOpenedState(CharacterSkinData skin)
    {
        _skinImage.sprite = skin.Image;
        _skinImage.color = _normalColor;
        _button.interactable = true;
    }

    private void ShowChoosenState(CharacterSkinData skin)
    {
        _skinImage.sprite = skin.Image;
        _skinImage.color = _choosenColor;
        _button.interactable = true;
    } 
}