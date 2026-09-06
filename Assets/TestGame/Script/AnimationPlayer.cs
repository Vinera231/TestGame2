using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    private readonly int s_animationWalk = Animator.StringToHash("Walk");
    private readonly int s_animationJump = Animator.StringToHash("Jump");

    [SerializeField] private Animator _animator;

    public void PlayWalk()
    {
        _animator.Play(s_animationWalk,0,-1);
    }
    
    public void PlayJump()
    {
        _animator.Play(s_animationJump,0,-1);
    }
}