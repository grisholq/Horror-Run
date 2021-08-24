using UnityEngine;

public class BossAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private string _throwParameter;
    [SerializeField] private string _deathParameter;

    public void SetThrow()
    {
        _animator.SetTrigger(_throwParameter);
    }

    public void SetDeath()
    {
        _animator.SetTrigger(_deathParameter);
    }
}