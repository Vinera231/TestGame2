using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    private readonly int s_animationWalk = Animator.StringToHash("IsWalk");
    private readonly int s_animationJump = Animator.StringToHash("IsJump");

    [SerializeField] private Animator _animator;

    public void PlayWalk()
    {
        _animator.SetBool(s_animationWalk,true);
    }
    
    public void PlayJump()
    {
        _animator.SetBool(s_animationJump,true);
    }

    public void PlayIdle()
    {
        _animator.SetBool(s_animationWalk, false);
        _animator.SetBool(s_animationJump, false);
    }

}