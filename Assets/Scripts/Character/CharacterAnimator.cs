using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    [SerializeField] private string _sanityParameter;
    [SerializeField] private string _monsterNearbyParameter;
    [SerializeField] private string _nearedMonsterParameter;
    [SerializeField] private string _deathParameter;
    [SerializeField] private string _danceParameter;

    public void SetSanity(float sanity)
    {
        _animator.SetFloat(_sanityParameter, sanity);
    }

    public void SetMonsterNearby(bool nearby)
    {
        _animator.SetBool(_monsterNearbyParameter, nearby);
    }
    
    public void SetNearedMonster()
    {
        _animator.SetTrigger(_nearedMonsterParameter);
    }

    public void SetDeath()
    {
        _animator.SetTrigger(_deathParameter);
    }

    public void SetDance()
    {
        _animator.SetTrigger(_danceParameter);
    }
}