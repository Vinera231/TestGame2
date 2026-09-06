using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float gravity = -30f;
    [SerializeField] private float _speed = 8f;
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private float _jump = 3f;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private AnimationPlayer _animationPlayer;
    [SerializeField] private GameOverPanel _gameOverPanel;
    [SerializeField] private FinishPanel _finishPanel;

    public event Action Died;
    public event Action Won;
    private bool _isGround;
    private float  _moveZ;
    private bool _canJump = true;

    private void Update()
    {
        _isGround = _controller.isGrounded;

        if (_isGround && _velocity.y < 0)
            _velocity.y = -2f;

        _moveZ = Input.GetAxis("Vertical");
       
        _animationPlayer.PlayWalk();
        Vector3 move = transform.forward * _moveZ;
        _controller.Move(_speed * Time.deltaTime * move);

        _velocity.y += gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animationPlayer.PlayJump();
            Jump();
        }
    }

    public void Jump()
    {
        if (_isGround && _canJump)
            _velocity.y = Mathf.Sqrt(_jump * -2f * gravity);
    }

    public void PlayerDied()
    {
        Died?.Invoke();
        PauseSwitcher.Instance.Pause();
        _gameOverPanel.Show();
        AfterDied();
    }
    
    public void PlayerWin()
    {
        Won?.Invoke();
        PauseSwitcher.Instance.Pause();
        _finishPanel.Show();
        AfterDied();
    }

    public void AfterDied()
    {
        PauseSwitcher.Instance.Continue();
    }
}
