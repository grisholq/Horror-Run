using UnityEngine;

public class MonsterAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Avatar _avatar;

    private void Awake()
    {
        _animator.avatar = _avatar;
    }
}