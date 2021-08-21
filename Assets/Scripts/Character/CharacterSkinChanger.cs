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
        RemovePreviousSkin();
        InstantiateSkinPrefab(skin.Prefab); 
        SetSkinAvatar(skin.Avatar);
    }

    private void InstantiateSkinPrefab(Transform prefab)
    {
        Transform skin = Instantiate(prefab);
        skin.SetParent(transform);
    }

    private void RemovePreviousSkin()
    {
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