using UnityEngine;

public class CharacterSkin : MonoBehaviour
{
    private Animator _animator;

    private CharacterSkinData _current;

    private void Awake()
    {
        InizializeComponents();
    }

    private void OnEnable()
    {
        InizializeSkin();
    }

    private void OnDisable()
    {
        CharacterSkins.Instance.SkinChanged -= SetSkin;
    }

    private void InizializeComponents()
    {
        _animator = GetComponent<Animator>();
    }

    private void InizializeSkin()
    {
        CharacterSkins.Instance.SkinChanged += SetSkin;
        CharacterSkinData skin = CharacterSkins.Instance.Current;
        SetSkin(skin);
    }

    public void SetSkin(CharacterSkinData skin)
    {
        if (skin == _current) return;
        _current = skin;

        RemovePreviousSkin();
        InstantiateSkinPrefab(skin.Prefab);
        SetSkinAvatar(null);     
        SetSkinAvatar(skin.Avatar);     
    }

    private void InstantiateSkinPrefab(Transform prefab)
    {
        Transform skin = Instantiate(prefab);
        skin.SetParent(transform);
        skin.localPosition = Vector3.zero;
        skin.localEulerAngles = Vector3.zero;
    }

    private void RemovePreviousSkin()
    {
        if (transform.childCount == 0) return;

        for (int i = 0; i < transform.childCount; i++)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }

    private void SetSkinAvatar(Avatar avatar)
    {
        _animator.avatar = avatar;
    }
}