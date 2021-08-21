using UnityEngine;

public class SanityItem : MonoBehaviour
{
    [SerializeField] Behaviour _halo;

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