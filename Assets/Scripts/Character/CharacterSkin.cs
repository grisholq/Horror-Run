using UnityEngine;

public class CharacterSkin : MonoBehaviour
{
    private Animator _animator;

    private CharacterSkinData _current;

    private void Awake()
    {
        InizializeComponents();
        InizializeSkin();
    }

    private void InizializeComponents()
    {
        _animator = GetComponent<Animator>();
    }

    private void InizializeSkin()
    {
        string skinName = GameDataStorage.Instance.CharacterSkinName;
        SetSkin(SkinsStorage.Instance.GetSkinByName(skinName));
    }

    public void SetSkin(CharacterSkinData skin)
    {
        if (skin == _current) return;
        _current = skin;

        RemovePreviousSkin();
        InstantiateSkinPrefab(skin.Prefab);
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
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    private void SetSkinAvatar(Avatar avatar)
    {
        _animator.avatar = avatar;
    }
}