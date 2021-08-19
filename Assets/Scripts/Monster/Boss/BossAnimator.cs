using UnityEngine;

public class BossAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _throwParameter;

    public void SetThrow()
    {
        _animator.SetTrigger(_throwParameter);
    }
}