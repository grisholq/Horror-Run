using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    [SerializeField] private string _sanityParameter;
    [SerializeField] private string _nearedMonsterParameter;
    [SerializeField] private string _passedMonsterParameter;
    [SerializeField] private string _deathParameter;
    [SerializeField] private string _danceParameter;
    [SerializeField] private string _walkParameter;
    [SerializeField] private string _projectorParameter;

    public void SetSanity(float sanity)
    {
        _animator.SetFloat(_sanityParameter, sanity);
    }
    
    public void SetNearedMonster()
    {
        _animator.SetTrigger(_nearedMonsterParameter);
    }
    
    public void SetPassedMonster()
    {
        _animator.SetTrigger(_passedMonsterParameter);
    }

    public void SetDeath()
    {
        _animator.SetTrigger(_deathParameter);
    }

    public void SetDance()
    {
        _animator.SetTrigger(_danceParameter);
    }

    public void SetWalk()
    {
        _animator.SetTrigger(_walkParameter);
    }

    public void SetProjector()
    {
        _animator.SetTrigger(_projectorParameter);
    }
}