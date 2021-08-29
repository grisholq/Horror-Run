using UnityEngine;

public class SanityItem : MonoBehaviour
{
    [SerializeField] private Behaviour _halo;
    [SerializeField] private SanityItemSkin _skin;

    public SanityItemSkin Skin => _skin;

    private void Awake()
    {
        _halo.enabled = false;
    }

    public void OnEnterFieldOfView()
    {
        EnableHalo();
    }

    private void EnableHalo()
    {
        _halo.enabled = true;
    }
}