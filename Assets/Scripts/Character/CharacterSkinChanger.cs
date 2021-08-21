using UnityEngine;

public class CharacterSkinChanger : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetSkin(CharacterSkin skin)
    {
        SetSkinAvatar(skin.Avatar);
        InstantiateSkinPrefab(skin.Prefab);
        RemovePreviousSkin();
    }

    private void InstantiateSkinPrefab(Transform prefab)
    {
        Transform skin = Instantiate(prefab);
        skin.SetParent(transform);
    }

    private void RemovePreviousSkin()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        foreach (var child in children)
        {
            Destroy(child.gameObject);
        }
    }

    private void SetSkinAvatar(Avatar avatar)
    {
        _animator.avatar = avatar;
    }
}