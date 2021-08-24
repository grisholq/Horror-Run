using UnityEngine;

public class ProjectorAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _turnForwardParameter;

    public void SetTurnForward()
    {
        _animator.SetTrigger(_turnForwardParameter);
    }
}