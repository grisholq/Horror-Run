using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CharacterOpenSkinButton : MonoBehaviour
{
    [SerializeField] private UnityEvent SkinRecieved;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        HandleButtonInteractability();
    }

    public void HandleButtonInteractability()
    {
        float currency = SoftCurrency.Instance.Amount;
        _button.interactable = currency >= 1000 && CharacterSkins.Instance.HasClosedSkins;
    }

    public void OpenSkin()
    {
        SoftCurrency.Instance.Spend(1000);
        CharacterSkins.Instance.OpenClosedSkin();
        SkinRecieved?.Invoke();
    }
}